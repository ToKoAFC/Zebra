﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.CoreModels;
using Zebra.Database.Models;

namespace Zebra.Database.Access
{
    public class ProductAccess
    {
        private readonly ZebraContext _context;
        public ProductAccess(ZebraContext context)
        {
            _context = context;
        }

        public List<CoreProduct> GetCoreProduct()
        {
            return _context.Products
                .Select(prod => new CoreProduct
                {
                    Name = prod.Name,
                    Description = prod.Description,
                    ProuductId = prod.ProuductId,
                    BasePrice = prod.BasePrice,
                    Categories = prod.Categories.Select(cat => new CoreCategory
                    {
                        CategoryId = cat.CategoryId,
                        CategoryName = cat.Name
                    }).ToList()
                })
                .ToList();
        }

        public CoreProduct GetProduct(int produtId)
        {
            var product = _context.Products
                .Where(p => p.ProuductId == produtId)
                .Select(prod => new CoreProduct
                {
                    Name = prod.Name,
                    Description = prod.Description,
                    ProuductId = prod.ProuductId,
                    BasePrice = prod.BasePrice
                })
                .FirstOrDefault();
            return product;
        }

        public List<CoreProduct> GetProducts()
        {
            var products = _context.Products
                .Select(prod => new CoreProduct
                {
                    Name = prod.Name,
                    Description = prod.Description,
                    ProuductId = prod.ProuductId,
                    BasePrice = prod.BasePrice
                })
                .ToList();
            return products;
        }

        public void SaveProduct(CoreProduct product, int? companyId)
        {
            var dbProduct = _context.Products.Where(p => p.ProuductId == product.ProuductId).FirstOrDefault();
            if (dbProduct != null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.BasePrice = product.BasePrice;
                _context.SaveChanges();
                return;
            }
            _context.Products.Add(new DbProduct
            {
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                ProductPrices = new List<DbProductPrice>
                {
                    new DbProductPrice
                    {
                        CreatedDate = DateTime.Now,
                        Value = product.BasePrice
                    }
                },
                CompanyId = companyId ?? 0
            });
            _context.SaveChanges();
        }

        public bool DeleteProduct(int productId)
        {
            var dbProduct = _context.Products.Where(p => p.ProuductId == productId).FirstOrDefault();
            if (dbProduct == null)
            {
                return false;
            }
            try
            {
                _context.Products.Remove(dbProduct);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
