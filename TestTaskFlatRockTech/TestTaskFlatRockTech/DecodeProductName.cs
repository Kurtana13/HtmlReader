using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFlatRockTech
{
    public class DecodeProductName
    {
        public static string Decode(string productName)
        {
            return System.Web.HttpUtility.HtmlDecode(productName);
        }
    }
}
