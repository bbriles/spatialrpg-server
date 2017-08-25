﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockBattleService : IBattleService
    {
        protected List<Battle> battles;

        public MockBattleService()
        {
            battles = new List<Battle>();
        }

        public IEnumerable<Battle> GetBattles()
        {
            return (IEnumerable<Battle>)battles;
        }

        public int StartBattle(Encounter encounter, User user)
        {
            var battle = new Battle(encounter, user);

            battles.Add(battle);

            return battle.Id;
        }
    }
}