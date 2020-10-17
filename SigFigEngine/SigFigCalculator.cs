using System;
using System.Linq;
using MathEngine.SigFig.Extensions;

namespace MathEngine.SigFig
{
	public class SigFigCalculator
	{

		public SigFigCalculatorResult Evaluate(string expression)
		{
			SigFigTokenizer tokenizer = new SigFigTokenizer(expression);
			
			double result = 0;
			try
			{
				Parser parser = new Parser(tokenizer);
				Node node = parser.ParseExpression();
				result = node.Eval();
			}
			catch (SyntaxException e)
			{
				return new SigFigCalculatorResult(false, "", "", e.Message);
			}


			double resultRounded;

			if(expression.Contains('/') || expression.Contains('*'))
			{
				
				int lowestNumOfSigFigs = tokenizer.NumbersParsed.OrderBy(x => x.GetSigFigAmount()).First().GetSigFigAmount();
				resultRounded = RoundNumberMultiplication(result, lowestNumOfSigFigs);

				return new SigFigCalculatorResult(true, result.ToString(), resultRounded.ToString().AddExtraSigFigs(lowestNumOfSigFigs));
			}
			else
			{
				

				if(!(tokenizer.NumbersParsed.Count > 0))
				{
					return new SigFigCalculatorResult(false, "", "", errorMessage: "No sig figs to calculate");
				}

				//same buisness as the spooky one above just with after the decimal sig figs
				int lowestNumOfSigFigs = tokenizer.NumbersParsed.OrderBy(x => x.GetSigFigAmountAfterDecimal()).First().GetSigFigAmountAfterDecimal();

				resultRounded = RoundNumberAddition(result, lowestNumOfSigFigs);
				string resultRoundedStr = resultRounded.ToString().AddExtraSigFigs(lowestNumOfSigFigs, ExtraSigFigsMode.AddSub);
				return new SigFigCalculatorResult(true, result.ToString(), resultRoundedStr);
			}
			


			
			
		}


		private double RoundNumberMultiplication(double result, int lowestNumOfSigFigs)
		{
			double resultRounded;
			string resultStr = result.ToString();
			int digitsBefore = resultStr.Split('.').First().Length;
			int digitsAfter = resultStr.Split('.').Last().Length;
			int resultStrSigFigs = resultStr.GetSigFigAmount();

			if (resultStrSigFigs == lowestNumOfSigFigs)
			{
				resultRounded = result;
			}
			else if (digitsBefore - lowestNumOfSigFigs >= 0)
			{
				resultRounded = result.RoundTo(Math.Pow(10, digitsBefore - lowestNumOfSigFigs));
			}
			else if (digitsAfter - lowestNumOfSigFigs >= 0)
			{
				resultRounded = Math.Round(result, lowestNumOfSigFigs - digitsBefore);
			}
			else
			{
				resultRounded = result;
			}

			return resultRounded;
		}

		private double RoundNumberAddition(double result, int lowestNumOfSigFigs)
		{
			return Math.Round(result, lowestNumOfSigFigs);
		}
		
	}
}
