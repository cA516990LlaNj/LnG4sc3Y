// 代码生成时间: 2025-09-16 11:08:38
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

// 定义一个图片尺寸批量调整器的类
public partial class ImageResizerApp : Window
{
    // 构造函数
    public ImageResizerApp()
    {
        InitializeComponent();
    }

    // 打开文件夹并选择图片
    private void SelectImagesButton_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog()
        {
            Filter = "Image Files(*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif",
            Multiselect = true
        };
        if (openFileDialog.ShowDialog() == true)
        {
            foreach (string file in openFileDialog.FileNames)
            {
                ResizeImage(file);
            }
        }
    }

    // 根据指定尺寸调整图片大小
    private void ResizeImage(string imagePath)
    {
        try
        {
            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();

                int newWidth = 800; // 设置新宽度
                int newHeight = 600; // 设置新高度

                using (PngBitmapEncoder encoder = new PngBitmapEncoder())
                {
                    // 创建一个新的BitmapSource对象
                    BitmapSource resizedImage = new TransformedBitmap(bitmap, new ScaleTransform(newWidth / (double)bitmap.PixelWidth, newHeight / (double)bitmap.PixelHeight));
                    encoder.Frames.Add(BitmapFrame.Create(resizedImage));

                    // 保存调整后的图片
                    string fileName = Path.GetFileNameWithoutExtension(imagePath) + "_resized" + Path.GetExtension(imagePath);
                    string filePath = Path.Combine(Path.GetDirectoryName(imagePath), fileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        encoder.Save(fileStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error resizing image: " + ex.Message);
        }
    }
}

// XAML 部分
<Window x:Class="ImageResizerApp.ImageResizerApp"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Image Resizer" Height="350" Width="525">
    <Grid>
        <Button Content="Select Images" HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Width="120" Click="SelectImagesButton_Click"/>
    </Grid>
</Window>