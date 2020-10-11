using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class CalculatorResult
	{
		public CalculatorResult(bool success, string value, string errorMessage = "")
		{
			Success = success;
			Value = value;
			ErrorMessage = errorMessage;
		}

		public bool Success { get; }

		public string ErrorMessage { get; }

		public string Value { get; }
	}
}
