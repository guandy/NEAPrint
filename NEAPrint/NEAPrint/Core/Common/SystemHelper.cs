/***************************************************************************
*projectname:NEAPrint.Core.Common
*classname:SystemHelper
*des:SystemHelper
*author:guandy   https://github.com/guandy/NEAPrint 
*createtime:2019-04-11 11:20:06
*updatetime:2019-04-11 11:20:06
***************************************************************************/
using System;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;

namespace NEAPrint
{
    public sealed class SystemHelper
    {
        /// <summary>
        /// 设置程序开机启动
        /// </summary>
        /// <param name="appPath"></param>
        /// <param name="appName"></param>
        /// <param name="isAutoRun"></param>
        public static void SetAutoRun(string appPath, string appName, bool isAutoRun)
        {
            try
            {
                if (string.IsNullOrEmpty(appPath) || string.IsNullOrEmpty(appName))
                {
                    throw new Exception("应用程序路径或名称为空！");
                }
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey run = reg.CreateSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\");
                if (isAutoRun)
                {
                    run.SetValue(appName, appPath);
                }
                else
                {
                    if (null != run.GetValue(appName))
                    {
                        run.DeleteValue(appName);
                    }
                }
                run.Close();
                reg.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 判断是否为开启启动
        /// </summary>
        /// <param name="appPath"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static bool IsAutoRun(string appPath, string appName)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey software = reg.OpenSubKey(@"SOFTWARE");
                RegistryKey run = reg.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\");
                object key = run.GetValue(appName);
                software.Close();
                run.Close();
                if (null == key || !appPath.Equals(key.ToString()))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }

}
