
using Newtonsoft.Json;
namespace Shattered_pixel_dungeon_CUSTOM.MVVM.Models
{
    public class Hero
    {
        [JsonProperty("STR")]
        public int Strength { get; set; }

        [JsonProperty("HP")]
        public int HealthPoints { get; set; }

        [JsonProperty("HT")]
        public int MaxHealthPoints { get; set; }

        [JsonProperty("attackSkill")]
        public int AttackSkill { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("subClass")]
        public string SubClass { get; set; }

    }
}
