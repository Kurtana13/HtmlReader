using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFlatRockTech
{
    public class RemoveCurrency
    {
        public static string Remove(string currency)
        {
            return currency.Trim('$').Replace(",","");
        }
    }
}
