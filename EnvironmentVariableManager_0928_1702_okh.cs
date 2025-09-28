// 代码生成时间: 2025-09-28 17:02:29
using System;
using System.Linq;
using System.Windows;

// 环境变量管理器
public partial class EnvironmentVariableManager : Window
{
    // 构造函数
    public EnvironmentVariableManager()
    {
        InitializeComponent();
    }

    // 加载窗口时调用的方法
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取系统环境变量并显示
            var environmentVariables = System.Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry entry in environmentVariables)
            {
                // 将环境变量添加到列表中
                // 这里假设有一个名为EnvironmentVariablesListBox的ListBox控件
                EnvironmentVariablesListBox.Items.Add($"{entry.Key} = {entry.Value}");
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error loading environment variables: {ex.Message}");
        }
    }

    // 添加环境变量按钮点击事件处理
    private void AddVariableButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string variableName = VariableNameTextBox.Text;
            string variableValue = VariableValueTextBox.Text;

            // 检查输入
            if (string.IsNullOrEmpty(variableName) || string.IsNullOrEmpty(variableValue))
            {
                MessageBox.Show("Please enter both variable name and value.");
                return;
            }

            // 添加环境变量
            System.Environment.SetEnvironmentVariable(variableName, variableValue, EnvironmentVariableTarget.User);

            // 更新界面
            EnvironmentVariablesListBox.Items.Add($"{variableName} = {variableValue}");
            MessageBox.Show("Environment variable added successfully.");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error adding environment variable: {ex.Message}");
        }
    }

    // 删除环境变量按钮点击事件处理
    private void RemoveVariableButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string variableName = VariableNameTextBox.Text;

            // 检查输入
            if (string.IsNullOrEmpty(variableName))
            {
                MessageBox.Show("Please enter the variable name to remove.");
                return;
            }

            // 删除环境变量
            System.Environment.SetEnvironmentVariable(variableName, null, EnvironmentVariableTarget.User);

            // 更新界面
            EnvironmentVariablesListBox.Items.Remove(VariableNameTextBox.Text);
            MessageBox.Show("Environment variable removed successfully.");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error removing environment variable: {ex.Message}");
        }
    }
}
