using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace removeCache
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String mtxName = "캐시자동삭제";
            bool mtxSuccess;

            System.Threading.Mutex mtx = new System.Threading.Mutex(true, mtxName, out mtxSuccess);

            if (!mtxSuccess)
            {
                MessageBox.Show("프로그램이 실행중입니다.");
                return;
            }

            Application.Run(new Main());
            mtx.ReleaseMutex();
        }
    }

    

}
