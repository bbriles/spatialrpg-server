using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Converters
{
    public class StatsJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Stats);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // we currently support only writing of JSON
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var stats = (Stats)value;

            var statNames = new string[] { Stat.HpCurrent, Stat.HpMax, Stat.PhysicalAttack, Stat.PhysicalDefense, Stat.MagicAttack, Stat.MagicDefense, Stat.Speed };

            writer.WriteStartObject();

            foreach (var statName in statNames)
            {
                writer.WritePropertyName(statName);
                serializer.Serialize(writer, stats.GetStat(statName));
            }

            writer.WriteEndObject();
        }
    }
}
