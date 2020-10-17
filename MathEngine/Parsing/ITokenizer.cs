using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public interface ITokenizer
	{
		int CurrentToken { get;}

		double CurrentNumber { get; }

		void NextToken();
	}
}
