using System;
using System.Collections.Generic;
using System.Text;
using atheneum.Core;

namespace atheneum.Services
{
    public interface ILoanService
    {
        bool Loan(Item item, Member member, Loan loan);
        bool Return(Item item, Member member);
    }
    public class LoanService : ILoanService
    {
        public bool Loan(Item item, Member member, Loan loan)
        {
            bool return_value = false;

            if (member.Loans.Count < member.MaxItems)
            {
                loan.ItemId = item.Id;
                loan.MemberId = member.Id;
                loan.LoanDate = DateTime.Now.Date;
                loan.DueDate = DateTime.Now.Date.AddDays(21);

                item.Status = ItemStatus.OnLoan;
                member.Loans.Add(loan);

                return_value = true;
            }

            return return_value;
        }

        public bool Return(Item item, Member member)
        {
            bool return_value = false;

            var index = member.Loans.FindIndex(l => l.ItemId == item.Id);

            if (index >= 0)
            {
                member.Loans.RemoveAt(index);
                item.Status = ItemStatus.OnShelf;
                return_value = true;
            }

            return return_value;
        }
    }
}
