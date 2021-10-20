using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EY4J5D_HFT_2021221.Logic
{
    public class AveragesResult
    {
        public string Brand { get; set; }
        public double Average { get; set; }

        public override string ToString()
        {
            return $"BRAND = {Brand}, AVG = {Average}";
        }

        public override bool Equals(object obj)
        {
            if (obj is AveragesResult)
            {
                AveragesResult other = obj as AveragesResult;
                return this.Brand == other.Brand && this.Average == other.Average;
            }
            else return false;
        }
    }
}
