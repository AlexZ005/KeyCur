using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace KeyCur
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsDuplicate())
            {
                MessageBox.Show("Another instance of the KeyCur is already running", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Exchange.Init();

            bool minimized = false;

            if (args.Length != 0 && args[0].ToLower() == "/minimized") minimized = true;

            Application.Run(new Configure(minimized));
        }

        private static bool IsDuplicate()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //Loop through the running processes in with the same name 
            foreach (Process process in processes)
            {
                //Ignore the current process 
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file. 
                    if (Assembly.GetExecutingAssembly().Location.
                         Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return the other process instance.  
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
