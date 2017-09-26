using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using atheneum.Core;
using atheneum.Services;
using System.Collections.Generic;

namespace atheneum.Test
{
    [TestClass]
    public class Member_Service_Tests
    {
        [TestMethod]
        public void Create_A_Member()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id = Guid.NewGuid();
            Member member = new Member { Id = _id, Code = "BROWN19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980,06,17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            // Act
            bool result = _memberService.Add(member, members);

            // Assert
            Assert.AreEqual(true, result);
            CollectionAssert.Contains(members, member);
        }

        [TestMethod]
        public void Create_An_Member_With_A_Unique_Guid()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id1, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            // Act
            bool member1_result = _memberService.Add(member1, members);
            bool member2_result = _memberService.Add(member2, members);
            bool member3_result = _memberService.Add(member3, members);

            // Assert
            Assert.AreEqual(true, member1_result);
            Assert.AreEqual(false, member2_result);
            Assert.AreEqual(true, member3_result);
            Assert.AreEqual(2, members.Count);
            CollectionAssert.DoesNotContain(members, member2);
        }

        [TestMethod]
        public void Create_An_Member_With_A_Unique_Code()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "BROWN19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            // Act
            bool member1_result = _memberService.Add(member1, members);
            bool member2_result = _memberService.Add(member2, members);
            bool member3_result = _memberService.Add(member3, members);

            // Assert
            Assert.AreEqual(true, member1_result);
            Assert.AreEqual(true, member2_result);
            Assert.AreEqual(false, member3_result);
            Assert.AreEqual(2, members.Count);
            CollectionAssert.DoesNotContain(members, member3);
        }

        [TestMethod]
        public void Amend_A_Member_Code()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            member1.Code = "BROWN19800617999";

            // Act
            bool result = _memberService.Update(_id1, member1, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("BROWN19800617999", updated_member.Code);
        }

        [TestMethod]
        public void Amend_A_Member_Title()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Sir", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("Sir", updated_member.Title);
        }

        [TestMethod]
        public void Amend_A_Member_Forename()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Mike", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("Mike", updated_member.Forename);
        }

        [TestMethod]
        public void Amend_A_Member_Surname()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Banks", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("Banks", updated_member.Surname);
        }

        [TestMethod]
        public void Amend_A_Member_DOB()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 21), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual(new DateTime(1980, 06, 21), updated_member.DOB);
        }

        [TestMethod]
        public void Amend_A_Member_Gender()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "X", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("X", updated_member.Gender);
        }

        [TestMethod]
        public void Amend_A_Member_Address()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 King Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("1 King Street", updated_member.Address);
        }

        [TestMethod]
        public void Amend_A_Member_City()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Sunderland", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("Sunderland", updated_member.City);
        }

        [TestMethod]
        public void Amend_A_Member_Postcode()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1NN", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("N1 1NN", updated_member.Postcode);
        }

        [TestMethod]
        public void Amend_A_Member_Email()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1NN", Email = "amemnded_email_address@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("amemnded_email_address@mydomain.com", updated_member.Email);
        }

        [TestMethod]
        public void Amend_A_Member_Telephone()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1NN", Email = "myself@mydomain.com", Telephone = "01298 123 9999", Mobile = "0781 7813 105", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("01298 123 9999", updated_member.Telephone);
        }

        [TestMethod]
        public void Amend_A_Member_Mobile()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1NN", Email = "myself@mydomain.com", Telephone = "01298 123 9999", Mobile = "0781 7813 999", MaxItems = 6 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual("0781 7813 999", updated_member.Mobile);
        }

        [TestMethod]
        public void Amend_A_Member_MaxItems()
        {
            // Arrange
            MemberService _memberService = new MemberService();
            List<Member> members = new List<Member>();
            Guid _id1 = Guid.NewGuid();
            Guid _id2 = Guid.NewGuid();
            Guid _id3 = Guid.NewGuid();
            Guid _id4 = Guid.NewGuid();
            Member member1 = new Member { Id = _id1, Code = "BROWN19800617001", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member2 = new Member { Id = _id2, Code = "SMITH19800617001", Title = "Mr", Forename = "Bob", Surname = "Smith", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "2 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member3 = new Member { Id = _id3, Code = "SHEAR19800617001", Title = "Mr", Forename = "Alan", Surname = "Shearer", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "3 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 6 };
            Member member4 = new Member { Id = _id4, Code = "BROWN19800617002", Title = "Mr", Forename = "Danny", Surname = "Brown", DOB = new DateTime(1980, 06, 17), Gender = "M", Address = "1 High Street", City = "Newcastle", Postcode = "N1 1AS", Email = "myself@mydomain.com", Telephone = "01298 123 9876", Mobile = "0781 7813 105", MaxItems = 9 };

            _memberService.Add(member1, members);
            _memberService.Add(member2, members);
            _memberService.Add(member3, members);

            // Act
            bool result = _memberService.Update(_id1, member4, members);

            // Assert
            Member updated_member = members.Find(m => m.Id == _id1);
            Assert.AreEqual(9, updated_member.MaxItems);
        }
    }
}
