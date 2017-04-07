//类名:EcanSystem
//作用:系统设置及其他
//作者：刘典武
//时间：2010-12-05

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace Ecan
{
    public class EcanSystem
    {

        /// <summary>
        /// 设置程序开机运行
        /// </summary>
        /// <param name="started">是否开机运行</param>
        /// <param name="exeName">要运行的EXE程序名称（不要拓展名）</param>
        /// <param name="path">要运行的EXE程序路径</param>
        /// <returns>成功返回真，否则返回假</returns>

        public bool runWhenStart(bool started, string exeName, string path)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            }
            if (started == true)
            {
                try
                {
                    key.SetValue(exeName, path);//设置为开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    key.DeleteValue(exeName);//取消开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 解禁任务管理器
        /// </summary>
        /// <returns>成功返回真，否则返回假</returns>

        public bool enableTaskmgr()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system");
            }
            try
            {
                key.SetValue("disabletaskmgr", 0, RegistryValueKind.DWord);
                key.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 禁用任务管理器
        /// </summary>
        /// <returns>成功返回真，否则返回假</returns>

        public bool notEnableTaskmgr()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system");
            }
            try
            {
                key.SetValue("disabletaskmgr", 1, RegistryValueKind.DWord);
                key.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 解禁注册表
        /// </summary>
        /// <returns>成功返回真，否则返回假</returns>

        public bool enableRegedit()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system");
            }
            try
            {
                key.SetValue("disableregistrytools", 0, RegistryValueKind.DWord);
                key.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 禁用注册表
        /// </summary>
        /// <returns>成功返回真，否则返回假</returns>

        public bool notEnableRegedit()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\system");
            }
            try
            {
                key.SetValue("disableregistrytools", 1, RegistryValueKind.DWord);
                key.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="processName">进程名称</param>
        /// <returns>成功返回真，否则返回假</returns>

        public bool killProcess(string processName)
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName == processName)
                    {
                        p.Kill();
                    }
                }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 注册控件
        /// </summary>
        /// <param name="dllIdValue">控件注册后对应的键值</param>
        /// <returns>成功返回真，否则返回假</returns>

        public bool regDll(string dllIdValue)
        {
            try
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"CLSTD\" + dllIdValue, true);//打开注册表子项
                if (key == null)//如果该项不存在的话，则创建该子项
                {
                    key = Registry.ClassesRoot.CreateSubKey(@"CLSTD\" + dllIdValue);
                }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 压缩图片（指定压缩比例值）
        /// </summary>
        /// <param name="fromFile">源文件</param>
        /// <param name="saveFile">保存文件</param>
        /// <param name="bili">比例值（例如0.5）</param>
        /// <returns>成功返回真，否则返回假</returns>

        public bool pressImage(string fromFile, string saveFile, double bili)
        {
            Image img;
            Bitmap bmp;
            Graphics grap;
            int width, height;
            try
            {
                img = Image.FromFile(fromFile);
                width = Convert.ToInt32(img.Width * bili);
                height = Convert.ToInt32(img.Height * bili);

                bmp = new Bitmap(width, height);
                grap = Graphics.FromImage(bmp);
                grap.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                grap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grap.DrawImage(img, new Rectangle(0, 0, width, height));

                bmp.Save(saveFile, System.Drawing.Imaging.ImageFormat.Jpeg);

                grap.Dispose();
                bmp.Dispose();
                img.Dispose();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 压缩图片（指定高度和宽度）
        /// </summary>
        /// <param name="fromFile">源文件</param>
        /// <param name="saveFile">保存文件</param>
        /// <param name="width">宽度值</param>
        /// <param name="height">高度值</param>
        /// <returns>成功返回真，否则返回假</returns>

        public bool pressImage(string fromFile, string saveFile, int width, int height)
        {
            Image img;
            Bitmap bmp;
            Graphics grap;
            try
            {
                img = Image.FromFile(fromFile);

                bmp = new Bitmap(width, height);
                grap = Graphics.FromImage(bmp);
                grap.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                grap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grap.DrawImage(img, new Rectangle(0, 0, width, height));

                bmp.Save(saveFile, System.Drawing.Imaging.ImageFormat.Jpeg);

                grap.Dispose();
                bmp.Dispose();
                img.Dispose();
                return true;
            }
            catch { return false; }
        }
    }
}