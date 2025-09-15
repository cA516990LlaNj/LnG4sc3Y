// 代码生成时间: 2025-09-16 03:26:03
// ThemeSwitcherWpfApp.xaml.cs
// 这是一个WPF应用程序，用于实现主题切换功能。

using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppThemeSwitcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplyTheme("LightTheme");
        }

        // 应用主题
        private void ApplyTheme(string themeName)
        {
            try
            {
                string themeUri = $"/WpfAppThemeSwitcher;component/Themes/{themeName}.xaml";
                Application.Current.Resources.MergedDictionaries.Clear();
                ResourceDictionary themeDictionary = new ResourceDictionary()
                {
                    Source = new Uri(themeUri, UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying theme: {ex.Message}");
            }
        }

        // 切换主题按钮点击事件
        private void SwitchThemeButton_Click(object sender, RoutedEventArgs e)
        {
            string currentTheme = (string)Application.Current.Properties["CurrentTheme"];
            string newTheme = currentTheme == "LightTheme" ? "DarkTheme" : "LightTheme";
            ApplyTheme(newTheme);
            Application.Current.Properties["CurrentTheme"] = newTheme;
        }
    }
}
