using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NEAPrint
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RunByAdmin();
        }
        /// <summary>
        /// 当前用户是管理员直接启动应用程序
        /// 如果不是管理员，改用管理员身份运行
        /// </summary>
        static void RunByAdmin()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            Application.EnableVisualStyles();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                Application.EnableVisualStyles();
                Application.Run(new PrintMain());
            }
            else
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                    System.Windows.Forms.Application.Exit();
                }
                catch
                {

                }
            }
        }
    }
}
