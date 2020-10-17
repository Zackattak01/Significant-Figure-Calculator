using System;
using System.Collections.Generic;
using System.Text;

namespace SigFigEngineTests
{
	public class TestExpression
	{
		public TestExpression(string expression, string expectedValue)
		{
			Expression = expression;
			ExpectedValue = expectedValue;
		}

		public string Expression { get; }
		public string ExpectedValue { get; }

	}
}
