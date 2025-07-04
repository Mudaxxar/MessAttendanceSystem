using System.Globalization;

namespace MessManagemetSystem.API.CustomExceptionHandling
{
	public class CustomeException : Exception
	{
		public CustomeException() : base()
		{
		}
		public CustomeException(string message) : base(message)
		{
		}
		public CustomeException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
		{
		}
	}
}
