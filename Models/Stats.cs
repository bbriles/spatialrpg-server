using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Stats
    {
        protected Dictionary<string, int> stats;

        public Stats(Dictionary<string, int> initStats)
        {
            if (initStats != null)
            {
                stats = new Dictionary<string, int>(initStats);
            }
            else
            {
                stats = new Dictionary<string, int>();
            }
            SetDefaultStats();
        }

        protected void SetDefaultStats()
        {
            if (!stats.ContainsKey(Stat.HpMax)) stats[Stat.HpMax] = 0;
            stats.Add(Stat.HpCurrent, stats[Stat.HpMax]);
            if (!stats.ContainsKey(Stat.PhysicalAttack)) stats[Stat.PhysicalAttack] = 0;
            if (!stats.ContainsKey(Stat.MagicAttack)) stats[Stat.MagicAttack] = 0;
            if (!stats.ContainsKey(Stat.PhysicalDefense)) stats[Stat.PhysicalDefense] = 0;
            if (!stats.ContainsKey(Stat.MagicDefense)) stats[Stat.MagicDefense] = 0;
            if (!stats.ContainsKey(Stat.Speed)) stats[Stat.Speed] = 0;
            if (!stats.ContainsKey(Stat.RecruitRate)) stats[Stat.RecruitRate] = 0;
        }

        public int GetStat(string name)
        {
            // apply modifiers to value returned

            try
            {
                return stats[name];
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
