using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(15)]
        public string Isbn { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(20)]
        public string Publisher { get; set; }

        public override string ToString() => Title;
    }
}
