using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryBooks = new HashSet<BookCategory>();
        }
        public int CategoryId { get; set; }
        public string  Name { get; set; }
        public ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
