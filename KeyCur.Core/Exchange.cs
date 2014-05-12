using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyCur
{
    public static class Exchange
    {
        public static Preference Preference { get; set; }

        public static void Init()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            dir = Path.Combine(dir, "Onuprova");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir = Path.Combine(dir, "KeyCur");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, "preference2.json");

            //System.Windows.Forms.MessageBox.Show(path);

            Preference = Preference.Load(path);
        }
    }
}
