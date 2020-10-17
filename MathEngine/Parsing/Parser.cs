using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class Parser : IParser
	{
		public Parser(ITokenizer tokenizer)
		{
			this.tokenizer = tokenizer;
		}

		protected ITokenizer tokenizer;

		public virtual Node ParseExpression()
		{
			Node expr = ParseAddSubtract();

			if (tokenizer.CurrentToken != Token.EOE)
				throw new SyntaxException("Unexpected characters at the end of the expression."); 

			return expr;
		}

		protected virtual Node ParseAddSubtract()
		{
			Node lhs = ParseMultiplyDivide();

			while (true)
			{
				Func<double, double, double> op = null;

				if(tokenizer.CurrentToken == Token.Add)
				{
					op = (a, b) => a + b;
				}else if(tokenizer.CurrentToken == Token.Subtract)
				{
					op = (a, b) => a - b;
				}

				if (op == null)
					return lhs;

				tokenizer.NextToken();

				Node rhs = ParseMultiplyDivide();

				lhs = new BinaryNode(lhs, rhs, op);
			}
		}

		protected virtual Node ParseMultiplyDivide()
		{
			Node lhs = ParseUnary();

			while (true)
			{
				Func<double, double, double> op = null;
				if(tokenizer.CurrentToken == Token.Multiply)
				{
					op = (a, b) => a * b;
				}
				else if(tokenizer.CurrentToken == Token.Divide)
				{
					op = (a, b) => a / b;
				}

				if (op == null)
					return lhs;

				tokenizer.NextToken();

				Node rhs = ParseUnary();

				lhs = new BinaryNode(lhs, rhs, op);
			}
		}

		protected virtual Node ParseUnary()
		{
			while (true)
			{


				if (tokenizer.CurrentToken == Token.Add)
				{
					tokenizer.NextToken();
					continue;
				}

				if (tokenizer.CurrentToken == Token.Subtract)
				{
					tokenizer.NextToken();

					Node rhs = ParseUnary();

					return new UnaryNode(rhs, (a) => -a);
				}

				return ParsePower();
			}
		}

		protected virtual Node ParsePower()
		{
			Node lhs = ParseLeaf();

			while (true)
			{
				if(tokenizer.CurrentToken == Token.Power)
				{
					tokenizer.NextToken();

					Node rhs = ParseLeaf();

					lhs = new PowerNode(lhs, rhs);
				}
				else
				{
					return lhs;
				}
			}

		}

		protected virtual Node ParseLeaf()
		{
			if(tokenizer.CurrentToken == Token.Number)
			{
				Node node = new NodeNumber(tokenizer.CurrentNumber);
				tokenizer.NextToken();
				return node;
			}

			if(tokenizer.CurrentToken == Token.ParenOpen)
			{
				tokenizer.NextToken();

				Node node = ParseAddSubtract();

				if (tokenizer.CurrentToken != Token.ParenClose)
					throw new SyntaxException("Missing closing parenthesis");

				tokenizer.NextToken();

				return node;
			}

			//do something to indicate error in the future
			throw new SyntaxException($"Unexpected Token: {tokenizer.CurrentToken}");
		}
	}
}
