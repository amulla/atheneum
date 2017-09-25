using System;
using System.Collections.Generic;
using System.Text;
using atheneum.Core;

namespace atheneum.Services
{
    public interface ICategoryService
    {
        bool Add(Category section, List<Category> sections);
    }
    public class CategoryService : ICategoryService
    {
        public bool Add(Category category, List<Category> categories)
        {
            bool return_value = true;

            if (categories.Find(s => s.Id == category.Id) == null && categories.Find(s => s.Code == category.Code) == null)
            {
                categories.Add(category);
            }
            else
            {
                return_value = false;
            }

            return return_value;
        }
    }
}
