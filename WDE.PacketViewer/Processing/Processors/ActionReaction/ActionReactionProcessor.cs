using System;
using System.Collections.Generic;
using System.Linq;
using WDE.PacketViewer.Processing.Processors.ActionReaction.Rating;
using WDE.PacketViewer.Utils;
using WowPacketParser.Proto;
using WowPacketParser.Proto.Processing;

namespace WDE.PacketViewer.Processing.Processors.ActionReaction
{
    public class ActionReactionProcessor : IPacketProcessor<bool>, ITwoStepPacketBoolProcessor
    {
        private readonly ActionGenerator actionGenerator;
        private readonly EventDetectorProcessor eventDetectorProcessor;
        private readonly IRandomMovementDetector randomMovementDetector;
        private readonly IChatEmoteSoundProcessor chatEmoteSoundProcessor;
        private readonly IWaypointProcessor waypointsProcessor;
        private readonly IUnitPositionFollower unitPositionFollower;
        private readonly IUpdateObjectFollower updateObjectFollower;
        private readonly IPlayerGuidFollower playerGuidFollower;

        public ActionReactionProcessor(
            ActionGenerator actionGenerator,
            EventDetectorProcessor eventDetectorProcessor,
            IRandomMovementDetector randomMovementDetector, 
            IChatEmoteSoundProcessor chatEmoteSoundProcessor, 
            IWaypointProcessor waypointsProcessor,
            IUnitPositionFollower unitPositionFollower,
            IUpdateObjectFollower updateObjectFollower,
            IPlayerGuidFollower playerGuidFollower)
        {
            this.actionGenerator = actionGenerator;
            this.eventDetectorProcessor = eventDetectorProcessor;
            this.randomMovementDetector = randomMovementDetector;
            this.chatEmoteSoundProcessor = chatEmoteSoundProcessor;
            this.waypointsProcessor = waypointsProcessor;
            this.unitPositionFollower = unitPositionFollower;
            this.updateObjectFollower = updateObjectFollower;
            this.playerGuidFollower = playerGuidFollower;
        }

        public EventHappened? GetLastEventHappened()
        {
            if (eventDetectorProcessor.CurrentIndex == -1)
                return null;
            return eventDetectorProcessor.GetEvent(eventDetectorProcessor.CurrentIndex);
        }
        
        public ActionHappened? GetAction(int number)
        {
            if (!actionsHappened.TryGetValue(number, out var state))
                return null;
            return state.Item2[0];
        }

        public ActionHappened? GetAction(PacketBase packet) => GetAction(packet.Number);

        public IEnumerable<(IEvaluation rate, EventHappened @event)> GetPossibleEventsForAction(PacketBase packet) => GetPossibleEventsForAction(packet.Number);

