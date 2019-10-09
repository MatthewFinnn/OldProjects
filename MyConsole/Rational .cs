using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsole
{
	public class Rational
	{
		int n, d;			// Numerator, Denominator
		public static readonly Rational Zero, One;

		static Rational()		// Закрытый статический конструктор (он необходим для инициализации статических полей)
		{
			Zero = new Rational();
			One = new Rational();
			One.n = 1;
		}

		Rational() { n = 0; d = 1; }	// Закрытый default-конструктор (он вызывается при создания констант Zero и One)

		public Rational(int a, int b)
		{
			if (b == 0)
			{
				n = int.MaxValue;
				d = 1;
				return;
			}
			if (b < 0)
			{
				a = -a;
				b = -b;
			}
			int g = Gcd(a, b);
			n = a / g;
			d = b / g;
		}

		int Gcd(int a, int b)
		{
			int t = 0;
			a = Math.Abs(a); b = Math.Abs(b);
			if (b > a)
			{
				t = a; a = b; b = t;
			}
			while (b != 0) { t = a % b; a = b; b = t; } 
			return a;
		}

		public override string ToString()
		{
			return n == int.MaxValue ? "Infinity" : n.ToString() + "/" + d.ToString();
		}

		public void Print(string title) { Console.WriteLine(title + " = " + ToString()); }

		public static Rational operator+ (Rational p, Rational q) { return new Rational(p.n * q.d + q.n * p.d, p.d * q.d); }
		public static Rational operator -(Rational p, Rational q) { return new Rational(p.n * q.d - q.n * p.d, p.d * q.d); }
		public static Rational operator *(Rational p, Rational q) { return new Rational(p.n * q.n, p.d * q.d); }
		public static Rational operator /(Rational p, Rational q) { return new Rational(p.n * q.d, p.d * q.n); }
		public static bool operator ==(Rational p, Rational q) { return p.n == q.n && p.d == q.d; }
		public static bool operator !=(Rational p, Rational q) { return p.n != q.n || p.d != q.d; }
		public static bool operator <(Rational p, Rational q) { return p.n * q.d < p.d * q.n; }
		public static bool operator >(Rational p, Rational q) { return p.n * q.d > p.d * q.n; }
		public static bool operator <(Rational p, double d) { return (double)p.n / p.d < d; }
		public static bool operator >(Rational p, double d) { return (double)p.n / p.d > d; }
	}
}
