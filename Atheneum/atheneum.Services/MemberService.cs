using System;
using System.Collections.Generic;
using System.Text;
using atheneum.Core;

namespace atheneum.Services
{
    public interface IMemberService
    {
        bool Add(Member member, List<Member> members);
        bool Update(Guid guid, Member member, List<Member> members);
        bool Delete(Guid guid, List<Member> members);
    }
    public class MemberService : IMemberService
    {
        public bool Add(Member member, List<Member> members)
        {
            bool return_value = false;

            if (members.Find(s => s.Id == member.Id) == null && members.Find(s => s.Code == member.Code) == null)
            {
                members.Add(member);
                return_value = true;
            }

            return return_value;
        }

        public bool Update(Guid guid, Member member, List<Member> members)
        {
            bool return_value = false;

            int index = members.FindIndex(i => i.Id == guid);

            if (index >= 0 && (members.Find(s => s.Id == member.Id) == null && members.Find(s => s.Code == member.Code) == null))
            {
                members[index].Code = member.Code;
                members[index].Title = member.Title;
                members[index].Forename = member.Forename;
                members[index].Surname = member.Surname;
                members[index].DOB = member.DOB;
                members[index].Gender = member.Gender;
                members[index].Address = member.Address;
                members[index].City = member.City;
                members[index].Postcode = member.Postcode;
                members[index].Email = member.Email;
                members[index].Telephone = member.Telephone;
                members[index].Mobile = member.Mobile;
                members[index].MaxItems = member.MaxItems;

                return true;
            }

            return return_value;
        }

        public bool Delete(Guid guid, List<Member> members)
        {
            throw new NotImplementedException();
        }
    }
}
