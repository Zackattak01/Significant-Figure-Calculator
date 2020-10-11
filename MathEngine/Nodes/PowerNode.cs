using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class PowerNode : Node
	{
		public PowerNode(Node lhs, Node rhs)
		{
			this.lhs = lhs;
			this.rhs = rhs;
		}

		Node lhs;
		Node rhs;

		public override double Eval()
		{
			return Math.Pow(lhs.Eval(), rhs.Eval());
		}
	}
}
