using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	//PEMDAS
	//public enum Token
	//{
	//	EOE, // End of Expression
	//	Number,
	//	Add,
	//	Subtract,
	//	Multiply,
	//	Divide,
	//	Power,
	//	ParenOpen,
	//	ParenClose
	//}
	public class Token
	{
		public const int EOE = 0;
		public const int Number = 1;
		public const int Add = 2;
		public const int Subtract = 3;
		public const int Multiply = 4;
		public const int Divide = 5;
		public const int Power = 7;
		public const int ParenOpen = 8;
		public const int ParenClose = 9;
	}
}
