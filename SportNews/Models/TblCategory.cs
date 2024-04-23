using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportNews.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public string CateId { get; set; }
        public string CateName { get; set; }

        public virtual ICollection<TblPosts> TblPosts { get; set; }
    }
}
