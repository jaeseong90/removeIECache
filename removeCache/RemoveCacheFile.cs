using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace removeCache
{
    public class RemoveCacheFile
    {
        private Main _main;

        Boolean _IsRun = false;
        Thread _Thread;
        public static RemoveCacheFile _RemoveCacheFile = new RemoveCacheFile();

        private RemoveCacheFile()
        {
        }

        public bool SetMain(Main main)
        {
            this._main = main;
            return true;
        }

        public bool Start()
        {
            if (!_IsRun)
            {
                _Thread = new Thread(runRemove);
                _Thread.Start();
                _IsRun = true;
                return true;
            }

            return false;
        }

        private void runRemove()
        {

            try
            {
                while (true)
                {

                    //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8");

                    string iePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache),"IE") ;
                    string[] arrFilePath = Directory.GetDirectories(iePath);
                    foreach (string filePath in arrFilePath)
                    {
                        if (Directory.Exists(filePath))
                        {
                            foreach (string file in Directory.GetFiles(filePath, "*.mts"))
                            {
                                if (File.Exists(file))
                                {
                                    File.Delete(file);
                                }
                            }

                            foreach (string file in Directory.GetFiles(filePath, "*.jpg"))
                            {
                                if (File.Exists(file))
                                {
                                    File.Delete(file);
                                }
                            }
                        }
                    }
                  
                    Thread.Sleep(1000 * 10);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("비정상 종료\n", e.ToString());
                _main.SetLog("Error", e.ToString());
            }
            finally
            {
                Show("종료되었습니다. 재활성화 바랍니다.");
            }
        }

        private async void Show(string message)
        {
            await Task.Delay(1);
            System.Windows.Forms.MessageBox.Show(message);
        }


    }
}
