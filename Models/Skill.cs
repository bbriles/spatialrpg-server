using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AffectedStat { get; set; }
        public string RelatedStat { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public string Type { get; set; }
    }

    // Skill type determines what kind of formula is used
    public struct SkillType
    {
        public const string Attack = "Attack";
        public const string Restore = "Restore";
    }

    public struct TargetType
    {
        public const string Single = "Single";
        public const string Group = "Group";
        public const string All = "All";
        public const string Self = "Self";
    }
}
