using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var multipliers = Enumerable.Range(0, max);     

        return multipliers.Where(x => multiples.Any(y => (y > 0) && (x % y == 0))).Sum();
    }
}