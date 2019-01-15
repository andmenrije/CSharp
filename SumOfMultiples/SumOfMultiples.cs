using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(0, max).Where(x => multiples.Any(y => (y > 0) && (x % y == 0))).Sum();
    }
}