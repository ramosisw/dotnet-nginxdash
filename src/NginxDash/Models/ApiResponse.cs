using Newtonsoft.Json;
using System.Net;
using System;

namespace NginxDash.Models
{
    public class EmptyPayload { }
    public class ApiResponse<T>
    {
        private readonly JsonSerializerSettings jsonSettings;
        public ApiResponse()
        {
            jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public bool HasError { get; set; } = false;
        public int Code { get; set; } = 200;
        public string Message { get; set; } = "Success";
        public T Payload { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, jsonSettings);
        }
    }
    public class ApiResponse : ApiResponse<EmptyPayload>
    {
        public ApiResponse()
        {
            Payload = new EmptyPayload();
        }
    }
}