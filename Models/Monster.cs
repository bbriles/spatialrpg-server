using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class Monster
    {
        private MonsterKind _kind;
        public MonsterKind Kind
        {
            get
            {
                return _kind;
            }
            set
            {
                _kind = value;
                stats = new Stats(_kind.BaseStats);
            }
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public Stats stats;

        public Monster()
        {
        }
    }
}
