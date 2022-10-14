using BK_Tool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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

            Application.Run(new FrmMain());
        }

        /// <summary>
        /// 判断进程是否存在
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static bool ExistsProcess(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);
            return (process != null && process.Length > 0);
        }
    }
}
