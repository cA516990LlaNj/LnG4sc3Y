// 代码生成时间: 2025-09-20 04:27:51
using System;
using System.Windows;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestfulApiApp
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        // 发送GET请求的示例方法
        private async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                // 错误处理
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // 发送POST请求的示例方法
        private async Task<string> PostAsync(string url, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                // 错误处理
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // 示例：调用GET请求并显示结果
        private async void OnGetButtonClick(object sender, RoutedEventArgs e)
        {
            string result = await GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            if (result != null)
            {
                // 假设返回的数据是JSON格式
                JObject jo = JObject.Parse(result);
                // 在UI中显示结果（此处省略实际的UI更新代码）
                // Example: DisplayResult(jo);
            }
        }

        // 示例：调用POST请求并显示结果
        private async void OnPostButtonClick(object sender, RoutedEventArgs e)
        {
            var data = new { title = "New Todo", completed = false, userId = 1 };
            string result = await PostAsync("https://jsonplaceholder.typicode.com/todos", data);
            if (result != null)
            {
                // 在UI中显示结果（此处省略实际的UI更新代码）
                // Example: DisplayResult(JObject.Parse(result));
            }
        }

        // 用于显示结果的方法（示例，需根据实际UI组件进行实现）
        private void DisplayResult(JObject result)
        {
            // 此处添加代码以将结果显示在UI中
        }
    }
}
