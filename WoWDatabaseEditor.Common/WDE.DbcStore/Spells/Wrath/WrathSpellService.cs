using System;
using System.Collections.Generic;
using System.IO;
using WDE.Common.Services;
using WDE.DbcStore.FastReader;

namespace WDE.DbcStore.Spells.Wrath
{
    public class WrathSpellService : ISpellService
    {
        private Dictionary<uint, SpellStructure> spells = new();
        public void Load(string path)
        {
            var opener = new DatabaseClientFileOpener();
            foreach (var row in opener.Open(Path.Join(path, "Spell.dbc")))
            {
                int i = 0;
                SpellStructure spell = new();
                
                spell.Id = row.GetUInt(i++);
                spell.Category = row.GetUInt(i++);
                spell.DispelType = row.GetUInt(i++);
                spell.Mechanic = row.GetUInt(i++);
                spell.Attributes = (SpellAttr0)row.GetUInt(i++);
                spell.AttributesEx = (SpellAttr1)row.GetUInt(i++);
                spell.AttributesExB = (SpellAttr2)row.GetUInt(i++);
                spell.AttributesExC = (SpellAttr3)row.GetUInt(i++);
                spell.AttributesExD = (SpellAttr4)row.GetUInt(i++);
                spell.AttributesExE = (SpellAttr5)row.GetUInt(i++);
                spell.AttributesExF = (SpellAttr6)row.GetUInt(i++);
                spell.AttributesExG = (SpellAttr7)row.GetUInt(i++);
                spell.ShapeshiftMask[0] = row.GetUInt(i++);
                spell.ShapeshiftMask[1] = row.GetUInt(i++);
                spell.ShapeshiftExclude[0] = row.GetUInt(i++);
                spell.ShapeshiftExclude[1] = row.GetUInt(i++);
                spell.Targets = row.GetUInt(i++);
                spell.TargetCreatureType = row.GetUInt(i++);
                spell.RequiresSpellFocus = row.GetUInt(i++);
                spell.FacingCasterFlags = row.GetUInt(i++);
                spell.CasterAuraState = row.GetUInt(i++);
                spell.TargetAuraState = row.GetUInt(i++);
                spell.ExcludeCasterAuraState = row.GetUInt(i++);
                spell.ExcludeTargetAuraState = row.GetUInt(i++);
                spell.CasterAuraSpell = row.GetUInt(i++);
                spell.TargetAuraSpell = row.GetUInt(i++);
                spell.ExcludeCasterAuraSpell = row.GetUInt(i++);
                spell.ExcludeTargetAuraSpell = row.GetUInt(i++);
                spell.CastingTimeIndex = row.GetUInt(i++);
                spell.RecoveryTime = row.GetUInt(i++);
                spell.CategoryRecoveryTime = row.GetUInt(i++);
                spell.InterruptFlags = row.GetUInt(i++);
                spell.AuraInterruptFlags = row.GetUInt(i++);
                spell.ChannelInterruptFlags = row.GetUInt(i++);
                spell.ProcTypeMask = row.GetUInt(i++);
                spell.ProcChance = row.GetUInt(i++);
                spell.ProcCharges = row.GetUInt(i++);
                spell.MaxLevel = row.GetUInt(i++);
                spell.BaseLevel = row.GetUInt(i++);
                spell.SpellLevel = row.GetUInt(i++);
                spell.DurationIndex = row.GetUInt(i++);
                spell.PowerType = row.GetUInt(i++);
                spell.ManaCost = row.GetUInt(i++);
                spell.ManaCostPerLevel = row.GetUInt(i++);
                spell.ManaPerSecond = row.GetUInt(i++);
                spell.ManaPerSecondPerLevel = row.GetUInt(i++);
                spell.RangeIndex = row.GetUInt(i++);
                spell.Speed = row.GetFloat(i++);
                spell.ModalNextSpell = row.GetUInt(i++);
                spell.CumulativeAura = row.GetUInt(i++);
                spell.Totem[0] = row.GetUInt(i++);
                spell.Totem[1] = row.GetUInt(i++);
                // Reagent<32>[8]
                i += 8;
                //ReagentCount<32>[8]
                i += 8;
                spell.EquippedItemClass = row.GetUInt(i++);
                spell.EquippedItemSubclass = row.GetUInt(i++);
                spell.EquippedItemInvTypes = row.GetUInt(i++);
                spell.Effect[0] = (SpellEffectType)row.GetUInt(i++);
                spell.Effect[1] = (SpellEffectType)row.GetUInt(i++);
                spell.Effect[2] = (SpellEffectType)row.GetUInt(i++);
                spell.EffectDieSides[0] = row.GetUInt(i++);
                spell.EffectDieSides[1] = row.GetUInt(i++);
                spell.EffectDieSides[2] = row.GetUInt(i++);
                spell.EffectRealPointsPerLevel[0] = row.GetFloat(i++);
                spell.EffectRealPointsPerLevel[1] = row.GetFloat(i++);
                spell.EffectRealPointsPerLevel[2] = row.GetFloat(i++);
                spell.EffectBasePoints[0] = row.GetUInt(i++);
                spell.EffectBasePoints[1] = row.GetUInt(i++);
                spell.EffectBasePoints[2] = row.GetUInt(i++);
                spell.EffectMechanic[0] = row.GetUInt(i++);
                spell.EffectMechanic[1] = row.GetUInt(i++);
                spell.EffectMechanic[2] = row.GetUInt(i++);
                spell.ImplicitTargetA[0] = row.GetUInt(i++);
                spell.ImplicitTargetA[1] = row.GetUInt(i++);
                spell.ImplicitTargetA[2] = row.GetUInt(i++);
                spell.ImplicitTargetB[0] = row.GetUInt(i++);
                spell.ImplicitTargetB[1] = row.GetUInt(i++);
                spell.ImplicitTargetB[2] = row.GetUInt(i++);
                spell.EffectRadiusIndex[0] = row.GetUInt(i++);
                spell.EffectRadiusIndex[1] = row.GetUInt(i++);
                spell.EffectRadiusIndex[2] = row.GetUInt(i++);
                spell.EffectAura[0] = row.GetUInt(i++);
                spell.EffectAura[1] = row.GetUInt(i++);
                spell.EffectAura[2] = row.GetUInt(i++);
                spell.EffectAuraPeriod[0] = row.GetUInt(i++);
                spell.EffectAuraPeriod[1] = row.GetUInt(i++);
                spell.EffectAuraPeriod[2] = row.GetUInt(i++);
                spell.EffectAmplitude[0] = row.GetFloat(i++);
                spell.EffectAmplitude[1] = row.GetFloat(i++);
                spell.EffectAmplitude[2] = row.GetFloat(i++);
                spell.EffectChainTargets[0] = row.GetUInt(i++);
                spell.EffectChainTargets[1] = row.GetUInt(i++);
                spell.EffectChainTargets[2] = row.GetUInt(i++);
                spell.EffectItemType[0] = row.GetUInt(i++);
                spell.EffectItemType[1] = row.GetUInt(i++);
                spell.EffectItemType[2] = row.GetUInt(i++);
                spell.EffectMiscValue[0] = row.GetUInt(i++);
                spell.EffectMiscValue[1] = row.GetUInt(i++);
                spell.EffectMiscValue[2] = row.GetUInt(i++);
                spell.EffectMiscValueB[0] = row.GetUInt(i++);
                spell.EffectMiscValueB[1] = row.GetUInt(i++);
                spell.EffectMiscValueB[2] = row.GetUInt(i++);
                spell.EffectTriggerSpell[0] = row.GetUInt(i++);
                spell.EffectTriggerSpell[1] = row.GetUInt(i++);
                spell.EffectTriggerSpell[2] = row.GetUInt(i++);
                spell.EffectPointsPerCombo[0] = row.GetFloat(i++);
                spell.EffectPointsPerCombo[1] = row.GetFloat(i++);
                spell.EffectPointsPerCombo[2] = row.GetFloat(i++);
                spell.EffectSpellClassMaskA[0] = row.GetUInt(i++);
                spell.EffectSpellClassMaskA[1] = row.GetUInt(i++);
                spell.EffectSpellClassMaskA[2] = row.GetUInt(i++);
                spell.EffectSpellClassMaskB[0] = row.GetUInt(i++);
                spell.EffectSpellClassMaskB[1] = row.GetUInt(i++);
                spell.EffectSpellClassMaskB[2] = row.GetUInt(i++);
                spell.EffectSpellClassMaskC[0] = row.GetUInt(i++);
                spell.EffectSpellClassMaskC[1] = row.GetUInt(i++);
                spell.EffectSpellClassMaskC[2] = row.GetUInt(i++);
                spell.SpellVisualId[0] = row.GetUInt(i++);
                spell.SpellVisualId[1] = row.GetUInt(i++);
                spell.SpellIconId = row.GetUInt(i++);
                spell.ActiveIconId = row.GetUInt(i++);
                spell.SpellPriority = row.GetUInt(i++);
                spell.Name = row.GetString(i++);
                spell.NameSubtext = row.GetString(i++);
                spell.Description = row.GetString(i++);
                spell.AuraDescription = row.GetString(i++);
                spell.ManaCostPct = row.GetUInt(i++);
                spell.StartRecoveryCategory = row.GetUInt(i++);
                spell.StartRecoveryTime = row.GetUInt(i++);
                spell.MaxTargetLevel = row.GetUInt(i++);
                spell.SpellClassSet = row.GetUInt(i++);
                spell.SpellClassMask[0] = row.GetUInt(i++);
                spell.SpellClassMask[1] = row.GetUInt(i++);
                spell.SpellClassMask[2] = row.GetUInt(i++);
                spell.MaxTargets = row.GetUInt(i++);
                spell.DefenseType = row.GetUInt(i++);
                spell.PreventionType = row.GetUInt(i++);
                spell.StanceBarOrder = row.GetUInt(i++);
                spell.EffectChainAmplitude[0] = row.GetFloat(i++);
                spell.EffectChainAmplitude[1] = row.GetFloat(i++);
                spell.EffectChainAmplitude[2] = row.GetFloat(i++);
                spell.MinFactionId = row.GetUInt(i++);
                spell.MinReputation = row.GetUInt(i++);
                spell.RequiredAuraVision = row.GetUInt(i++);
                spell.RequiredTotemCategoryID[0] = row.GetUInt(i++);
                spell.RequiredTotemCategoryID[1] = row.GetUInt(i++);
                spell.RequiredAreasId = row.GetUInt(i++);
                spell.SchoolMask = row.GetUInt(i++);
                spell.RuneCostId = row.GetUInt(i++);
                spell.SpellMissileId = row.GetUInt(i++);
                spell.PowerDisplayId = row.GetUInt(i++);
                spell.EffectBonusCoefficient[0] = row.GetFloat(i++);
                spell.EffectBonusCoefficient[1] = row.GetFloat(i++);
                spell.EffectBonusCoefficient[2] = row.GetFloat(i++);
                spell.DescriptionVariablesId = row.GetUInt(i++);
                spell.Difficulty = row.GetUInt(i++);

                spells[spell.Id] = spell;
            }
        }
        
