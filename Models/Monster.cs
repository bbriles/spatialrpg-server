using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class Monster
    {
        private MonsterType _type;
        public MonsterType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                Stats = new Stats(_type.BaseStats);
            }
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public Stats Stats { get; set; }

        public Monster()
        {
        }
    }
}
