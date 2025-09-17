// 代码生成时间: 2025-09-17 19:38:02
using System;
using System.Windows.Controls;
using System.Globalization;
using System.Linq;

// 表单验证器类
public class FormValidator
{
    // 验证文本框是否为空
    public static bool IsNotEmptyTextBox(TextBox textBox)
    {
        if (textBox == null) throw new ArgumentNullException(nameof(textBox));

        bool isEmpty = string.IsNullOrWhiteSpace(textBox.Text);
        if (isEmpty)
        {
            MessageBox.Show("The textbox cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        return !isEmpty;
    }

    // 验证日期是否合法
    public static bool IsValidDateTextBox(TextBox textBox)
    {
        if (textBox == null) throw new ArgumentNullException(nameof(textBox));

        if (DateTime.TryParseExact(textBox.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return true;
        }
        else
        {
            MessageBox.Show("The date is not valid.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }

    // 验证电子邮件是否合法
    public static bool IsValidEmailTextBox(TextBox textBox)
    {
        if (textBox == null) throw new ArgumentNullException(nameof(textBox));

        try
        {
            var addr = new System.Net.Mail.MailAddress(textBox.Text);
            return addr.Address == textBox.Text;
        }
        catch
        {
            MessageBox.Show("The email is not valid.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }

    // 其他验证方法可以继续添加...
}
