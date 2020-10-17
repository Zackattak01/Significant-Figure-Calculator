using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathEngine.SigFig;
using System.Collections.Generic;

namespace SigFigEngineTests
{
	[TestClass]
	public class SigFigCalculatorTests
	{
		List<TestExpression> expressions = new List<TestExpression>
		{
			new TestExpression("5 + 5", "10"),
			new TestExpression("5.241 * 5.22", "27.4"),
			new TestExpression("(5.00 + 5.7) * 6.65", "71"),
			new TestExpression("(a5.00 + a5.7) * 6.65", "71.2"),
			new TestExpression("15000 * 10000", "200000000"),
			new TestExpression("15000 * 10001", "150000000"),
			new TestExpression("5.1 + 5", "10"),
			new TestExpression("5.1 + 5.1", "10.2"),
			new TestExpression("5.0 + 5.0", "10.0"),
			new TestExpression("5 * 5", "30"),
			new TestExpression("5.0 * 5.0", "25"),
			new TestExpression("5.00 * 5.00", "25.0"),
		};

		[TestMethod]
		public void EvaluateWithCorrectSigFigRounding()
		{
			SigFigCalculator calc = new SigFigCalculator();

			foreach (var expression in expressions)
			{
				SigFigCalculatorResult result = calc.Evaluate(expression.Expression);

				Assert.AreEqual(expression.ExpectedValue, result.RoundedValue, 
					$"Expression: \"{expression.Expression}\" was not evaluted correctly with a result of \"{result.RoundedValue}\"");
			}
		}
	}
}
