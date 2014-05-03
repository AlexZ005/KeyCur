using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Reflection;

namespace KeyCur
{
    [DataContract]
    public class ExtendedKey
    {
        [DataMember]
        public int KeyProxy { get; set; }

        [DataMember]
        public int ScanCode { get; set; }

        [DataMember]
        public bool IsExtended { get; set; }

        [IgnoreDataMember]
        public Keys Key { get { return KeyProxy == 0 ? Keys.None : (Keys)KeyProxy; } set { KeyProxy = (int)value; } }

        public ExtendedKey(Keys key = Keys.None, bool extended = false, int scanCode = 0)
        {
            Key = key;
            IsExtended = extended;
            ScanCode = scanCode;
        }

        public override string ToString()
        {
            string name = Key.ToString();

            if (IsExtended && Key == Keys.Enter)
            {
                name = "Ex " + name;
            }

            return name.
                Replace("NumPad", "NP").
                Replace("Subtract", "-").
                Replace("Multiply", "*").
                Replace("Add", "+").
                Replace("Divide", "/");
        }

        public static bool operator ==(ExtendedKey ex1, ExtendedKey ex2)
        {
            if ((ex1 as object) == null && (ex2 as object) == null) return true;
            if ((ex1 as object) == null && (ex2 as object)  != null) return false;
            if ((ex1 as object)  != null && (ex2 as object)  == null) return false;
            return ex1.ScanCode == ex2.ScanCode;
        }

        public static bool operator !=(ExtendedKey ex1, ExtendedKey ex2)
        {
            return !(ex1 == ex2);
        }

        public override bool Equals(object obj)
        {
            return (obj as ExtendedKey) == this;
        }

        public override int GetHashCode()
        {
            PropertyInfo[] theProperties = this.GetType().GetProperties();

            int hash = 31;

            foreach (PropertyInfo info in theProperties)
            {
                if (info != null)
                    unchecked
                    {
                        hash = 29 * hash ^ info.GetHashCode();
                    }
            }

            return hash;
        }
    }
}
