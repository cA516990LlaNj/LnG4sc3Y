// 代码生成时间: 2025-09-20 16:42:19
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ThemeSwitcherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default theme resource dictionary.
        /// </summary>
        private ResourceDictionary defaultTheme;

        /// <summary>
        /// Dark theme resource dictionary.
        /// </summary>
        private ResourceDictionary darkTheme;

        public MainWindow()
        {
            InitializeComponent();

            // Load the default theme.
            defaultTheme = new ResourceDictionary
            {
                Source = new Uri("/Themes/DefaultTheme.xaml", UriKind.Relative)
            };
            this.Resources.MergedDictionaries.Add(defaultTheme);

            // Load the dark theme.
            darkTheme = new ResourceDictionary
            {
                Source = new Uri("/Themes/DarkTheme.xaml", UriKind.Relative)
            };
        }

        /// <summary>
        /// Switches the application theme.
        /// </summary>
        public void SwitchTheme()
        {
            try
            {
                if (this.Resources.MergedDictionaries.Contains(darkTheme))
                {
                    // Switch to default theme.
                    this.Resources.MergedDictionaries.Remove(darkTheme);
                    this.Resources.MergedDictionaries.Add(defaultTheme);
                }
                else
                {
                    // Switch to dark theme.
                    this.Resources.MergedDictionaries.Remove(defaultTheme);
                    this.Resources.MergedDictionaries.Add(darkTheme);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur when switching themes.
                MessageBox.Show($"Error switching theme: {ex.Message}", "Theme Switch Error");
            }
        }
    }
}