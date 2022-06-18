using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    internal class Dairy_product : Product
    {
        private DateTime useBefore;

        public DateTime UseBefore
        {
            get => useBefore;
            private set
            {
                if (value < DateTime.Now) throw new ArgumentOutOfRangeException("Use before is a future date");
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
        public override string ToString()
        {
            string res = base.ToString();
            return String.Format("{0}, вжити до: {1}", res, UseBefore.ToShortDateString());
        }
        public override bool Equals(object obj)
        {
            Dairy_product product = obj as Dairy_product;
            if (product == null) return false;
            if (!base.Equals(product)) return false;
            return UseBefore == product.UseBefore;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
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
    }
}