        public IEnumerable<(IEvaluation rate, EventHappened @event)> GetPossibleEventsForAction(int number)
        {
            if (number == 22081)
            {
                Console.WriteLine();
            }
        
            if (chatEmoteSoundProcessor.IsEmoteForChat(number))
            {
                yield return (Const.One, new EventHappened()
                {
                    Description = "Emote for the next SMSG_CHAT",
                    PacketNumber = chatEmoteSoundProcessor.GetChatPacketForEmote(number)!.Value
                });
                yield break;
            }

            // if (waypointsProcessor.GetOriginalSpline(number) is { } originalPacket)
            // {
            //     yield return (Const.One, new EventHappened()
            //     {
            //         Description = $"Part of spline begun in packet {originalPacket}",
            //         PacketNumber = originalPacket
            //     });
            //     yield break;
            // }
            
            if (!actionsHappened.TryGetValue(number, out var state))
                yield break;

            var action = state.Item2[0];
            
            List<(IEvaluation, EventHappened)> reasons = new();
            int i = state.Item1;
            while (i >= 0 && reasons.Count < 50)
            {
                var @event = eventDetectorProcessor.GetEvent(i--);

                if (@event.PacketNumber == action.PacketNumber)
                    continue;
                
                float? distToEvent = null;
                if (@event.EventLocation != null && action.EventLocation != null)
                    distToEvent = @event.EventLocation.Distance3D(action.EventLocation);

                var timePassed = action.Time - @event.Time;

                if (timePassed.TotalSeconds > 20)
                    break;
                
                // special cases

                
                if (@event.RestrictedAction.HasValue &&
                    @event.RestrictedAction.Value != action.Kind)
                    continue;
                
                if (action.RestrictEvent.HasValue &&
                    action.RestrictEvent.Value != @event.Kind)
                    continue;

                if (action.Kind == ActionType.GossipMessage &&
                    (@event.Kind != EventType.GossipSelect &&
                     @event.Kind != EventType.GossipHello))
                    continue;
                
                if (@event.Kind == EventType.AuraShouldBeRemoved &&
                    action.Kind == ActionType.AuraRemoved &&
                    @event.CustomEntry != action.CustomEntry)
                    continue;

                if (@event.Kind == EventType.GossipMessageShown &&
                    action.Kind == ActionType.GossipSelect &&
                    @event.CustomEntry != action.CustomEntry)
                    continue;
                
                // special cases
                
                if (@event.Kind == EventType.StartMovement &&
                    action.Kind == ActionType.ContinueMovement &&
                    @event.CustomEntry != action.CustomEntry)
                    continue;
                
                //
                
                if (@event.Kind == EventType.SpellCasted &&
                    action.Kind == ActionType.AuraApplied &&
                    @event.CustomEntry != action.CustomEntry)
                    continue;
                
                //
                
                if (@event.Kind == EventType.SummonBySpell &&
                    (action.Kind != ActionType.Summon || action.MainActor!.Entry != @event.CustomEntry))
                    continue;

                if (action.Kind == ActionType.ExitsCombat && (
                    @event.Kind != EventType.EnterCombat ||
                    !action.MainActor!.Equals(@event.MainActor)))
                    continue;
                
                //
                
                var actorsRating = (action.MainActor?.Equals(@event.MainActor) ?? false) ? Const.One : Const.Zero;
                if (actorsRating.Value == 0 && action.AdditionalActors != null &&
                    action.AdditionalActors[0].Equals(@event.MainActor))
                    actorsRating = Const.One;
                else if (actorsRating.Value == 0 && @event.AdditionalActors != null &&
                         @event.AdditionalActors[0].Equals(action.MainActor))
                    actorsRating = Const.One;
                else if (actorsRating.Value == 0 && action.AdditionalActors != null &&
                         @event.AdditionalActors != null &&
                         @event.AdditionalActors[0].Equals(action.AdditionalActors[0]))
                    actorsRating = Const.Half;
                if (actorsRating.Value == 0 && action.CustomEntry.HasValue &&
                    action.CustomEntry.Value == @event.MainActor?.Entry)
                    actorsRating = new Const(0.8f);

                var distRating = new OneMinus(new Power(new Remap(new Const(distToEvent ?? 33.5f), 0, 75, 0, 1), 1));

                var timeRating =
                    new OneMinus(
                        new Power(new Remap(new Const((float)timePassed.TotalMilliseconds), 0, 10000 * (@event.TimeFactor ?? 1) * (action.TimeFactor ?? 1), 0, 1),  4));

                IEvaluation? bonus = action.CustomEntry.HasValue && @event.CustomEntry.HasValue &&
                                    action.CustomEntry.Value == @event.CustomEntry.Value ? Const.One : null;
                
                var rating = new Weighted((actorsRating, 0.4f), (timeRating, 0.35f), (distRating, 0.25f), (bonus, 0.2f));

                float bonusMult = (@event.Kind == EventType.ChatOver && action.Kind == ActionType.Chat) ? 1.3f : 1.0f;

                // bonus for packets sent in the same time
                if (@event.Time == action.Time)
                    bonusMult += 0.5f;
                
                if (@event.Kind == EventType.SummonBySpell &&
                    action.Kind == ActionType.Summon && action.MainActor!.Entry == @event.CustomEntry)
                    bonusMult += 10;

                if (@event.Kind == EventType.GossipSelect &&
                    action.Kind == ActionType.GossipMessage &&
                    timePassed.TotalSeconds > 1)
                    bonusMult = 0; // if event is select option, then action gossip message is accepted only if it is within ~0.5s

                if (@event.Kind == EventType.Movement && distRating.Value < 0.01)
                    bonusMult = 0;

                var ratingBonused = new Multiply(rating, bonusMult);

                if (ratingBonused.Value > 0.5f || ratingBonused.Value > 0.25f && actorsRating.Value > 0.5f)
                    reasons.Add((ratingBonused, @event));
            }

            if (reasons.Count > 0)
            {
                foreach (var r in reasons.OrderByDescending(o => o.Item1.Value))
                {
                    yield return r;
                }
            }
        }
        
        // action packet Id -> what are actions
        private Dictionary<int, (int, List<ActionHappened>)> actionsHappened = new();
        
        // reverse lookup: event packet id -> what are possible actions, this event caused
        private Dictionary<int, List<(int packetId, double chance, EventHappened happened)>>? reverseLookup;

        public virtual bool Process(PacketHolder packet)
        {
            playerGuidFollower.Process(packet);
            unitPositionFollower.Process(packet);
            
            eventDetectorProcessor.Flush(packet.BaseData.Time.ToDateTime());
            var actions = actionGenerator.Process(packet);
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (!actionsHappened.TryGetValue(packet.BaseData.Number, out var list))
                        list = actionsHappened[packet.BaseData.Number] = (eventDetectorProcessor.CurrentIndex - 1,
                            new List<ActionHappened>());
                    
                    list.Item2.Add(action);
                }
            }

            eventDetectorProcessor.Process(packet);

            updateObjectFollower.Process(packet);
            return true;
        }

        public void BuildReverseLookup()
        {
            if (reverseLookup != null)
                return;
            reverseLookup = new();
            
            foreach (var actionPacketId in actionsHappened)
            {
                foreach (var reason in GetPossibleEventsForAction(actionPacketId.Key))
                {
                    if (!reverseLookup.TryGetValue(reason.@event.PacketNumber, out var r))
                        r = reverseLookup[reason.@event.PacketNumber] = new();
                    r.Add((actionPacketId.Key, reason.rate.Value, reason.@event));
                }
            }
        }

        // returns sorted list of possible actions by event packet id
        public IEnumerable<(int packetId, double chance, EventHappened happened)> GetPossibleActionsForEvent(int eventPacketId)
        {
            BuildReverseLookup();
            if (reverseLookup!.TryGetValue(eventPacketId, out var list))
            {
                if (list.Count == 0)
                    return list;
                var limit = list[0].happened.LimitActionsCount;
                IEnumerable<(int packetId, double chance, EventHappened happened)> enumerable = list.OrderByDescending(p => p.chance);
                if (limit.HasValue)
                    enumerable = enumerable.Take(limit.Value);
                return enumerable;
            }
            return Enumerable.Empty<(int packetId, double chance, EventHappened happened)>();
        }

        public bool PreProcess(PacketHolder packet)
        {
            randomMovementDetector.Process(packet);
            chatEmoteSoundProcessor.Process(packet);
            waypointsProcessor.Process(packet);
            return true;
        }
    }
}