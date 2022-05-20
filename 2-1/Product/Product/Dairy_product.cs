using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Dairy_product : Product
    {
        private DateTime useBefore;

        public DateTime UseBefore
        {
            get => useBefore; private set
            {
                useBefore = value;
            }
        }
        public Dairy_product(string name, double price, double weight, DateTime useBefore) :
            base(name, price, weight)
        {
            UseBefore = useBefore;
        }
        public Dairy_product(string name, double price, double weight, string useBeforeStr) :
            base(name, price, weight)
        {
            if (!DateTime.TryParse(useBeforeStr, out DateTime useBefore)) throw new ArgumentException("UseBefore");
            UseBefore = useBefore;
        }
        public Dairy_product() : base()
        {
            UseBefore = new DateTime(2000, 1, 1);
        }
        public override void IncreasePrice(int percent)
        {
            if ((UseBefore - DateTime.Now).Days < 5)
            {
                percent -= 3;
            }
            else if ((UseBefore - DateTime.Now).Days > 2)
            {
                percent -= 20;
            }
            base.IncreasePrice(percent);
        }
        public override string ToString()
        {
            string res = base.ToString();
            return String.Format("{0}, вжити до: ",res,UseBefore.ToShortDateString());
        }
    }
}
