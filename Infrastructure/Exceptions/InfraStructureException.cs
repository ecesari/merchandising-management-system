using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagement.Infrastructure.Exceptions
{
	class InfrastructureException : Exception
	{
		internal InfrastructureException(string message)
			: base(message)
		{
		}

		internal InfrastructureException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
