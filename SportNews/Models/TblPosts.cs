using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportNews.Models
{
    public partial class TblPosts
    {
        public int IdPost { get; set; }
        public string CateId { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
        public byte[] CreatedAt { get; set; }
        public string img { get; set; }
        public virtual TblCategory Cate { get; set; }
        public virtual TblUsers User { get; set; }
    }
}
