using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessManagementSystem.Shared.Models
{
	public class ApiResponse<T>
	{
		public T Data { get; set; }
		public bool IsError { get; set; }
		public string Description { get; set; }
		public override string ToString()
		{
			var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			return JsonConvert.SerializeObject(this, settings);
		}

		// for glocal Exception Handling
		public bool Succeeded { get; set; }
		public string Message { get; set; }
		public string InnerException { get; set; }
		public static ApiResponse<T> Fail(string errorMessage, string innerException)
		{
			return new ApiResponse<T> { IsError = true, Description = $"{innerException}{errorMessage}", Succeeded = false, Message = errorMessage, InnerException = innerException };
		}
		public static ApiResponse<T> Success(T data)
		{
			return new ApiResponse<T> { Succeeded = true, Data = data };
		}
	}
	public class ApiListResponse<T>
	{
		public IEnumerable<T> Data { get; set; }
		public bool IsError { get; set; }
		public string StatusCode { get; set; }
		public string Description { get; set; }
	}
}
