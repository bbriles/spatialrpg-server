using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpatialRPGServer.Converters;

namespace SpatialRPGServer.Models
{
    [JsonConverter(typeof(StatsJsonConverter))]
    public class Stats
    {
        public int Level { get; set; }
        protected Dictionary<string, int> baseStats;
        protected Dictionary<string, int> individualStats;

        public Stats(Dictionary<string, int> typeStats)
        {
            baseStats = typeStats;

            // TODO: Individual Values
            GenerateIndividualStats();

            // TODO: Make Level not always a default value
            Level = 10;

            // TODO: Fix this to work with loading monsters not at full health
            individualStats[Stat.HpCurrent] = GetStat(Stat.HpMax);
        }

        public int GetStat(string stat)
        {
            var statValue = 0;

            // HP Current is a special case
            if (stat == Stat.HpCurrent)
            {
                statValue = GetStatOrDefault(stat, individualStats);
            }
            else if (stat == Stat.RecruitRate) // Recruit Rate is also a special case
            {
                statValue = GetStatOrDefault(stat, baseStats);
            }
            else
            {
                var baseVal = GetStatOrDefault(stat, baseStats);
                var individualVal = GetStatOrDefault(stat, individualStats);

                // HP Max has different formula than everything else
                if (stat == Stat.HpMax)
                {
                    statValue = (2 * baseVal + individualVal) * Level / 100 + Level + 10;
                }
                else
                {
                    statValue = (2 * baseVal + individualVal) * Level / 100 + 5;
                }

            }

            // apply modifiers to value returned


            return statValue;
        }

        private void GenerateIndividualStats()
        {
            individualStats = new Dictionary<string, int>() {
                { Stat.HpMax, 0 }, { Stat.PhysicalAttack, 0 }, { Stat.PhysicalDefense, 0 },
                { Stat.MagicAttack, 0 }, {Stat.MagicDefense, 0}, {Stat.Speed, 0}
            };
        }

        private int GetStatOrDefault(string stat, Dictionary<string, int> statDict)
        {
            try
            {
                return statDict[stat];
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

    }

    public struct Stat
    {
        public const string HpMax = "hpMax";
        public const string HpCurrent = "hpCurrent";
        public const string PhysicalAttack = "physicalAttack";
        public const string MagicAttack = "magicAttack";
        public const string PhysicalDefense = "physicalDefense";
        public const string MagicDefense = "magicDefense";
        public const string Speed = "speed";
        public const string RecruitRate = "recruitRate";
    }
}
