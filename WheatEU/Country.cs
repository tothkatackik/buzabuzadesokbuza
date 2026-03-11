using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheatEU
{
    internal class Country
    {
        private string name;
        private Dictionary<int, string> wheatAmount;

        public Country(string name, Dictionary<int, string> wheatAmount)
        {
            this.name = name;
            this.wheatAmount = wheatAmount;
        }
    }
}
