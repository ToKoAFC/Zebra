using System;
using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Database.Models;

namespace Zebra.Database.Access
{
    public class CategoryAccess : ICategoryAccess
    {
        private readonly ZebraContext _context;
        public CategoryAccess(ZebraContext context)
        {
            _context = context;
        }

        public List<CoreCategory> GetCoreCategories()
        {
            return _context.Categories
                .Select(cat => new CoreCategory
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.Name
                })
                .ToList();
        }

        public void AddNewCategory(string categoryName, int? categoryId)
        {
            _context.Categories.Add(new DbCategory
            {
                Name = categoryName
            });
            _context.SaveChanges();
        }

        public CoreCategory GetCategory(int categoryId)
        {
            return _context.Categories
                    .Where(x => x.CategoryId == categoryId)
                    .Select(x => new CoreCategory
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.Name
                    })
                    .FirstOrDefault();
        }

        public void SaveCategory(CoreCategory category)
        {
            var dbCategory = _context.Categories
                            .Where(p => p.CategoryId == category.CategoryId)
                            .FirstOrDefault();
            if (dbCategory != null)
            {
                dbCategory.Name = category.CategoryName;
                _context.SaveChanges();
                return;
            }
            _context.Categories.Add(new DbCategory
            {
                Name = category.CategoryName
            });
            _context.SaveChanges();
        }

        public bool DeleteCategory(int categoryId)
        {
            var dbCategory = _context.Categories
                                .Where(p => p.CategoryId == categoryId)
                                .FirstOrDefault();
            if (dbCategory == null)
            {
                return false;
            }
            try
            {
                _context.Categories.Remove(dbCategory);
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
