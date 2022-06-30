using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    internal enum Category { hiestSort, firstSort, secondSort }
    internal enum Kind { mutton, veal, pork, chicken }
    internal class Meat : Dairy_product
    {
        private Category category;
        private Kind kind;

        public Category Category { get => category; private set => category = value; }
        public Kind Kind { get => kind; private set => kind = value; }
        public Meat(string name, double price, double weight, DateTime useBefore, Category category, Kind kind) :
            base(name, price, weight, useBefore)
        {
            Category = category;
            Kind = kind;
        }
        public Meat(string name, double price, double weight, string useBefore, string categoryStr, string kindStr) :
            base(name, price, weight, useBefore)
        {
            if (!Enum.TryParse(categoryStr, out Category category)) throw new ArgumentException("Category");
            if (!Enum.TryParse(kindStr, out Kind kind)) throw new ArgumentException("Kind");
            Category = category;
            Kind = kind;
        }
        public Meat(string name, string price, string weight, string useBefore, string categoryStr, string kindStr) :
             base(name, price, weight, useBefore)
        {
            if (!Enum.TryParse(categoryStr, out Category category)) throw new ArgumentException("Category");
            if (!Enum.TryParse(kindStr, out Kind kind)) throw new ArgumentException("Kind");
            Category = category;
            Kind = kind;
        }
        public override string ToString()
        {
            return String.Format("{0}, категорiя: {1}, вид: {2}", base.ToString(), Kind, Category);
        }
        public override bool Equals(object obj)
        {
            Meat meat = obj as Meat;
            if (meat == null) return false;
            if (!base.Equals(meat)) return false;
            return this.Category == meat.Category && this.Kind == meat.Kind;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Weight,UseBefore, Category, Kind);
        }
        public override void IncreasePrice(int percent)
        {
            percent += Settings.AdditionalSortsPersons[Category];
            base.IncreasePrice(percent);
        }
        public override string ToFileString()
        {
            return $"Meat_{base.ToFileString().Substring(8)}_{Category}_{Kind}";
        }
        public override Meat Clone()
        {
            return new Meat(Name, Price, Weight,UseBefore, Category, Kind);
        }
        public override bool Seach(string search)
        {
            if (!string.IsNullOrWhiteSpace(search) && search.Length >= Settings.MinSearchSymbols)
            {
                if (Category.ToString().Contains(search) || Kind.ToString().Contains(search)) return true;
            }
            return base.Seach(search);
        }
    }
}
