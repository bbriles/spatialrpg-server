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
        public char Operator { get; set; }
        public string AffectedStat { get; set; }
        public double Amount { get; set; }
    }

    public struct Operator
    {
        public const string Attack = "Attack";
        public const string Buff = "Buff";
        public const string Debuff = "Debuff";

    }
}
