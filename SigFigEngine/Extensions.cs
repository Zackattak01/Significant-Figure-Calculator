using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MathEngine.SigFig.Extensions
{
	public static class Extensions
	{
		public static int GetSigFigAmount(this string str)
		{
			bool startCount = false;
			int sigFigs = 0;

			if (str.Contains("."))
			{
				foreach (var c in str)
				{
					if (!startCount && c == '0')
						continue;

					if(c != '0' && c != '.' && !startCount)
					{
						startCount = true;
						sigFigs++;
					}else if (startCount && c != '.')
					{
						sigFigs++;
					}
				}
			}
			else
			{

				foreach (var c in str.Reverse())
				{
					if (!startCount && c == '0')
						continue;

					if(c != '0' && !startCount)
					{
						startCount = true;
						sigFigs++;
					}else if (startCount)
					{
						sigFigs++;
					}
				}
			}

			return sigFigs;
		}
		public static int GetSigFigAmount(this double d)
		{
			string str = d.ToString();
			bool startCount = false;
			int sigFigs = 0;

			if (str.Contains("."))
			{
				foreach (var c in str)
				{
					if (!startCount && c == '0')
						continue;

					if (c != '0' && c != '.' && !startCount)
					{
						startCount = true;
						sigFigs++;
					}
					else if (startCount && c != '.')
					{
						sigFigs++;
					}
				}
			}
			else
			{

				foreach (var c in str.Reverse())
				{
					if (!startCount && c == '0')
						continue;

					if (c != '0' && !startCount)
					{
						startCount = true;
						sigFigs++;
					}
					else if (startCount)
					{
						sigFigs++;
					}
				}
			}

			return sigFigs;
		}

		public static int GetSigFigAmountAfterDecimal(this string num)
		{
			if (num.Contains('.'))
			{
				return num.Split('.').Last().Length;
			}
			else
			{
				return 0;
			}
		}

		public static double RoundTo(this double num, double place)
		{
				return Math.Round(num / place, MidpointRounding.AwayFromZero) * place;
		}

		//This method will keep adding sig figs until the TOTAL amount of sig figs in the nubmer equals the number passed in (sigFigs)
		public static string AddExtraSigFigs(this string num, int sigFigs)
		{
			if (sigFigs == num.GetSigFigAmount())
				return num;

			if (!num.Contains('.'))
				num += '.';

			while(num.Length - 1 < sigFigs)
			{
				num += '0';
			}

			return num;
		}
	}
}
