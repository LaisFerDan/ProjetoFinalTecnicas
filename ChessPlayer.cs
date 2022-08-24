using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoFinalTecnicas
{
    public class ChessPlayer
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("url")]
        public string url { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("username")]
        public string username { get; set; }
        [JsonPropertyName("best_rating")]
        public int best_rating { get; set; }
        [JsonPropertyName("wins")]
        public int wins { get; set; }
        [JsonPropertyName("loses")]
        public int loses { get; set; }
        [JsonPropertyName("number_of_games")]
        public int number_of_games { get; set; }
        [JsonPropertyName("followers")]
        public int followers { get; set; }
        [JsonPropertyName("country")]
        public string country { get; set; }
        [JsonPropertyName("last_online")]
        public DateTime last_online { get; set; }
        [JsonPropertyName("joined")]
        public DateTime joined { get; set; }

        public ChessPlayer(string username)
        {
            this.username = username;
        }
    }
        
}
