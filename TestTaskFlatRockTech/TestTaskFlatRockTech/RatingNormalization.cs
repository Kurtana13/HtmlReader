using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFlatRockTech
{
    public class RatingNormalization
    {
        public static string Normalize(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal parsedRating))
            {
                if(parsedRating > 5)
                {
                    decimal normalizedRating = parsedRating / 10.0m * 5.0m;
                    return Math.Round(normalizedRating,1).ToString().Replace(",", ".");
                }
            }
            return parsedRating.ToString().Replace(",", ".");
        }
    }
}
