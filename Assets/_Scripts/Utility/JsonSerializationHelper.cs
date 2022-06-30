namespace Assets._Scripts.Utility
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    namespace Mark4.Utility
    {
        public static class JsonSerializationHelper
        {
            private static JsonSerializer _defaultSerializerAsync = JsonSerializer.CreateDefault();
            private static StringBuilder _stringBuilderAsync = new StringBuilder();

            public static string SerializeObject<T>(T value, Formatting formatting = Formatting.None)
            {
                var result = JsonConvert.SerializeObject(
                  value,
                  formatting,
                  new JsonSerializerSettings()
                  {
                      TypeNameHandling = TypeNameHandling.Auto,
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  });
                return result;
            }

            public static async Task<string> SerializeObjectAsync<T>(T value, Formatting formatting = Formatting.None)
            {
                string result = string.Empty;
                try
                {
                    result = await Task.Run<string>(() =>
                    {
                        lock (_stringBuilderAsync)
                        {
                            _stringBuilderAsync.Clear();
                            using (StringWriter writer = new StringWriter(_stringBuilderAsync))
                            using (JsonWriter jwriter = new JsonTextWriter(writer))
                            {
                                jwriter.Formatting = formatting;
                                lock (_defaultSerializerAsync)
                                {
                                    _defaultSerializerAsync.Serialize(jwriter, value, typeof(T));
                                }
                            }
                            return _stringBuilderAsync.ToString();
                        }
                    });
                }
                catch (System.Exception)
                {
                    result = SerializeObject(value, formatting);
                }

                return result;
            }

            public static T DeserializeObject<T>(string jString)
            {
                return (T)JsonConvert.DeserializeObject(
                    jString,
                    typeof(T),
                    new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
        }
    }
}
