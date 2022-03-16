using System;
using System.Collections.Generic;

#nullable disable

namespace Microtech_WebApiTask_3
{
    public partial class Account
    {
        public Account()
        {
            InverseAccParentNavigation = new HashSet<Account>();
        }

        public string AccNumber { get; set; }
        public string AccParent { get; set; }
        public decimal? Balance { get; set; }

        public virtual Account AccParentNavigation { get; set; }
        public virtual ICollection<Account> InverseAccParentNavigation { get; set; }
    }
}
