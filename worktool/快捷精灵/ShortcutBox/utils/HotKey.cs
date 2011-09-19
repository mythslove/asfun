using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ShortcutBox.utils
{
    /// <summary>
    /// 热键代理
    /// </summary>
    class HotKey
    {
        /// <summary>
        /// windows热键消息，在WndProc内判断消息时用
        /// </summary>
        public const int WM_HOTKEY = 0x312;

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口句柄</param>
        /// <param name="id">定义热键的ID,这个ID不能跟其它ID重复</param>
        /// <param name="fsModifiers">组合键</param>
        /// <param name="vk)">热键</param>
        /// <returns>
        /// 返回0：注册失败，要得到扩展错误信息，调用GetLastError。
        /// 返回!=0：注册成功。
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            KeyModifiers fsModifiers,
            Keys vk
        );

        /// <summary>
        /// 移除热键
        /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
        /// <returns>
        /// 返回0：注册失败，要得到扩展错误信息，调用GetLastError。
        /// 返回!=0：注册成功。
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int id
        );

        /// <summary>
        /// 获取键状态
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        [DllImport("user32.dll",CharSet = CharSet.Auto,
            ExactSpelling = true,
            CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);


 
        /// <summary>
        /// 热键枚举
        /// </summary>
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            Windows = 8
        } 



    }
}
