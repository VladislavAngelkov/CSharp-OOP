using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; set; }

        public decimal Price => throw new NotImplementedException();

        public int Quantity => throw new NotImplementedException();

        public int CompareTo([AllowNull] IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
