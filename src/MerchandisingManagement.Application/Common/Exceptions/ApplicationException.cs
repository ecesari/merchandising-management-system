using System;

namespace MerchandisingManagement.Application.Common.Exceptions
{
	class ApplicationException : Exception
	{
		internal ApplicationException(string message)
			: base(message)
		{
		}

		internal ApplicationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
