using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //InMemory bellekte yazılacak veri erişim kodları demek
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        //ctor, bellekte referans aldığı zaman çalışacak kod bloğudur
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 10, UnitsInStock = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 }
            };
        }

        public void Add(Product product)
        {
           _products.Add(product);
        }

        public void Delete(Product product)
        {
             _products.Remove(_products.SingleOrDefault(p=>p.ProductId==product.ProductId));
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products.ToList();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
           Product productToUpdate = _products.SingleOrDefault(_ => _.ProductId==product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice; 
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
