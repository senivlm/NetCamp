using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Buy
    {
        private Product product;
        private int count;

        public Product Product { get => product; set => product = value; }
        public int Count { get => count;
            set
            {
                if(value < 0) throw new ArgumentOutOfRangeException();
                count = value; }
        }
        public double Summ
        {
            get
            { return product.Price * count; }
        }
        public double FullWeight
        {
            get
            { return product.Weight * count; }
        }
        public Buy() : this(new Product(), 0)
        {        }
        public Buy(Product product, int count)
        {
            if (product == null) throw new ArgumentNullException();
            this.product = product;
            Count = count;
        }
        public override string ToString()
        {
            return $"Назва товару - {Product.Name}, кiлькiсть - {Count}, сума - {Summ:F2}, загальна вага - {FullWeight}";
        }
    }
}
