// 代码生成时间: 2025-09-17 08:38:37
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WebContentGrabber
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient;

        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void FetchContentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = UrlTextBox.Text;
                string content = await FetchWebContentAsync(url);
                ContentTextBox.Text = content;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Fetches the web content from the specified URL asynchronously
        private async Task<string> FetchWebContentAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be empty");
            }

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
