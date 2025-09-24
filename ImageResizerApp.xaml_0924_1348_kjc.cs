// 代码生成时间: 2025-09-24 13:48:44
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageResizerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            
            if (openFileDialog.ShowDialog() == true)
            {
                string[] fileNames = openFileDialog.FileNames;
                if (fileNames.Length > 0)
                {
                    ResizeImages(fileNames);
                }
                else
                {
                    MessageBox.Show("No files selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ResizeImages(string[] filePaths)
        {
            foreach (var filePath in filePaths)
            {
                try
                {
                    BitmapImage originalImage = new BitmapImage();
                    originalImage.BeginInit();
                    originalImage.UriSource = new Uri(filePath);
                    originalImage.CacheOption = BitmapCacheOption.OnLoad;
                    originalImage.EndInit();

                    int targetWidth = 800; // Default target width
                    int targetHeight = (int)(originalImage.Height * (targetWidth / (double)originalImage.Width));

                    // Resize the image
                    BitmapImage resizedImage = new TransformedBitmap(originalImage, new ScaleTransform(targetWidth / originalImage.Width, targetHeight / originalImage.Height));

                    // Save the resized image
                    string newFileName = Path.ChangeExtension(filePath, "resized" + Path.GetExtension(filePath));
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(resizedImage));
                    using (FileStream fileStream = new FileStream(newFileName, FileMode.Create))
                    {
                        encoder.Save(fileStream);
                    }

                    MessageBox.Show("Image resized and saved as: " + newFileName, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error resizing image: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}