using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Serialization.POC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string json = @"{
                                ""Id"" : ""bf005e39-d263-4939-867d-41e12cbe5458"",
                                ""ProductName"" : ""My Cool Product"",
                                ""Descriptions"" : [
                                            {
                                                ""Text"": ""My German Description"",
                                                ""Language"": ""DE-DE"",
                                            },
                                            {
                                                ""Text"" : ""My French Description"",
                                                ""Language"": ""FR-FR"",
                                            }
                                        ]
                            }";

            var pr = GetJsonGenericType<Description>(json);

            Product product = Deserialize<Product>(json);
        }

        //https://stackoverflow.com/a/2246771/10868761
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray());
            return retVal;
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }

        //https://www.thecodebuzz.com/deserialize-json-into-type-object-dynamically/
        private static T GetJsonGenericType<T>(string strJSON)
        {
            var generatedType = JsonConvert.DeserializeObject<T>(strJSON); // using newtonsoft
            return (T)Convert.ChangeType(generatedType, typeof(T));
        }
    }
}
