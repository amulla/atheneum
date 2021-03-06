﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using atheneum.Core;
using atheneum.Services;
using System.Collections.Generic;

namespace atheneum.Test
{
    [TestClass]
    public class Section_Service_Tests
    {
        [TestMethod]
        public void Create_A_Section()
        {
            // Arrange
            SectionService _sectionService = new SectionService();
            List<Section> sections = new List<Section>();
            Guid _id = Guid.NewGuid();
            Section section = new Section { Id = _id, Code = "CHLD", Name = "Children", Description = "Children Aged 0-12" };

            // Act
            bool result = _sectionService.Add(section, sections);

            // Assert
            Assert.AreEqual(true, result);
        }

        
        [TestMethod]
        public void Create_A_Section_With_Unique_Guid()
        {
            // Arrange
            SectionService _sectionService = new SectionService();
            List<Section> sections = new List<Section>();
            Guid guid = Guid.NewGuid();
            Section childrens_section = new Section { Id = guid, Code = "CHLD", Name = "Children", Description = "Children Aged 0-12" };
            Section teens_section = new Section { Id = guid, Code = "TEEN", Name = "Teenage", Description = "Children Aged 13-15" };

            // Act
            bool childrens_result = _sectionService.Add(childrens_section, sections);
            bool teens_result = _sectionService.Add(teens_section, sections);

            // Assert
            Assert.AreEqual(true, childrens_result);
            Assert.AreEqual(false, teens_result);
        }

        [TestMethod]
        public void Create_A_Section_With_Unique_Code()
        {
            // Arrange
            SectionService _sectionService = new SectionService();
            List<Section> sections = new List<Section>();
            Guid childrens_guid = Guid.NewGuid();
            Guid teens_guid = Guid.NewGuid();
            Guid adults_guid = Guid.NewGuid();

            Section childrens_section = new Section { Id = childrens_guid, Code = "CHLD", Name = "Children", Description = "Children Aged 0-12" };
            Section teens_section = new Section { Id = teens_guid, Code = "CHLD", Name = "Teenage", Description = "Children Aged 13-15" };
            Section adults_section = new Section { Id = adults_guid, Code = "ADLT", Name = "Adult", Description = "Adults Aged 16+" };

            // Act
            bool childrens_result = _sectionService.Add(childrens_section, sections);
            bool teens_result = _sectionService.Add(teens_section, sections);
            bool adults_result = _sectionService.Add(adults_section, sections);

            // Assert
            Assert.AreEqual(true, childrens_result);
            Assert.AreEqual(false, teens_result);
            Assert.AreEqual(true, adults_result);
            Assert.AreEqual(2, sections.Count);
        }

        [TestMethod]
        public void Amend_A_Section_Name()
        {
            // Arrange
            SectionService _sectionService = new SectionService();
            List<Section> sections = new List<Section>();
            Guid guid = Guid.NewGuid();

            Section section = new Section { Id = guid, Code = "TEEN", Name = "Teenage", Description = "Children Aged 13-15" };
            _sectionService.Add(section, sections);
            section.Name = "Young Adult";

            // Act
            bool childrens_result = _sectionService.Update(guid, section, sections);

            // Assert
            Section assert_section = sections.Find(s => s.Id == guid);
            Assert.AreEqual("Young Adult", assert_section.Name);
        }

        [TestMethod]
        public void Amend_A_Section_Description()
        {
            // Arrange
            SectionService _sectionService = new SectionService();
            List<Section> sections = new List<Section>();
            Guid guid = Guid.NewGuid();

            Section section = new Section { Id = guid, Code = "TEEN", Name = "Teenage", Description = "Children Aged 13-15" };
            _sectionService.Add(section, sections);
            section.Description = "Young Adults Aged 13-15";

            // Act
            bool childrens_result = _sectionService.Update(guid, section, sections);

            // Assert
            Section assert_section = sections.Find(s => s.Id == guid);
            Assert.AreEqual("Young Adults Aged 13-15", assert_section.Description);
        }

        [TestMethod]
        public void Delete_A_Section()
        {
            // Arrange
            SectionService _sectionService = new SectionService();
            List<Section> sections = new List<Section>();
            Guid childrens_guid = Guid.NewGuid();
            Guid teens_guid = Guid.NewGuid();
            Guid adults_guid = Guid.NewGuid();

            Section childrens_section = new Section { Id = childrens_guid, Code = "CHLD", Name = "Children", Description = "Children Aged 0-12" };
            Section teens_section = new Section { Id = teens_guid, Code = "TEEN", Name = "Teenage", Description = "Children Aged 13-15" };
            Section adults_section = new Section { Id = adults_guid, Code = "ADLT", Name = "Adult", Description = "Adults Aged 16+" };

            _sectionService.Add(childrens_section, sections);
            _sectionService.Add(teens_section, sections);
            _sectionService.Add(adults_section, sections);

            // Act
            bool result = _sectionService.Delete(adults_guid, sections);

            // Assert
            Assert.AreEqual(2, sections.Count);
            CollectionAssert.DoesNotContain(sections, adults_section);
        }
    }
}
