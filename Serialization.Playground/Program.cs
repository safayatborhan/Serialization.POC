using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;

namespace Serialization.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomMetadata metadata = new CustomMetadata();
            metadata.Add(new Description
            {
                Text = "Foo bar my app description"
            });
            metadata.Add(new ScreenShot
            {
                ScreenShots = new List<string>
                {
                    "https://foobar/screenshot1.jpg",
                    "https://foobar/screenshot2.jpg"
                }
            });
            metadata.Add(new LinguisticDescription
            {
                Descriptions = new List<MetadataDescription>
                {
                    new MetadataDescription
                    {
                        Description = "My German Description",
                        Language = "DE-DE"
                    },
                    new MetadataDescription
                    {
                        Description = "My French Description",
                        Language = "FR-FR"
                    },
                }
            });
            //Reference : https://stackoverflow.com/questions/24681873/how-can-i-serialize-deserialize-a-dictionary-with-custom-keys-using-json-net/24682429
            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(metadata.dictionary.ToArray()
                , Newtonsoft.Json.Formatting.Indented);

            //var json2 = JsonSerializer.Serialize(metadata.dictionary.ToArray(), typeof(Dictionary<Type, object>), null);

            var mtaData = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyValuePair<Type, object>[]>(json)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            var linguisticDesciptions = 
                Newtonsoft.Json.JsonConvert.DeserializeObject<LinguisticDescription>(mtaData[typeof(LinguisticDescription)].ToString() 
                    ?? string.Empty);

        }

    }
}
