using System;
using System.Collections.Generic;
using System.Text;

namespace atheneum.Core
{
    public enum ItemStatus
    {
        OnShelf,
        OnLoan,
        InRepair
    }

    public class Item
    {
        public Guid Id;
        public Guid SectionId;
        public Guid CategoryId;
        public string Code;
        public string Title;
        public string Author;
        public string ISBN;
        public ItemStatus Status; 
    }
}
