using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class LoginForm : Form
    {
        AutoSizeFormClass autoSizeFormClass = new AutoSizeFormClass();
        private Button _testButton;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            accountText.Text = "";
            passwordText.Text = "";

            accountText.TabIndex = 0;

            // 
            // 动态生成控件 按钮
            // testButton
            // 

            // 实例化
            _testButton = new Button();

            _testButton.Location = new System.Drawing.Point(116, 229);
            _testButton.Name = "testButton";
            _testButton.Size = new System.Drawing.Size(221, 35);
            _testButton.TabIndex = 4;
            _testButton.Text = "测试";
            _testButton.UseVisualStyleBackColor = true;

            // 注册控件事件
            _testButton.Click += TestButton_Click;

            // 将控件添加到控件集合中
            Controls.Add(this._testButton);

            autoSizeFormClass.controllInitializeSize(this);
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            Control from = (Control) sender;
            MessageBox.Show(from.Text);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认退出？", "退出", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            autoSizeFormClass.controlAutoSize(this);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = accountText.Text.Trim();
            string pass = BitConverter
                .ToString(
                    new SHA1CryptoServiceProvider()
                        .ComputeHash(
                            Encoding.UTF8.GetBytes(passwordText.Text)
                        )
                )
                .Replace("-", "");
            MessageBox.Show(user + "\r\n" + pass);
        }
    }
}