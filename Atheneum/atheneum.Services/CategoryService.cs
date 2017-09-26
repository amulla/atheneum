using System;
using System.Collections.Generic;
using System.Text;
using atheneum.Core;

namespace atheneum.Services
{
    public interface ICategoryService
    {
        bool Add(Category category, List<Category> categories);
        bool Update(Guid guid, Category category, List<Category> categories);
        bool Delete(Guid guid, List<Category> categories);
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

        public bool Update(Guid guid, Category category, List<Category> categories)
        {
            bool return_value = true;

            int index = categories.FindIndex(s => s.Id == guid);

            if (index >= 0)
            {
                categories[index].Name = category.Name;
                categories[index].Description = category.Description;
                return true;
            }

            return return_value;
        }

        public bool Delete(Guid guid, List<Category> categories)
        {
            bool return_value = true;

            var removeCategory = categories.Find(s => s.Id == guid);

            if (removeCategory != null)
            {
                categories.Remove(removeCategory);
                return_value = true;
            }

            return return_value;
        }
    }
}
