using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	//PEMDAS
	public enum Token
	{
		EOE, // End of Expression
		Number,
		Add,
		Subtract,
		Multiply,
		Divide,
		Power,
		ParenOpen,
		ParenClose
	}
}