        public bool Exists(uint spellId)
        {
            return spells.ContainsKey(spellId);
        }

        public T GetAttributes<T>(uint spellId) where T : Enum
        {

            if (!spells.TryGetValue(spellId, out var spell))
                return default;

            // kinda unnecessary boxing :/
            if (typeof(T) == typeof(SpellAttr0))
                return (T)(object)spell.Attributes;

            if (typeof(T) == typeof(SpellAttr1))
                return (T)(object)spell.AttributesEx;

            if (typeof(T) == typeof(SpellAttr2))
                return (T)(object)spell.AttributesExB;

            if (typeof(T) == typeof(SpellAttr3))
                return (T)(object)spell.AttributesExC;

            if (typeof(T) == typeof(SpellAttr4))
                return (T)(object)spell.AttributesExD;

            if (typeof(T) == typeof(SpellAttr5))
                return (T)(object)spell.AttributesExE;

            if (typeof(T) == typeof(SpellAttr6))
                return (T)(object)spell.AttributesExF;

            if (typeof(T) == typeof(SpellAttr7))
                return (T)(object)spell.AttributesExG;

            return default;
        }

        public int GetSpellEffectsCount(uint spellId)
        {
            if (spells.TryGetValue(spellId, out var spell))
                return spell.Effect[0] == SpellEffectType.None ? 0 :
                    (spell.Effect[1] == SpellEffectType.None ? 1 : 
                        (spell.Effect[2] == SpellEffectType.None ? 2 : 3));
            return 0;
        }

        public SpellEffectType GetSpellEffectType(uint spellId, int index)
        {
            if (spells.TryGetValue(spellId, out var spell))
                return spell.Effect[index];
            return SpellEffectType.None;
        }

        public uint GetSpellEffectMiscValueA(uint spellId, int index)
        {
            if (spells.TryGetValue(spellId, out var spell))
                return spell.EffectMiscValue[index];
            return 0;
        }
    }
}