using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal enum Category { hiestSort, firstSort, secondSort }
    internal enum Kind { mutton, veal, pork, chicken }
    internal class Meat : Product
    {
        private Category category;
        private Kind kind;

        public Category Category { get => category; private set => category = value; }
        public Kind Kind { get => kind; private set => kind = value; }
        public Meat(string name, double price, double weight, Category category, Kind kind) :
            base(name, price, weight)
        {
            Category = category;
            Kind = kind;
        }
        public Meat(string name, double price, double weight, string categoryStr, string kindStr) :
            base(name, price, weight)
        {
            if (!Enum.TryParse(categoryStr, out Category category)) throw new ArgumentException("Category");
            if (!Enum.TryParse(kindStr, out Kind kind)) throw new ArgumentException("Kind");
            Category = category;
            Kind = kind;
        }
        public Meat(string name, string price, string weight, string categoryStr, string kindStr) :
            base(name, price, weight)
        {
            if (!Enum.TryParse(categoryStr, out Category category)) throw new ArgumentException("Category");
            if (!Enum.TryParse(kindStr, out Kind kind)) throw new ArgumentException("Kind");
            Category = category;
            Kind = kind;
        }
        public override void IncreasePrice(int percent)
        {
            switch (Category)
            {
                case Category.hiestSort:
                    percent += 15;
                    break;
                case Category.firstSort:
                    percent += 10;
                    break;
                case Category.secondSort:
                    percent += 5;
                    break;
            }
            base.IncreasePrice(percent);
        }
        public override string ToString()
        {
            return String.Format("Назва: {0}, ціна: {1:F2}, категорiя: {2}, вид: {3}", Name, Price,Category, Kind);
        }
    }
}
