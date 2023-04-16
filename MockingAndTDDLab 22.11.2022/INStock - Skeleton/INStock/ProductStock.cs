using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly Dictionary<int,IProduct> products;
        public ProductStock()
        {
            products = new Dictionary<int, IProduct>();
        }

        public IProduct this[int index]
        {
            get 
            {
                if (index>=Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return products[index]; 
            }
            set 
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                products[index] = value; 
            }
        }

        public int Count
        {
            get { return products.Count; }
        }

        public void Add(IProduct product)
        {
            products.Add(Count, product);
        }

        public bool Contains(IProduct product)
        {
            return products.Any(p => p.Value.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index>=Count)
            {
                throw new IndexOutOfRangeException();
            }
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
