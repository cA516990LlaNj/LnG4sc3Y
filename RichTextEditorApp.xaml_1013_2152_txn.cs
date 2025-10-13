// 代码生成时间: 2025-10-13 21:52:52
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;

// MainWindow 是 WPF 应用程序的主窗口
public partial class MainWindow : Window
{
    // 构造函数
    public MainWindow()
    {
        InitializeComponent();
        // 初始化富文本编辑器组件
        InitializeRichTextBox();
    }

    // 初始化富文本编辑器
    private void InitializeRichTextBox()
    {
        // 设置富文本编辑器的默认样式
        rtbEditor.Document.Blocks.Clear();
        Paragraph paragraph = new Paragraph();
        paragraph.Inlines.Add("欢迎使用富文本编辑器");
        rtbEditor.Document.Blocks.Add(paragraph);
    }

    // 保存按钮点击事件处理程序
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取富文本编辑器的内容并保存
            string content = rtbEditor.Text;
            System.IO.File.WriteAllText("editorContent.txt", content);
            MessageBox.Show("内容已保存");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"保存时出错: {ex.Message}");
        }
    }

    // 打开按钮点击事件处理程序
    private void btnOpen_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 使用文件对话框选择文件并打开
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                string content = System.IO.File.ReadAllText(openFileDialog.FileName);
                rtbEditor.Document.Blocks.Clear();
                rtbEditor.Document.Blocks.Add(new Paragraph(content));
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"打开文件时出错: {ex.Message}");
        }
    }

    // 复制按钮点击事件处理程序
    private void btnCopy_Click(object sender, RoutedEventArgs e)
    {
        // 将富文本编辑器的选中内容复制到剪贴板
        rtbEditor.Copy();
    }

    // 粘贴按钮点击事件处理程序
    private void btnPaste_Click(object sender, RoutedEventArgs e)
    {
        // 将剪贴板内容粘贴到富文本编辑器
        rtbEditor.Paste();
    }
}
