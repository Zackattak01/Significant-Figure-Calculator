using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class NodeNumber : Node
	{
		public NodeNumber(double number)
		{
			this.number = number;
		}

		double number;

		public override double Eval()
		{
			return number;
		}
	}
}
