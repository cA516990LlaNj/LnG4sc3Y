// 代码生成时间: 2025-10-05 19:57:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// 命名空间应与项目名一致
namespace LivestreamShoppingSystem
{
    /// <summary>
    /// Interaction logic for LivestreamShoppingSystem.xaml
    /// </summary>
    public partial class LivestreamShoppingSystem : Window
    {
        public LivestreamShoppingSystem()
        {
            InitializeComponent();
        }

        // 假设有一个商品列表
        private List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "商品1", Price = 100 },
            new Product { Id = 2, Name = "商品2", Price = 200 }
        };

        // 商品类
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        // 直播商品列表显示方法
        private void DisplayProducts()
        {
            try
            {
                // 清空现有列表
                productListView.Items.Clear();

                // 将商品列表添加到ListView中
                foreach (var product in products)
                {
                    productListView.Items.Add(new {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price
                    });
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                MessageBox.Show($"Error displaying products: {ex.Message}");
            }
        }

        // 商品点击事件处理
        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedProduct = e.AddedItems[0] as dynamic;
                if (selectedProduct != null)
                {
                    // 显示选中商品的详细信息
                    MessageBox.Show($"Product Selected: {selectedProduct.Name}, Price: {selectedProduct.Price}$");
                }
            }
        }
    }
}