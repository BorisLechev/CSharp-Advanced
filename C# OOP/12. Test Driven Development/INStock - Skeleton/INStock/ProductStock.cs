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
        private IProduct[] products;

        private const int INITIAL_SIZE = 4;

        public ProductStock()
        {
            this.products = new IProduct[INITIAL_SIZE];
        }

        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.products[index];
            }

            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.products[index] = value;   
            }
        }

        public int Count { get; set; }

        public int Capacity => this.products.Length;

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.products[i].CompareTo(product) == 0)
                {
                    this.products[i].Quantity += product.Quantity;
                    return;
                }
            }

            if (this.products.Length == this.Count)
            {
                this.Resize();
            }

            this.products[this.Count++] = product;
        }

        public bool Contains(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            return this.products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.products[index];
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
            if (string.IsNullOrEmpty(label) || string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentNullException();
            }

            IProduct product = null;

            foreach (IProduct currentProduct in this.products)
            {
                if (currentProduct != null && currentProduct.Label == label)
                {
                    product = currentProduct;
                    break;
                }
            }

            if (product == null)
            {
                throw new ArgumentNullException();
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            IProduct mostExpensiveProduct = this.products[0];

            for (int i = 1; i < this.Count; i++)
            {
                IProduct currentProduct = this.products[i];

                if (currentProduct.Price > mostExpensiveProduct.Price)
                {
                    mostExpensiveProduct = currentProduct;
                }
            }

            return mostExpensiveProduct;
        }

        public bool Remove(IProduct product)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (product == this.products[i])
                {
                    this.products[i] = null;

                    this.Reorder(i);

                    this.Count--;

                    if (this.Capacity / 2 == this.Count)
                    {
                        this.Shrink();
                    }

                    return true;
                }
            }

            return false;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            IProduct[] tempArray = new IProduct[this.Capacity * 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }

            this.products = tempArray;
        }

        private void Reorder(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.products[i] = this.products[i + 1];
            }
        }

        private void Shrink()
        {
            IProduct[] tempArray = new IProduct[this.Capacity / 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }

            this.products = tempArray;
        }
    }
}
