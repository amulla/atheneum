using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using atheneum.Core;
using atheneum.Services;
using System.Collections.Generic;

namespace atheneum.Test
{
    [TestClass]
    public class Category_Service_Tests
    {
        [TestMethod]
        public void Can_Create_A_Category()
        {
            // Arrange
            CategoryService _categoryService = new CategoryService();
            List<Category> categories = new List<Category>();
            Guid _id = Guid.NewGuid();
            Category category = new Category { Id = _id, Code = "BOOK", Name = "Books", Description = "Books" };

            // Act
            bool result = _categoryService.Add(category, categories);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Can_Create_A_Category_With_Unique_Guid()
        {
            // Arrange
            CategoryService _categoryService = new CategoryService();
            List<Category> categories = new List<Category>();
            Guid book_guid = Guid.NewGuid();
            Guid dvd_guid = Guid.NewGuid();
            Guid magazine_guid = Guid.NewGuid();

            Category book_category = new Category { Id = book_guid, Code = "BOOK", Name = "Books", Description = "Books" };
            Category dvd_category = new Category { Id = dvd_guid, Code = "DVD", Name = "DVDs", Description = "DVDs" };
            Category magazine_category = new Category { Id = magazine_guid, Code = "DVD", Name = "Magazines", Description = "Magazines" };

            // Act
            bool book_result = _categoryService.Add(book_category, categories);
            bool dvd_result = _categoryService.Add(dvd_category, categories);
            bool magazine_result = _categoryService.Add(magazine_category, categories);

            // Assert
            Assert.AreEqual(true, book_result);
            Assert.AreEqual(true, dvd_result);
            Assert.AreEqual(false, magazine_result);
            Assert.AreEqual(2, categories.Count);
        }
    }
}
