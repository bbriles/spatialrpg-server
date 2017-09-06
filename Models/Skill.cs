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
        public Operator Operator { get; set; }
        public string RelatedStat { get; set; }
        public string AffectedStat { get; set; }
        public double Amount { get; set; }
    }

    public enum Operator
    {
        Add = 0,
        Multiply = 1
    }
}
