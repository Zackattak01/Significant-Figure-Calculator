using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine.SigFig
{
	public class SigFigCalculatorResult : CalculatorResult
	{
		public SigFigCalculatorResult(bool success, string unroundedValue, string roundedValue, string errorMessage = "")
			:base(success, unroundedValue, errorMessage)
		{
			RoundedValue = roundedValue;
		}


		public string RoundedValue { get; }

	}
}
