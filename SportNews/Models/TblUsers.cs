using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportNews.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual ICollection<TblPosts> TblPosts { get; set; }
    }
}
