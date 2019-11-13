using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db=new BookShopContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
