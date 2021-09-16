using System;
using System.Threading.Tasks;
using WDE.Common.Services;
using WDE.Module.Attributes;
using WDE.PacketViewer.Processing.Processors;
using WDE.PacketViewer.Processing.Processors.ActionReaction;

namespace WDE.PacketViewer.Processing.ProcessorProviders
{
    [AutoRegister]
    public class ActionReactionDumperProvider : IPacketDumperProvider
    {
        private readonly IActionReactionProcessorCreator creator;

        public ActionReactionDumperProvider(
            IActionReactionProcessorCreator creator)
        {
            this.creator = creator;
        }
        
        public string Name => "Action - reaction";
        public string Description => "Debug";
        public string Extension => "story";

        public Task<IPacketTextDumper> CreateDumper()
        {
            return Task.FromResult<IPacketTextDumper>(creator.CreateTextProcessor());
        }
    }
}