using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJFKModels
{
    public class MemberPickerModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public static MemberPickerModel Deserialize(string json)
        {
            // Validate the JSON
            if (json == null || !json.StartsWith("{") || !json.EndsWith("}"))
            {
                return null;
            }
            // Deserialize the JSON
            var jobj = (JProperty)JsonConvert.DeserializeObject(json);
            return new MemberPickerModel()
            {
                Id = (int)jobj.Value["id"],
                Name = (string)jobj.Value["name"],
            };
        }
    }
}
