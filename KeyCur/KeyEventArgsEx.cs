using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyCur
{
    public class KeyEventArgsEx : KeyEventArgs
    {
        public ExtendedKey Key { get; set; }

        public KeyEventArgsEx(Keys key = Keys.None, bool extended = false, int scanCode = 0)
            : base(key)
        {
            Key = new ExtendedKey(key, extended, scanCode);
        }

        public KeyEventArgsEx(ExtendedKey key)
            : base(key.Key)
        {
            Key = key;
        }
    }
}
