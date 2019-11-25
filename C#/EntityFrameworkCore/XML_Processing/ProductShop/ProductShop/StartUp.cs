using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            using (var db = new ProductShopContext())
            {
                var xmlToImport = File.ReadAllText($"../../../Datasets/products.xml");

                Console.WriteLine(ImportProducts(db, xmlToImport)); 
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var users=(ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            foreach (var user in users)
            {
                User userToImport = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                };

                context.Add(userToImport);
            }

            int result=context.SaveChanges();

            return $"Successfully imported {result}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var products = (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));


            foreach (var pro in products)
            {
                var product = Mapper.Map<Product>(pro);

                context.Add(product);
            }
            int result = context.SaveChanges();

            return $"Successfully imported {result}";
        }
    }
}