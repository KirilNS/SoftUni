using System;
using System.Collections.Generic;
using System.Text;


namespace ProductShop.Dtos.Import
{
    []
    public class ImportProductDto
    {
        //    <Products>
        //<Product>
        //    <name>Care One Hemorrhoidal</name>
        //    <price>932.18</price>
        //    <sellerId>25</sellerId>
        //    <buyerId>24</buyerId>
        //</Product>
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
    }
}
