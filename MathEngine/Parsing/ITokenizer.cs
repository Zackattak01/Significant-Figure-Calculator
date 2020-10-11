using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public interface ITokenizer
	{
		Token CurrentToken { get;}

		double CurrentNumber { get; }

		void NextToken();
	}
}
