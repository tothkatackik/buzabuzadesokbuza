using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheatEU
{
    public class Country
    {
        private string name;
        private Dictionary<int, string> wheatAmount;

        public Country(string name, Dictionary<int, string> wheatAmount)
        {
            this.name = name;
            this.wheatAmount = wheatAmount;
        }

        public string Name { get => name; }
        public Dictionary<int, string> WheatAmount { get => new Dictionary<int, string>(wheatAmount); }

        public string ToString(int n)
        {
            return wheatAmount[n];
        }
    }
}
