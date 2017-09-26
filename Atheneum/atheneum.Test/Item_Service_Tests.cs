using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using atheneum.Core;
using atheneum.Services;
using System.Collections.Generic;

namespace atheneum.Test
{
    [TestClass]
    public class Item_Service_Tests
    {
        [TestMethod]
        public void Create_An_Item()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid _id = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item item = new Item { Id = _id, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };

            // Act
            bool result = _itemService.Add(item, items);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Create_An_Item_With_A_Unique_Guid()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid _id = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = _id, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = _id, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0002", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };

            // Act
            bool book1_result = _itemService.Add(book1, items);
            bool book2_result = _itemService.Add(book2, items);

            // Assert
            Assert.AreEqual(true, book1_result);
            Assert.AreEqual(false, book2_result);
            Assert.AreEqual(1, items.Count);
        }

        [TestMethod]
        public void Create_An_Item_With_A_Unique_Code()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid book1_guid = Guid.NewGuid();
            Guid book2_guid = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = book1_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = book2_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };

            // Act
            bool book1_result = _itemService.Add(book1, items);
            bool book2_result = _itemService.Add(book2, items);

            // Assert
            Assert.AreEqual(true, book1_result);
            Assert.AreEqual(false, book2_result);
            Assert.AreEqual(1, items.Count);
        }

        [TestMethod]
        public void Amend_An_Item_Code()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid book1_guid = Guid.NewGuid();
            Guid book2_guid = Guid.NewGuid();
            Guid book3_guid = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = book1_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = book2_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0002", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book3 = new Item { Id = book3_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0003", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };

            _itemService.Add(book1, items);
            book1.Code = "ADLTBOOKBROW0099";

            // Act
            bool result = _itemService.Update(book1_guid, book1, items);

            // Assert
            Item updated_item = items.Find(i => i.Id == book1_guid);
            Assert.AreEqual("ADLTBOOKBROW0099", updated_item.Code);
        }

        [TestMethod]
        public void Amend_An_Item_Title()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid book1_guid = Guid.NewGuid();
            Guid book2_guid = Guid.NewGuid();
            Guid book3_guid = Guid.NewGuid();
            Guid book4_guid = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = book1_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = book2_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0002", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book3 = new Item { Id = book3_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0003", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book4 = new Item { Id = book4_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0004", Author = "Dan Brown", Title = "The Lost Symbol Large Font", ISBN = "9780593054277" };

            _itemService.Add(book1, items);
            _itemService.Add(book2, items);
            _itemService.Add(book3, items);

            // Act
            bool result = _itemService.Update(book1_guid, book4, items);

            // Assert
            Item updated_item = items.Find(i => i.Id == book1_guid);
            Assert.AreEqual("The Lost Symbol Large Font", updated_item.Title);
        }

        [TestMethod]
        public void Amend_An_Item_Author()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid book1_guid = Guid.NewGuid();
            Guid book2_guid = Guid.NewGuid();
            Guid book3_guid = Guid.NewGuid();
            Guid book4_guid = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = book1_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = book2_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0002", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book3 = new Item { Id = book3_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0003", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book4 = new Item { Id = book4_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0004", Author = "Daniel Brown", Title = "The Lost Symbol Large Font", ISBN = "9780593054277" };

            _itemService.Add(book1, items);
            _itemService.Add(book2, items);
            _itemService.Add(book3, items);

            // Act
            bool result = _itemService.Update(book1_guid, book4, items);

            // Assert
            Item updated_item = items.Find(i => i.Id == book1_guid);
            Assert.AreEqual("Daniel Brown", updated_item.Author);
        }

        [TestMethod]
        public void Amend_An_Item_ISBN()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid book1_guid = Guid.NewGuid();
            Guid book2_guid = Guid.NewGuid();
            Guid book3_guid = Guid.NewGuid();
            Guid book4_guid = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = book1_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = book2_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0002", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book3 = new Item { Id = book3_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0003", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book4 = new Item { Id = book4_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0004", Author = "Daniel Brown", Title = "The Lost Symbol Large Font", ISBN = "9780593054278" };

            _itemService.Add(book1, items);
            _itemService.Add(book2, items);
            _itemService.Add(book3, items);

            // Act
            bool result = _itemService.Update(book1_guid, book4, items);

            // Assert
            Item updated_item = items.Find(i => i.Id == book1_guid);
            Assert.AreEqual("9780593054278", updated_item.ISBN);
        }

        [TestMethod]
        public void Delete_An_Item()
        {
            // Arrange
            ItemService _itemService = new ItemService();
            List<Item> items = new List<Item>();
            Guid book1_guid = Guid.NewGuid();
            Guid book2_guid = Guid.NewGuid();
            Guid book3_guid = Guid.NewGuid();
            Guid book4_guid = Guid.NewGuid();
            Guid section_guid = Guid.NewGuid();
            Guid category_guid = Guid.NewGuid();
            Item book1 = new Item { Id = book1_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0001", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book2 = new Item { Id = book2_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0002", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book3 = new Item { Id = book3_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0003", Author = "Dan Brown", Title = "The Lost Symbol", ISBN = "9780593054277" };
            Item book4 = new Item { Id = book4_guid, SectionId = section_guid, CategoryId = category_guid, Code = "ADLTBOOKBROW0004", Author = "Daniel Brown", Title = "The Lost Symbol Large Font", ISBN = "9780593054278" };

            _itemService.Add(book1, items);
            _itemService.Add(book2, items);
            _itemService.Add(book3, items);
            _itemService.Add(book4, items);

            // Act
            bool result = _itemService.Delete(book1_guid, items);

            // Assert
            Assert.AreEqual(3, items.Count);
            CollectionAssert.DoesNotContain(items, book1);
        }
    }
}
