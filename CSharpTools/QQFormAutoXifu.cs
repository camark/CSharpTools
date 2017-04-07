
//作用:QQ吸附窗体
//作者：刘典武
//时间：2010-12-01
//用法：添加timer控件，enable设置为true,实例化类EcanQQ qqfrm = new EcanQQ();timer1_Tick时间调用qqfrm.hide_show(this, ref height, timer1);     

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ecan
{
    public class EcanQQ
    {
        /// <summary>
        /// QQ吸附窗体
        /// </summary>
        /// <param name="frm">要吸附边缘的窗体</param>
        /// <param name="frmHeight">窗体的高度</param>
        /// <param name="timer">定时器控件</param>
        //用法：在对应窗体timer控件的Tick事件中写代码 int height = this.Height; EcanQQ.hide_show(this, ref height, timer1);

        public void hide_show(Form frm, ref int frmHeight, Timer timer)
        {
            if (frm.WindowState != FormWindowState.Minimized)
            {
                timer.Interval = 100;
                if (Cursor.Position.X > frm.Left - 1 && Cursor.Position.X < frm.Right && Cursor.Position.Y > frm.Top - 1 && Cursor.Position.Y < frm.Bottom)
                {
                    if (frm.Top <= 0 && frm.Left > 5 && frm.Left < Screen.PrimaryScreen.WorkingArea.Width - frm.Width)
                    {
                        frm.Top = 0;
                    }
                    else if (frm.Left <= 0)
                    {
                        frm.Left = 0;
                    }
                    else if (frm.Left + frm.Width > Screen.PrimaryScreen.WorkingArea.Width)
                    {
                        frm.Left = Screen.PrimaryScreen.WorkingArea.Width - frm.Width;
                    }
                    else
                    {
                        if (frmHeight > 0)
                        {
                            frm.Height = frmHeight;
                            frmHeight = 0;
                        }
                    }
                }
                else
                {
                    if (frmHeight < 1)
                    {
                        frmHeight = frm.Height;
                    }
                    if (frm.Top <= 4 && frm.Left > 5 && frm.Left < Screen.PrimaryScreen.WorkingArea.Width - frm.Width)
                    {
                        frm.Top = 3 - frm.Height;
                        if (frm.Left <= 4)
                        {
                            frm.Left = -5;
                        }
                        else if (frm.Left + frm.Width >= Screen.PrimaryScreen.WorkingArea.Width - 4)
                        {
                            frm.Left = Screen.PrimaryScreen.WorkingArea.Width - frm.Width + 5;
                        }
                    }
                    else if (frm.Left <= 4)
                    {
                        frm.Left = 3 - frm.Width;
                    }
                    else if (frm.Left + frm.Width >= Screen.PrimaryScreen.WorkingArea.Width - 4)
                    {
                        frm.Left = Screen.PrimaryScreen.WorkingArea.Width - 3;
                    }
                }
            }
        }
    }
}