using SCommerce.Main.Entities;
using SCommerce.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SCommerce.Main.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> CreateAsync(string title, string description, int rating, double price, IList<StorageFile> files)
        {
            var destFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
            var images = new List<ProductImage>();

            foreach (var file in files)
            {
                var image = await file.CopyAsync(destFolder, file.Name, NameCollisionOption.GenerateUniqueName);
                images.Add(new ProductImage { Path = image.Name });
            }

            var product = new Product
            {
                Title = title,
                Description = description,
                Rating = rating,
                Price = price,
                Images = images
            };

            await productRepository.AddAsync(product);

            return product;
    }

        public Task<List<Product>> ListAsync() => productRepository.ListAsync();

        public Task<Product> FindAsync(int id) => productRepository.FindAsync(id);

    }
}
