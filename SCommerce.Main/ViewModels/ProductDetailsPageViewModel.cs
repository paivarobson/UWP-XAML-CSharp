using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public List<string> Images { get; set; }
        public string SelectedImage { get; set; }

        public ProductDetailsPageViewModel()
        {
            Title = "Produto 1";
            Description = "Não é uma descrição ideal para este produto. Mas é a que tem :)";
            Price = 99.99;
            Rating = 4;
            Images = new List<string>
            {
                "ms-appx:///Assets/Images/shirt1.jpg",
                "ms-appx:///Assets/Images/shirt2.jpg",
                "ms-appx:///Assets/Images/shirt3.jpg"
            };
            SelectedImage = Images[0];
        }
    }
}
