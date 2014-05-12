using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace KeyCur
{
    [DataContract]
    public class Preference
    {
        [IgnoreDataMember]
        private string Path { get; set; }

        [DataMember]
        public int ClickSpeed { get; set; }

        [DataMember]
        public int DoubleClickDelay { get; set; }

        [DataMember]
        public int MovementAcceleration { get; set; }

        [DataMember]
        public int MaxSpeed { get; set; }

        [DataMember]
        public int WheelAcceleration { get; set; }

        [DataMember]
        public int MaxWheelSpeed { get; set; }

        [DataMember]
        public bool PlaySoundAlert { get; set; }

        [DataMember]
        public bool ShowBallonAlert { get; set; }

        [DataMember]
        public ExtendedKey LMB { get; set; }

        [DataMember]
        public ExtendedKey RMB { get; set; }

        [DataMember]
        public ExtendedKey MMB { get; set; }

        [DataMember]
        public ExtendedKey WheelUp { get; set; }

        [DataMember]
        public ExtendedKey WheelDown { get; set; }

        [DataMember]
        public ExtendedKey Left { get; set; }

        [DataMember]
        public ExtendedKey Right { get; set; }

        [DataMember]
        public ExtendedKey Up { get; set; }

        [DataMember]
        public ExtendedKey Down { get; set; }

        [DataMember]
        public ExtendedKey Activation { get; set; }

        [DataMember]
        public ExtendedKey DoubleClick { get; set; }

        [DataMember]
        public ExtendedKey Drag { get; set; }

        [DataMember]
        public ExtendedKey UpLeft { get; set; }

        [DataMember]
        public ExtendedKey UpRight { get; set; }

        [DataMember]
        public ExtendedKey DownLeft { get; set; }

        [DataMember]
        public ExtendedKey DownRight { get; set; }

        public Preference()
        {
            LMB = new ExtendedKey(Keys.NumPad0, false, 82);
            RMB = new ExtendedKey(Keys.Decimal, false, 83);
            MMB = new ExtendedKey(Keys.NumPad5, false, 76);
            WheelUp = new ExtendedKey(Keys.Z, false, 44);
            WheelDown = new ExtendedKey(Keys.X, false, 45);
            Left = new ExtendedKey(Keys.NumPad4, false, 75);
            Right = new ExtendedKey(Keys.NumPad6, false, 77);
            Up = new ExtendedKey(Keys.NumPad8, false, 72);
            Down = new ExtendedKey(Keys.NumPad2, false, 80);
            UpLeft = new ExtendedKey(Keys.NumPad7, false, 71);
            UpRight = new ExtendedKey(Keys.NumPad9, false, 73);
            DownLeft = new ExtendedKey(Keys.NumPad1, false, 79);
            DownRight = new ExtendedKey(Keys.NumPad3, false, 81);
            Activation = new ExtendedKey(Keys.F11, false, 87);
            DoubleClick = new ExtendedKey(Keys.Add, false, 28);
            Drag = new ExtendedKey(Keys.Subtract, false, 74);

            ClickSpeed = 50;
            DoubleClickDelay = 100;
            MovementAcceleration = 1;
            MaxSpeed = 10;
            WheelAcceleration = 1;
            MaxWheelSpeed = 100;
        }

        public static Preference Load(string path)
        {
            if (!File.Exists(path))
            {
                Preference p = new Preference();
                p.Path = path;
                return p;
            }
            else
            {
                string data = File.ReadAllText(path);

                Preference p = Util.DeserializeJSON<Preference>(data);
                if (p == null) p = new Preference();

                if (p.LMB == null) p.LMB = new ExtendedKey(Keys.NumPad0);
                if (p.RMB == null) p.RMB = new ExtendedKey(Keys.Decimal);
                if (p.MMB == null) p.MMB = new ExtendedKey(Keys.NumPad5);
                if (p.WheelUp == null) p.WheelUp = new ExtendedKey(Keys.Z);
                if (p.WheelDown == null) p.WheelDown = new ExtendedKey(Keys.X);
                if (p.Left == null) p.Left = new ExtendedKey(Keys.NumPad4);
                if (p.Right == null) p.Right = new ExtendedKey(Keys.NumPad6);
                if (p.Up == null) p.Up = new ExtendedKey(Keys.NumPad8);
                if (p.Down == null) p.Down = new ExtendedKey(Keys.NumPad2);
                if (p.Left == null) p.UpLeft = new ExtendedKey(Keys.NumPad7);
                if (p.Right == null) p.UpRight = new ExtendedKey(Keys.NumPad9);
                if (p.Left == null) p.DownLeft = new ExtendedKey(Keys.NumPad1);
                if (p.Right == null) p.DownRight = new ExtendedKey(Keys.NumPad3);
                if (p.Activation == null) p.Activation = new ExtendedKey(Keys.F11);
                if (p.LMB == null) p.DoubleClick = new ExtendedKey(Keys.Add);
                if (p.LMB == null) p.Drag = new ExtendedKey(Keys.Subtract);

                if (p.ClickSpeed == 0) p.ClickSpeed = 50;
                if (p.DoubleClickDelay == 0) p.DoubleClickDelay = 100;
                if (p.MovementAcceleration == 0) p.MovementAcceleration = 1;
                if (p.MaxSpeed == 0) p.MaxSpeed = 30;
                if (p.WheelAcceleration == 0) p.WheelAcceleration = 1;
                if (p.MaxWheelSpeed == 0) p.MaxWheelSpeed = 100;

                p.Path = path;

                return p;
            }
        }

        public void Save()
        {
            string data = Util.SerializeJSON(this);
            File.WriteAllText(Path, data);
        }
    }
}
