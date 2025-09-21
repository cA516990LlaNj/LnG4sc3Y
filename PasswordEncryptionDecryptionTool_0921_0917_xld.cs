// 代码生成时间: 2025-09-21 09:17:14
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

// 密码加密解密工具类
public partial class PasswordEncryptionDecryptionTool : Window
{
    private string encryptedPassword = string.Empty;
    private string decryptedPassword = string.Empty;

    public PasswordEncryptionDecryptionTool()
    {
        InitializeComponent();
    }

    // 加密密码方法
    private string EncryptPassword(string password)
    {
        try
        {
            using (Aes aesAlg = Aes.Create())
            {
                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(password);
                            }
                        }
                        encryptedPassword = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            return encryptedPassword;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error during encryption: " + ex.Message);
            return null;
        }
    }

    // 解密密码方法
    private string DecryptPassword(string encryptedPassword)
    {
        try
        {
            using (Aes aesAlg = Aes.Create())
            {
                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                decryptedPassword = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return decryptedPassword;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error during decryption: " + ex.Message);
            return null;
        }
    }

    // 调用加密方法的按钮事件处理程序
    private void EncryptButton_Click(object sender, RoutedEventArgs e)
    {
        string password = PasswordInputTextBox.Text;
        string encrypted = EncryptPassword(password);

        if (encrypted != null)
        {
            EncryptedPasswordTextBox.Text = encrypted;
        }
    }

    // 调用解密方法的按钮事件处理程序
    private void DecryptButton_Click(object sender, RoutedEventArgs e)
    {
        string encrypted = EncryptedPasswordTextBox.Text;
        string decrypted = DecryptPassword(encrypted);

        if (decrypted != null)
        {
            DecryptedPasswordTextBox.Text = decrypted;
        }
    }
}
