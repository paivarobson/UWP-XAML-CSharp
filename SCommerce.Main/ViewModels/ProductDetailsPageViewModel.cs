using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public List<string> Images { get; set; }
        public string selectedImage;
        public string SelectedImage
        {
            get { return selectedImage; }
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedImage"));
                }                
            }
        }

        public ProductDetailsPageViewModel()
        {
            Title = "Produto 1";
            Description = "Não é uma descrição ideal para este produto. Mas é a que tem :)";
            Price = 99.99856;
            Rating = 4;
            Images = new List<string>
            {
                "ms-appx:///Assets/Images/shirt1.jpg",
                "ms-appx:///Assets/Images/shirt2.jpg",
                "ms-appx:///Assets/Images/shirt3.jpg"
            };
            SelectedImage = Images[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
