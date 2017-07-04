using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StoryLine.Utils.Contracts;

namespace StoryLine.Utils.Services
{
    public class JsonConverter : IDataConverter
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public JsonConverter()
        {
        }

        public JsonConverter(JsonSerializerSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public object Convert(object data, Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var text = data as string;

            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Value cannot be null or empty.", nameof(text));

            return JsonConvert.DeserializeObject(text, type, _settings);
        }
    }
}
