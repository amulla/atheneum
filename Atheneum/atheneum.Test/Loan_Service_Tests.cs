using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using atheneum.Core;
using atheneum.Services;
using System.Collections.Generic;

namespace atheneum.Test
{
    [TestClass]
    public class Loan_Service_Tests
    {
        [TestMethod]
        public void Loan_One_Item_To_Member()
        {
            // Arrange
            LoanService _loanService = new LoanService();
            Item item = new Item { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), SectionId = Guid.NewGuid(), Code = "ADLTBOOKBROW0001", Title = "The Lost Symbol", Author = "Dan Brown", ISBN = "9780593054277", Status = ItemStatus.OnShelf };
            Member member = new Member { Id = Guid.NewGuid(), Code = "BROWN19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", Gender = "M", DOB = new DateTime(1979, 06,23), Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "alan.shearer@atheneum.com", Mobile = "09868390914", Telephone = "1927 9845983", MaxItems = 6, Loans = new List<Loan> { } };
            Loan loan = new Loan { Id = Guid.NewGuid() };

            // Act
            bool result = _loanService.Loan(item, member, loan);

            // Assert
            Assert.AreEqual(item.Id, loan.ItemId);
            Assert.AreEqual(member.Id, loan.MemberId);
            Assert.AreEqual(DateTime.Now.Date, loan.LoanDate);
            Assert.AreEqual(DateTime.Now.Date.AddDays(21), loan.DueDate);
            Assert.AreEqual(ItemStatus.OnLoan, item.Status);
            CollectionAssert.Contains(member.Loans, loan);
        }

        [TestMethod]
        public void Loan_One_Item_To_Member_If_Less_Than_MaxItems_Already_Loaned()
        {
            // Arrange
            LoanService _loanService = new LoanService();
            Item item = new Item { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), SectionId = Guid.NewGuid(), Code = "ADLTBOOKBROW0001", Title = "The Lost Symbol", Author = "Dan Brown", ISBN = "9780593054277", Status = ItemStatus.OnShelf };
            Member member = new Member { Id = Guid.NewGuid(), Code = "BROWN19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", Gender = "M", DOB = new DateTime(1979, 06, 23), Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "alan.shearer@atheneum.com", Mobile = "09868390914", Telephone = "1927 9845983", MaxItems = 6, Loans = new List<Loan> { } };
            Loan loan = new Loan { Id = Guid.NewGuid() };
            Loan loan2 = new Loan { Id = Guid.NewGuid() };
            Loan loan3 = new Loan { Id = Guid.NewGuid() };
            Loan loan4 = new Loan { Id = Guid.NewGuid() };
            Loan loan5 = new Loan { Id = Guid.NewGuid() };
            Loan loan6 = new Loan { Id = Guid.NewGuid() };
            member.Loans.Add(loan2);
            member.Loans.Add(loan3);
            member.Loans.Add(loan4);
            member.Loans.Add(loan5);
            member.Loans.Add(loan6);

            // Act
            bool result = _loanService.Loan(item, member, loan);

            // Assert
            Assert.AreEqual(item.Id, loan.ItemId);
            Assert.AreEqual(member.Id, loan.MemberId);
            Assert.AreEqual(DateTime.Now.Date, loan.LoanDate);
            Assert.AreEqual(DateTime.Now.Date.AddDays(21), loan.DueDate);
            Assert.AreEqual(ItemStatus.OnLoan, item.Status);
            CollectionAssert.Contains(member.Loans, loan);
            Assert.AreEqual(6, member.Loans.Count);
        }

        [TestMethod]
        public void Do_Not_Loan_Item_To_Member_If_MaxItems_Already_Loaned()
        {
            // Arrange
            LoanService _loanService = new LoanService();
            Item item = new Item { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), SectionId = Guid.NewGuid(), Code = "ADLTBOOKBROW0001", Title = "The Lost Symbol", Author = "Dan Brown", ISBN = "9780593054277", Status = ItemStatus.OnShelf };
            Member member = new Member { Id = Guid.NewGuid(), Code = "BROWN19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", Gender = "M", DOB = new DateTime(1979, 06, 23), Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "alan.shearer@atheneum.com", Mobile = "09868390914", Telephone = "1927 9845983", MaxItems = 6, Loans = new List<Loan> { } };
            Loan loan = new Loan { Id = Guid.NewGuid() };
            Loan loan2 = new Loan { Id = Guid.NewGuid() };
            Loan loan3 = new Loan { Id = Guid.NewGuid() };
            Loan loan4 = new Loan { Id = Guid.NewGuid() };
            Loan loan5 = new Loan { Id = Guid.NewGuid() };
            Loan loan6 = new Loan { Id = Guid.NewGuid() };
            Loan loan7 = new Loan { Id = Guid.NewGuid() };
            member.Loans.Add(loan2);
            member.Loans.Add(loan3);
            member.Loans.Add(loan4);
            member.Loans.Add(loan5);
            member.Loans.Add(loan6);
            member.Loans.Add(loan7);

            // Act
            bool result = _loanService.Loan(item, member, loan);

            // Assert
            Assert.AreEqual(ItemStatus.OnShelf, item.Status);
            CollectionAssert.DoesNotContain(member.Loans, loan);
            Assert.AreEqual(6, member.Loans.Count);
        }

        [TestMethod]
        public void Return_One_Item_To_Libary_Catalogue()
        {
            // Arrange
            LoanService _loanService = new LoanService();
            Item item = new Item { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), SectionId = Guid.NewGuid(), Code = "ADLTBOOKBROW0001", Title = "The Lost Symbol", Author = "Dan Brown", ISBN = "9780593054277", Status = ItemStatus.OnLoan };
            Item item2 = new Item { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), SectionId = Guid.NewGuid(), Code = "ADLTBOOKBROW0002", Title = "The DaVinci Code", Author = "Dan Brown", ISBN = "9780593054278", Status = ItemStatus.OnLoan };
            Item item3 = new Item { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), SectionId = Guid.NewGuid(), Code = "ADLTBOOKBROW0003", Title = "Origin", Author = "Dan Brown", ISBN = "9780593054279", Status = ItemStatus.OnLoan };
            Member member = new Member { Id = Guid.NewGuid(), Code = "BROWN19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", Gender = "M", DOB = new DateTime(1979, 06, 23), Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "alan.shearer@atheneum.com", Mobile = "09868390914", Telephone = "1927 9845983", MaxItems = 6, Loans = new List<Loan> { } };
            Loan loan = new Loan { Id = Guid.NewGuid(), ItemId = item.Id, MemberId = member.Id, LoanDate = DateTime.Now.Date.AddDays(-7), DueDate = DateTime.Now.Date.AddDays(7)};
            Loan loan2 = new Loan { Id = Guid.NewGuid(), ItemId = item2.Id, MemberId = member.Id, LoanDate = DateTime.Now.Date.AddDays(-7), DueDate = DateTime.Now.Date.AddDays(7) };
            Loan loan3 = new Loan { Id = Guid.NewGuid(), ItemId = item3.Id, MemberId = member.Id, LoanDate = DateTime.Now.Date.AddDays(-7), DueDate = DateTime.Now.Date.AddDays(7) };
            member.Loans.Add(loan);
            member.Loans.Add(loan2);
            member.Loans.Add(loan3);

            // Act
            bool result = _loanService.Return(item, member);

            // Assert
            CollectionAssert.DoesNotContain(member.Loans, loan);
            Assert.AreEqual(2, member.Loans.Count);
            Assert.AreEqual(ItemStatus.OnShelf, item.Status);
        }
    }
}
