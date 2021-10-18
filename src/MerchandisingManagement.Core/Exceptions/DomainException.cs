using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagement.Domain.Exceptions
{
	class DomainException : Exception
	{
		internal DomainException(string message)
			: base(message)
		{
		}

		internal DomainException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
