using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models.ResponseModels
{
        public class ValidationErrorResponse
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("status")]
            public int Status { get; set; }

            [JsonPropertyName("errors")]
            public Dictionary<string, List<string>> Errors { get; set; }

            [JsonPropertyName("traceId")]
            public string TraceId { get; set; }
        }
    }
