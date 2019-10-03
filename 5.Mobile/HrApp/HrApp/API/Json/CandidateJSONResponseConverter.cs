using Domain.Model;
using HrApp.API.Beans;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.API.Json
{
    public class CandidateJSONResponseConverter : JsonConverter
    {
        private static JsonConverter instance;

        public static JsonConverter getInstance()
        {
            if (instance == null)
                instance = new CandidateJSONResponseConverter();
            return instance;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CandidatesBeanResponse);
        }

        public override bool CanRead => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            CandidatesBeanResponse toRet = new CandidatesBeanResponse();

            foreach (var jObject in array)
            {
                var singleResponse = JsonConvert.DeserializeObject<CandidatesResponse>(jObject.ToString(),
                    CandidateResponseJSONConverter.getInstance());

                toRet.Candidates.Add(singleResponse);
            }

            return toRet;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
