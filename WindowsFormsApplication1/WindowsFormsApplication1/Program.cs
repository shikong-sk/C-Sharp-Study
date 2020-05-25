using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread] // COM线程模型  单线程模型
        static void Main()
        {
            // System.Windows.Form.Application 提供一系列静态方法和属性来管理应用程序

            /*
             *  固定格式
             */

            // 启用程序的可视样式
            Application.EnableVisualStyles();
            // 将 SetCompatibleTextRenderingDefault 设置为 false 默认值
            Application.SetCompatibleTextRenderingDefault(false);
            // 指定要启动的窗体
            // 使要启动的窗体可见，并显示出来
            Application.Run(new TestForm1());
        }
    }
}
