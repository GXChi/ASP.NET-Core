using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "电影名称")]
        public string Title { get; set; }
      
        [DataType(DataType.Date)]
        [Display(Name = "上映日期")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [Display(Name = "类型")]
        public string Genre { get; set; }                
      
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 100)]
        [Display(Name = "价格")]
        public decimal Price { get; set; }

        [StringLength(5, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "评级")]
        public string Rating { get; set; }
    }
}
