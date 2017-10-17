using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public abstract class AbstractLineItem
    {
        private bool _expected = true;
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        public bool Expected
        {
            get
            {
                return _expected;
            }
            set
            {
                _expected = value;
            }
        }
    }
}
