﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PustokApp.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokApp.Models
{
    public class Book : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercentage { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool InStock { get; set; }
        public string Code { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List <BookImage> BookImages { get; set; }
        public string MainImageUrl { get; set; }
        public string HoverImageUrl { get; set; }



    }
}
