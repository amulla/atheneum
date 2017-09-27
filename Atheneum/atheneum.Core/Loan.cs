using System;
using System.Collections.Generic;
using System.Text;

namespace atheneum.Core
{
    public class Loan
    {
        public Guid Id;
        public Guid ItemId;
        public Guid MemberId;
        public DateTime LoanDate;
        public DateTime DueDate;
    }
}
