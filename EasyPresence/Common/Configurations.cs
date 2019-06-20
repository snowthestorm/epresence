using Newtonsoft.Json;

namespace EasyPresence.Common
{
    public class Configurations
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("details")]
        public string Details { get; set; }
        
        [JsonProperty("image")]
        public string Image { get; set; }
        
        [JsonProperty("image_text")]
        public string ImageText { get; set; }
    }
}