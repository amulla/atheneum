using System;
using System.Collections.Generic;
using System.Text;
using atheneum.Core;

namespace atheneum.Services
{
    public interface IItemService
    {
        bool Add(Item item, List<Item> items);
        bool Update(Guid guid, Item item, List<Item> items);
        bool Delete(Guid guid, List<Item> items);
    }
    public class ItemService : IItemService
    {
        public bool Add(Item item, List<Item> items)
        {
            bool return_value = false;

            if (items.Find(s => s.Id == item.Id) == null && items.Find(s => s.Code == item.Code) == null)
            {
                items.Add(item);
                return_value = true;
            }

            return return_value;
        }

        public bool Update(Guid guid, Item item, List<Item> items)
        {
            bool return_value = false;

            int index = items.FindIndex(i => i.Id == guid);

            if (index >= 0)
            {
                items[index].Code = item.Code;
                items[index].Title = item.Title;
                items[index].Author = item.Author;
                items[index].ISBN = item.ISBN;
                items[index].Status = item.Status;
                return true;
            }

            return return_value;
        }

        public bool Delete(Guid guid, List<Item> items)
        {
            bool return_value = false;

            var removeItem = items.Find(s => s.Id == guid);

            if (removeItem != null)
            {
                items.Remove(removeItem);
                return_value = true;
            }

            return return_value;
        }
    }
}
