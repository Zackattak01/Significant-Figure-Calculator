using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class SyntaxException : Exception
	{
		public SyntaxException(string message) : base(message)
		{

		}
	}
}
