using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string BannerText { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [Column(TypeName ="nText")]
        public string Content { get; set; }
        //[ForeignKey("User")]
        //public int UserId { get; set; }
        //public User User { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
