using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(r.Expreal(realNumber), r.ExprealPow());
    }
}

public struct RationalNumber
{
    private int _numerator;
    private int _denominator;
    

    public RationalNumber(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public RationalNumber Add(RationalNumber r)
    {
        return new RationalNumber((_numerator * r._denominator) + (r._numerator * _denominator), 
                                  (_denominator * r._denominator)).Reduce();

    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return r1.Add(r2);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        return new RationalNumber((_numerator * r._denominator) - (r._numerator * _denominator),
                                  _denominator * r._denominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1.Sub(r2);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        return new RationalNumber(_numerator * r._numerator, _denominator * r._denominator).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return r1.Mul(r2);
    }

    public RationalNumber Div(RationalNumber r)
    {
        if ((_numerator * r._numerator) == 0)
            throw new DivideByZeroException("Cannot have 0 as denominator when dividing rational numbers");

        return new RationalNumber(_numerator * r._denominator, r._numerator * _denominator).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1.Div(r2);
    }

    public RationalNumber Abs()
    {
        /* can be done two ways */

        /* Using Math.Abs())*/
        /*
        return new RationalNumber( Math.Abs(_numerator), Math.Abs(_denominator) );
        */

        /* Manual way of getting absolute value */
        return new RationalNumber(_numerator < 0 ? -_numerator : _numerator, _denominator < 0 ? -_denominator : _denominator);
    }

    public RationalNumber Reduce()
    {
        //int gcd = _numerator > _denominator ? GreatestCommonDivisor(_numerator, _denominator) : GreatestCommonDivisor(_denominator, _numerator);
        int gcd = GreatestCommonDivisor(_numerator, _denominator);
        _numerator /= gcd;
        _denominator /= gcd;

        if(_denominator < 0)
        {
            _numerator = -_numerator;
            _denominator = -_denominator;
        }

        return this;
    }

    private int GreatestCommonDivisor(int a, int b)
    {
        if(b == 0)
        {
            return a;
        }
        else
        {
            return GreatestCommonDivisor(b, a % b);
        }
    }

    public RationalNumber Exprational(int power)
    {
        int newNumerator = 1;
        int newDenominator = 1;

        for(int i = 0; i < power; i++)
        {
            newNumerator *= _numerator;
            newDenominator *= _denominator;
        }

        return new RationalNumber(newNumerator, newDenominator).Reduce();
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow((double)baseNumber, (1.0 / _denominator));
    }

    public int ExprealPow()
    {
        return _numerator;
    }
}