using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task_5.Models; 
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Task_5.ViewModels 
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Product> Products { get; set; }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveProductCommand))]
        private Product selectedProduct;

        public ICommand AddProductCommand { get; }
        public IRelayCommand RemoveProductCommand { get; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            LoadInitialProducts();

            AddProductCommand = new RelayCommand(AddProduct);
            RemoveProductCommand = new RelayCommand(RemoveProduct, () => SelectedProduct != null);
        }

        private void LoadInitialProducts()
        {
            Products.Add(new Book
            {
                Name = "Кобзар",
                Description = "Збірка поетичних творів.",
                Price = 250,
                OriginCountry = "Україна",
                PackingDate = DateTime.Now,
                PageCount = 700,
                Publisher = "А-ба-ба-га-ла-ма-га",
                Authors = new List<string> { "Тарас Шевченко" }
            });

            Products.Add(new FoodProduct
            {
                Name = "Молоко 'Галичина'",
                Description = "Молоко пастеризоване 2.5%",
                Price = 56.90m,
                OriginCountry = "Україна",
                PackingDate = DateTime.Now.AddDays(-2),
                ExpiryDate = DateTime.Now.AddDays(5),
                Quantity = 900,
                Unit = "г"
            });
        }

        private void AddProduct()
        {
            Products.Add(new Book
            {
                Name = "Нова книга",
                Description = "Щойно додана",
                Price = 300,
                OriginCountry = "Україна",
                PackingDate = DateTime.Now,
                PageCount = 100,
                Publisher = "Видавництво",
                Authors = new List<string> { "Автор" }
            });
        }

        private void RemoveProduct()
        {
            if (SelectedProduct != null)
            {
                Products.Remove(SelectedProduct);
                SelectedProduct = null;
            }
        }
    }
}