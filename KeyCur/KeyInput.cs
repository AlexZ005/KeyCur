using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace KeyCur
{
    public class KeyInput:Control
    {
        private ToolTip tips = new ToolTip();
        private Label KeyText = new Label();

        private ExtendedKey key_;
        public ExtendedKey Key
        {
            get
            {

                return key_ == null ? new ExtendedKey() : key_;
            }
            set
            {
                key_ = value;
                if (key_ == null) key_ = new ExtendedKey(Keys.None);
                KeyText.Text = key_.ToString();
            }
        }

        public string ToolTip
        {
            get
            {
                return tips.GetToolTip(KeyText);
            }
            set
            {
                tips.SetToolTip(KeyText, value);
            }
        }

        public KeyInput()
        {
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.StandardClick, true);
            Cursor = Cursors.Hand;
            BackColor = Color.Gray;
            KeyText.ForeColor = Color.White;
            KeyText.TextAlign = ContentAlignment.MiddleCenter;
            KeyText.AutoSize = false;
            KeyText.Dock = DockStyle.Fill;
            KeyText.Text = Key.ToString();
            KeyText.Click +=new EventHandler(KeyText_Click);
            KeyText.MouseEnter +=new EventHandler(KeyText_MouseEnter);
            KeyText.MouseLeave+=new EventHandler(KeyText_MouseLeave);
            Controls.Add(KeyText);
        }

        private void KeyText_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        protected override void OnClick(EventArgs e)
        {
            Focus();
            base.OnClick(e);
        }

        protected void KeyText_MouseEnter(object sender, EventArgs e)
        {
            if (!Focused) BackColor = Color.Silver;
        }

        protected void KeyText_MouseLeave(object sender, EventArgs e)
        {
            if (!Focused) BackColor = Color.Gray;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            BackColor = Color.White;
            KeyText.Text = "??";
            KeyText.ForeColor = Color.Black;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            BackColor = Color.Gray;
            KeyText.Text = Key.ToString();
            KeyText.ForeColor = Color.White;
            base.OnLostFocus(e);
        }
    }
}
