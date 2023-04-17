using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartproduct.Data;
using Smartproduct.Model.Product;
using Smartproduct.Repository.Product;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Transactions;

namespace Smartproduct.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductTest
    {
        private static IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }


        private readonly DataContext _db;

        public ProductTest(DataContext db)
        {
            _db = db;
        }

        Product Product = new Product()
        {
            ProductCode = "CLT786",
            Name = "Jeep",
            Description = "Mens wrangler jeans",
            CategoryName = "Clothes",
            Price = 355.88M,
            Image = "Yes",
            CreatedOn = System.DateTime.Now,
            CreatedBy = "zainolnabi88@gmail.com"
        };


        [TestMethod]
        public async Task PostAsync_Success()
        {
            var product = new ProductRepository(_db, GetConfig());

            using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await product.Post(Product);

                Assert.IsInstanceOfType(result, typeof(Product));
                tx.Complete();
            }
        }


    }
}
