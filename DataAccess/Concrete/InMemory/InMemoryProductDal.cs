﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // simulating a simple database for testin operations
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Cup", UnitPrice=15, UnitsInStock =15 },
                new Product{ProductId=1, CategoryId=2, ProductName="Camera", UnitPrice=500, UnitsInStock =3 },
                new Product{ProductId=1, CategoryId=2, ProductName="Cellphone", UnitPrice=1500, UnitsInStock =2 },
                new Product{ProductId=1, CategoryId=2, ProductName="Keyboard", UnitPrice=150, UnitsInStock =65 },
                new Product{ProductId=1, CategoryId=2, ProductName="Mouse", UnitPrice=85, UnitsInStock =1 },
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null; // reference for object to delete

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            // using LINQ:
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);


            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = null;
            // find the product
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}