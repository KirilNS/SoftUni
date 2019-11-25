using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                var xmlToImport = File.ReadAllText($"../../../Datasets/categories-products.xml");

                Console.WriteLine(ImportCategoryProducts(db, xmlToImport)); 
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
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categories = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            foreach (var item in categories)
            {
                var category = Mapper.Map<Category>(item);
                context.Categories.Add(category);
            }

            int count=context.SaveChanges();

            return $"Successfully imported {count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));
            var categoryProductsDto =
                ((ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .ToList();

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                if (targetProduct != null && targetCategory != null)
                {
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(category);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}