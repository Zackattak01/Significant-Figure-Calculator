using System;

namespace MathEngine
{
	public class Calculator
	{
		public CalculatorResult Evaluate(string expression)
		{
			Tokenizer tokenizer = new Tokenizer(expression);

			double result;
			try
			{
				Parser parser = new Parser(tokenizer);
				Node node = parser.ParseExpression();
				result = node.Eval();
			}catch(SyntaxException e)
			{
				return new CalculatorResult(false, "", e.Message);
			}

			return new CalculatorResult(true, result.ToString());
		}
	}
}
