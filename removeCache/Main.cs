using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace removeCache
{
    public partial class Main : Form
    {

        public string _tempFolderPath;

        public Main()
        {
            InitializeComponent();
            RemoveCacheFile._RemoveCacheFile.SetMain(this);
            RemoveCacheFile._RemoveCacheFile.Start();
            InitConf();
            this.Text = "캐시자동삭제";
        }

        private const string _ConfName = @"\setting.ini";
        private string _Dir;
        private string _Year;
        private string _Month;
        private string _Day;
        private bool _Test = false;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void InitConf()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;

            //----------------------------------------------------------

            _Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            _Year = DateTime.Now.Year.ToString();
            _Month = DateTime.Now.Month.ToString();
            _Day = DateTime.Now.Day.ToString();

            CreateDir(_Dir + @"\removeCache");
            CreateDir(_Dir + @"\removeCache\" + _Year);
            CreateDir(_Dir + @"\removeCache\" + _Year + @"\" + _Month);

            SetLog("START OF MODULE", "START");
        }

        private void CreateDir(string dir)
        {
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            catch(Exception e){
                SetLog("ERROR createDir", e.ToString());
                MessageBox.Show("ERROR createDir" + e.ToString());
            }
        }

        private string GetConf(string section, string key)
        {
            StringBuilder ViewTray = new StringBuilder();
            GetPrivateProfileString(section, key, "", ViewTray, ViewTray.Capacity, _Dir + _ConfName);
            return ViewTray.ToString();
        }

        public void SetLog(string title , string log)
        {
            try
            {
                if (_Test)
                {
                    MessageBox.Show(log);
                }
                File.AppendAllText(_Dir + @"\removeCache\" + _Year + @"\" + _Month + @"\" + _Year + _Month + _Day + ".txt",DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "" + title + "" + log + "");
            }catch(Exception e)
            {
                MessageBox.Show("SetLog" + e.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shutdown();
        }

        public void Shutdown()
        {
            this.Dispose();
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RemoveCacheFile._RemoveCacheFile.Start())
            {
                MessageBox.Show("재활성화 되었습니다.");
            }
        }
    }

}
