using System;

namespace Budget.Models
{
    public class LineItem
    {
        private bool? _expected;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
        public bool? Expected
        {
            get
            {
                return _expected.HasValue && _expected.Value;
            }
            set
            {
                _expected = value ?? true;
            }
        }
    }
}
