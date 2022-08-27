using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoFinalTecnicas.Interfaces
{
    public interface IChessPlayer
    {
        [JsonPropertyName("id")]
         int id { get; set; }
        [JsonPropertyName("url")]
         string url { get; set; }
        [JsonPropertyName("name")]
         string name { get; set; }
        [JsonPropertyName("username")]
         string username { get; set; }
        [JsonPropertyName("best_rating")]
         int best_rating { get; set; }
        [JsonPropertyName("wins")]
         int wins { get; set; }
        [JsonPropertyName("loses")]
         int loses { get; set; }
        [JsonPropertyName("number_of_games")]
         int number_of_games { get; set; }
        [JsonPropertyName("followers")]
         int followers { get; set; }
        [JsonPropertyName("country")]
         string country { get; set; }
        [JsonPropertyName("last_online")]
         DateTime last_online { get; set; }
        [JsonPropertyName("joined")]
         DateTime joined { get; set; }
    }
}
