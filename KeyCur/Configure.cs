using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KeyCur
{
    public partial class Configure : Form
    {
        GlobalKeyboardHook gkh = new GlobalKeyboardHook();
        MouseSimulator msim = new MouseSimulator();

        SoundPlayer Player = new SoundPlayer();

        string enable_audio = null, disable_audio = null;

        MouseState MouseState;

        KeyState KeyState;

        KeyInput current { get; set; }

        List<KeyInput> KeyInputs;

        bool Simulate = false;

        bool StartMinimized = false;

        public Configure(bool minimized = false)
        {
            InitializeComponent();
            string dir = Application.ExecutablePath;
            dir = dir.Substring(0, dir.LastIndexOf("\\"));
            enable_audio = System.IO.Path.Combine(dir, "SFX\\enable.wav");
            disable_audio = System.IO.Path.Combine(dir, "SFX\\disable.wav");

            StartMinimized = minimized;
        }

        protected override void OnLoad(EventArgs e)
        {
            lmb.Key = Exchange.Preference.LMB;
            rmb.Key = Exchange.Preference.RMB;
            mmb.Key = Exchange.Preference.MMB;
            wheel_up.Key = Exchange.Preference.WheelUp;
            wheel_down.Key = Exchange.Preference.WheelDown;
            left.Key = Exchange.Preference.Left;
            right.Key = Exchange.Preference.Right;
            up.Key = Exchange.Preference.Up;
            down.Key = Exchange.Preference.Down;
            activation.Key = Exchange.Preference.Activation;
            double_click.Key = Exchange.Preference.DoubleClick;
            drag.Key = Exchange.Preference.Drag;
            up_left.Key = Exchange.Preference.UpLeft;
            up_right.Key = Exchange.Preference.UpRight;
            down_left.Key = Exchange.Preference.DownLeft;
            down_right.Key = Exchange.Preference.DownRight;

            MouseState.LeftButton = ButtonState.Up;
            MouseState.MiddleButton = ButtonState.Up;
            MouseState.RightButton = ButtonState.Up;

            KeyState.Left = ButtonState.Up;
            KeyState.Right = ButtonState.Up;
            KeyState.Up = ButtonState.Up;
            KeyState.Down = ButtonState.Up;
            KeyState.WheelUp = ButtonState.Up;
            KeyState.WheelDown = ButtonState.Up;
            KeyState.Activation = ButtonState.Up;
            KeyState.DoubleClick = ButtonState.Up;
            KeyState.Drag = ButtonState.Up;

            KeyState.ih = 0;
            KeyState.iv = 0;
            KeyState.iw = 0;

            start_button.Text = "Start (" + Exchange.Preference.Activation.ToString() + ")";

            KeyInputs = new KeyInput[]{
                lmb,rmb, mmb, wheel_up, wheel_down, up,left,down,right,
                activation, double_click, drag, up_left,up_right, down_left, down_right
            }.ToList();

            foreach (KeyInput ki in KeyInputs)
            {
                gkh.HookedKeys.Add(ki.Key);
            }

            gkh.KeyDown += new EventHandler<KeyEventArgsEx>(GKH_KeyDown);
            gkh.KeyUp += new EventHandler<KeyEventArgsEx>(GKH_KeyUp);
            gkh.hook();

            lmb.GotFocus += new EventHandler(KI_GotFocus);
            mmb.GotFocus += new EventHandler(KI_GotFocus);
            rmb.GotFocus+=new EventHandler(KI_GotFocus);
            wheel_up.GotFocus+=new EventHandler(KI_GotFocus);
            wheel_down.GotFocus+=new EventHandler(KI_GotFocus);
            up.GotFocus+=new EventHandler(KI_GotFocus);
            left.GotFocus+=new EventHandler(KI_GotFocus);
            down.GotFocus+=new EventHandler(KI_GotFocus);
            right.GotFocus+=new EventHandler(KI_GotFocus);
            activation.GotFocus+=new EventHandler(KI_GotFocus);
            double_click.GotFocus+=new EventHandler(KI_GotFocus);
            drag.GotFocus+=new EventHandler(KI_GotFocus);
            up_left.GotFocus+=new EventHandler(KI_GotFocus);
            up_right.GotFocus+=new EventHandler(KI_GotFocus);
            down_left.GotFocus+=new EventHandler(KI_GotFocus);
            down_right.GotFocus+=new EventHandler(KI_GotFocus);

            lmb.LostFocus += new EventHandler(KI_LostFocus);
            mmb.LostFocus += new EventHandler(KI_LostFocus);
            rmb.LostFocus += new EventHandler(KI_LostFocus);
            wheel_up.LostFocus += new EventHandler(KI_LostFocus);
            wheel_down.LostFocus += new EventHandler(KI_LostFocus);
            up.LostFocus += new EventHandler(KI_LostFocus);
            left.LostFocus += new EventHandler(KI_LostFocus);
            down.LostFocus += new EventHandler(KI_LostFocus);
            right.LostFocus += new EventHandler(KI_LostFocus);
            activation.LostFocus+=new EventHandler(KI_LostFocus);
            double_click.LostFocus+=new EventHandler(KI_LostFocus);
            drag.LostFocus+=new EventHandler(KI_LostFocus);
            up_left.LostFocus+=new EventHandler(KI_LostFocus);
            up_right.LostFocus+=new EventHandler(KI_LostFocus);
            down_left.LostFocus+=new EventHandler(KI_LostFocus);
            down_right.LostFocus+=new EventHandler(KI_LostFocus);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            if (StartMinimized) WindowState = FormWindowState.Minimized;

            click_speed.Value = Exchange.Preference.ClickSpeed;
            double_click_delay.Value = Exchange.Preference.DoubleClickDelay;
            movement_acceleration.Value = Exchange.Preference.MovementAcceleration;
            max_movement_speed.Value = Exchange.Preference.MaxSpeed;
            wheel_acceleration.Value = Exchange.Preference.WheelAcceleration;
            max_wheel_speed.Value = Exchange.Preference.MaxWheelSpeed;

            RunOnStartUp.Checked = IsStartUp();
            ballon_alert.Checked = Exchange.Preference.ShowBallonAlert;
            sound_alert.Checked = Exchange.Preference.PlaySoundAlert;

            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {
            if (StartMinimized) Hide();

            StartMinimized = false;

            base.OnShown(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Simulate)
            {
                //move
                int dx = 0, dy = 0;

                int px = 2, ph = px + KeyState.ih , pv = px + KeyState.iv;

                if (KeyState.Left == ButtonState.Down || KeyState.UpLeft == ButtonState.Down || KeyState.DownLeft == ButtonState.Down) dx -= ph;
                if (KeyState.Right == ButtonState.Down || KeyState.UpRight == ButtonState.Down || KeyState.DownRight == ButtonState.Down) dx += ph;

                if (KeyState.Up == ButtonState.Down || KeyState.UpLeft == ButtonState.Down || KeyState.UpRight == ButtonState.Down) dy -= pv;
                if (KeyState.Down == ButtonState.Down || KeyState.DownLeft == ButtonState.Down || KeyState.DownRight == ButtonState.Down) dy += pv;

                if (dx != 0 || dy != 0)
                {
                    msim.Move(dx, dy);
                }

                //wheel
                int delta = 0;
                int del = 10 + KeyState.iw;

                if (KeyState.WheelUp == ButtonState.Down) delta += del;
                if (KeyState.WheelDown == ButtonState.Down) delta -= del;

                if (delta != 0)
                {
                    msim.Wheel(delta);
                }
            }
            else
            {
                MouseState.LeftButton = ButtonState.Up;
                MouseState.MiddleButton = ButtonState.Up;
                MouseState.RightButton = ButtonState.Up;

                KeyState.Left = ButtonState.Up;
                KeyState.Right = ButtonState.Up;
                KeyState.Up = ButtonState.Up;
                KeyState.Down = ButtonState.Up;
                KeyState.WheelUp = ButtonState.Up;
                KeyState.WheelDown = ButtonState.Up;

                KeyState.ih = 0;
                KeyState.iv = 0;
                KeyState.iw = 0;
            }
        }

        private void GKH_GlobalKeyPress(object sender, EventArgs e)
        {
            Simulate = !Simulate;

            if (Simulate)
            {
                start_button.Text = "Stop (" + Exchange.Preference.Activation.ToString() + ")";
                trayIcon.Icon = Properties.Resources.mouse1;
                trayIcon.Text = "KeyCur is Enabled";
                if (Exchange.Preference.ShowBallonAlert) trayIcon.ShowBalloonTip(1000, "Activated", "KeyCur has been activated", ToolTipIcon.Info);
                activateToolStripMenuItem.Text = "&Deactivate";
                if (Exchange.Preference.PlaySoundAlert)
                {
                    try
                    {
                        Player.SoundLocation = enable_audio;
                        Player.Play();
                    }
                    catch { }
                }
            }
            else
            {
                start_button.Text = "Start (" + Exchange.Preference.Activation.ToString() + ")";
                trayIcon.Icon = Properties.Resources.mouse_inactive;
                trayIcon.Text = "KeyCur is Disabled";
                if (Exchange.Preference.ShowBallonAlert) trayIcon.ShowBalloonTip(1000, "Deactivated", "KeyCur has been deactivated", ToolTipIcon.Info);
                activateToolStripMenuItem.Text = "&Activate";
                if (Exchange.Preference.PlaySoundAlert)
                {
                    try
                    {
                        Player.SoundLocation = disable_audio;
                        Player.Play();
                    }
                    catch { }
                }
            }
        }

        private void GKH_KeyUp(object sender, KeyEventArgsEx e)
        {
            if (gkh.HookForAny)
            {
                mouse_panel.Focus();
                e.Handled = true;
            }
            else
            {
                if (Simulate)
                {
                    if (IsToSimulate(e))
                    {
                        SimulateKeyUp(e);
                        e.Handled = true;
                    }
                }

                if (e.Key == Exchange.Preference.Activation)
                {
                    KeyState.Activation = ButtonState.Up;
                    e.Handled = true;
                }
            }
        }

        private void AssignKey(KeyEventArgsEx e)
        {
            if (e.KeyCode != Keys.Escape)
            {
                if (current.Name != "activation")
                {
                    if (e.Key == Exchange.Preference.Activation)
                    {
                        MessageBox.Show("You may not assign currently assigned activation key for other use, please change the activation key first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                current.Key = e.Key;
                gkh.HookedKeys[KeyInputs.IndexOf(current)] = current.Key;

                foreach (KeyInput ki in KeyInputs)
                {
                    if (ki != current && ki.Key == e.Key)
                    {
                        ki.Key = new ExtendedKey();
                    }
                }

                if(current.Name =="activation")
                {
                    if (Simulate)
                    {
                        start_button.Text = "Stop (" + current.Key.ToString() + ")";
                    }
                    else
                    {
                        start_button.Text = "Start (" + current.Key.ToString() + ")";
                    }
                }

                switch (current.Name)
                {
                    case "lmb": Exchange.Preference.LMB = current.Key; break;
                    case "rmb": Exchange.Preference.RMB = current.Key; break;
                    case "mmb": Exchange.Preference.MMB = current.Key; break;
                    case "wheel_up": Exchange.Preference.WheelUp = current.Key; break;
                    case "wheel_down": Exchange.Preference.WheelDown = current.Key; break;
                    case "left": Exchange.Preference.Left = current.Key; break;
                    case "right": Exchange.Preference.Right = current.Key; break;
                    case "up": Exchange.Preference.Up = current.Key; break;
                    case "down": Exchange.Preference.Down = current.Key; break;
                    case "activation": Exchange.Preference.Activation = current.Key; break;
                    case "double_click": Exchange.Preference.DoubleClick = current.Key; break;
                    case "drag": Exchange.Preference.Drag = current.Key; break;
                    case "up_left": Exchange.Preference.UpLeft = current.Key; break;
                    case "up_right": Exchange.Preference.UpRight = current.Key; break;
                    case "down_left": Exchange.Preference.DownLeft = current.Key; break;
                    case "down_right": Exchange.Preference.DownRight = current.Key; break;
                }

                Exchange.Preference.Save();
            }
        }

        private bool AnyDiagonalDown()
        {
            return (KeyState.UpLeft == ButtonState.Down ||
                KeyState.UpRight == ButtonState.Down ||
                KeyState.DownLeft == ButtonState.Down ||
                KeyState.DownRight == ButtonState.Down);
        }

        private bool AllDiagonalUp()
        {
            return !AnyDiagonalDown();
        }

        private void SimulateKeyDown(KeyEventArgsEx e)
        {
            int max_ma = Exchange.Preference.MaxSpeed;
            int max_wa = Exchange.Preference.MaxWheelSpeed;

            if (e.Key == up_left.Key) KeyState.UpLeft = ButtonState.Down;
            if (e.Key == up_right.Key) KeyState.UpRight = ButtonState.Down;
            if (e.Key == down_left.Key) KeyState.DownLeft = ButtonState.Down;
            if (e.Key == down_right.Key) KeyState.DownRight = ButtonState.Down;

            if (e.Key == left.Key) KeyState.Left = ButtonState.Down;

            if (e.Key == right.Key) KeyState.Right = ButtonState.Down;

            if (KeyState.Left == ButtonState.Down || KeyState.Right == ButtonState.Down || AnyDiagonalDown())
            {
                KeyState.ih+= Exchange.Preference.MovementAcceleration;
                if (KeyState.ih > max_ma) KeyState.ih = max_ma;
            }

            if (e.Key == up.Key) KeyState.Up = ButtonState.Down;

            if (e.Key == down.Key) KeyState.Down = ButtonState.Down;

            if (KeyState.Up == ButtonState.Down || KeyState.Down == ButtonState.Down || AnyDiagonalDown())
            {
                KeyState.iv += Exchange.Preference.MovementAcceleration;
                if (KeyState.iv > max_ma) KeyState.iv = max_ma;
            }

            if (e.Key == wheel_up.Key) KeyState.WheelUp = ButtonState.Down;

            if (e.Key == wheel_down.Key) KeyState.WheelDown = ButtonState.Down;

            if (KeyState.WheelUp == ButtonState.Down || KeyState.WheelDown == ButtonState.Down)
            {
                KeyState.iw += Exchange.Preference.WheelAcceleration;
                if (KeyState.iw > max_wa) KeyState.iw = max_wa;
            }

            if (e.Key == lmb.Key && MouseState.LeftButton != ButtonState.Down)
            {
                msim.ButtonDown(Buttons.LMB);
                MouseState.LeftButton = ButtonState.Down;
            }

            if (e.Key == rmb.Key && MouseState.RightButton != ButtonState.Down)
            {
                msim.ButtonDown(Buttons.RMB);
                MouseState.RightButton = ButtonState.Down;
            }

            if (e.Key == mmb.Key && MouseState.MiddleButton != ButtonState.Down)
            {
                msim.ButtonDown(Buttons.MMB);
                MouseState.MiddleButton = ButtonState.Down;
            }

            if (e.Key == Exchange.Preference.Drag && KeyState.Drag == ButtonState.Up)
            {
                if (MouseState.LeftButton == ButtonState.Up)
                {
                    msim.ButtonDown(Buttons.LMB);
                    MouseState.LeftButton = ButtonState.Down;
                }
                else if(MouseState.LeftButton == ButtonState.Down)
                {
                    msim.ButtonUp(Buttons.LMB);
                    MouseState.LeftButton = ButtonState.Up;
                }

                KeyState.Drag = ButtonState.Down;
            }

            if (e.Key == Exchange.Preference.DoubleClick && KeyState.DoubleClick == ButtonState.Up)
            {
                KeyState.DoubleClick = ButtonState.Down;

                msim.ButtonDown(Buttons.LMB);
                System.Threading.Thread.Sleep(Exchange.Preference.ClickSpeed);
                msim.ButtonUp(Buttons.LMB);
                System.Threading.Thread.Sleep(Exchange.Preference.DoubleClickDelay);
                msim.ButtonDown(Buttons.LMB);
                System.Threading.Thread.Sleep(Exchange.Preference.ClickSpeed);
                msim.ButtonUp(Buttons.LMB);
            }
        }

        private void SimulateKeyUp(KeyEventArgsEx e)
        {
            if (e.Key == up_left.Key) KeyState.UpLeft = ButtonState.Up;
            if (e.Key == up_right.Key) KeyState.UpRight = ButtonState.Up;
            if (e.Key == down_left.Key) KeyState.DownLeft = ButtonState.Up;
            if (e.Key == down_right.Key) KeyState.DownRight = ButtonState.Up;

            if (e.Key == left.Key) KeyState.Left = ButtonState.Up;

            if (e.Key == right.Key) KeyState.Right = ButtonState.Up;

            if (KeyState.Left == ButtonState.Up && KeyState.Right == ButtonState.Up && AllDiagonalUp())
            {
                KeyState.ih = 0;
            }

            if (e.Key == up.Key) KeyState.Up = ButtonState.Up;

            if (e.Key == down.Key) KeyState.Down = ButtonState.Up;

            if (KeyState.Up == ButtonState.Up && KeyState.Down == ButtonState.Up && AllDiagonalUp())
            {
                KeyState.iv = 0;
            }

            if (e.Key == wheel_up.Key) KeyState.WheelUp = ButtonState.Up;

            if (e.Key == wheel_down.Key) KeyState.WheelDown = ButtonState.Up;

            if (KeyState.WheelUp == ButtonState.Up && KeyState.Down == ButtonState.Up)
            {
                KeyState.iw = 0;
            }

            if (e.Key == lmb.Key && MouseState.LeftButton != ButtonState.Up)
            {
                msim.ButtonUp(Buttons.LMB);
                MouseState.LeftButton = ButtonState.Up;
            }

            if (e.Key == rmb.Key && MouseState.RightButton != ButtonState.Up)
            {
                msim.ButtonUp(Buttons.RMB);
                MouseState.RightButton = ButtonState.Up;
            }

            if (e.Key == mmb.Key && MouseState.MiddleButton != ButtonState.Up)
            {
                msim.ButtonUp(Buttons.MMB);
                MouseState.MiddleButton = ButtonState.Up;
            }

            if (e.Key == Exchange.Preference.DoubleClick)
            {
                KeyState.DoubleClick = ButtonState.Up;
            }

            if (e.Key == Exchange.Preference.Drag)
            {
                KeyState.Drag = ButtonState.Up;
            }
        }

        private bool IsToSimulate(KeyEventArgsEx e)
        {
            foreach(KeyInput KI in KeyInputs)
                if(e.Key == KI.Key)return true;
            return false;
        }

        private void GKH_KeyDown(object sender, KeyEventArgsEx e)
        {
            if (gkh.HookForAny)
            {
                AssignKey(e);
                e.Handled = true;
            }
            else
            {
                if (Simulate)
                {
                    if (IsToSimulate(e))
                    {
                        SimulateKeyDown(e);
                        e.Handled = true;
                    }
                }

                if (e.Key == Exchange.Preference.Activation && KeyState.Activation == ButtonState.Up)
                {
                    GKH_GlobalKeyPress(this, new EventArgs());
                    KeyState.Activation = ButtonState.Down;
                    e.Handled = true;
                }
            }
        }

        private void KI_GotFocus(object sender, EventArgs e)
        {
            gkh.HookForAny = true;
            current = sender as KeyInput;
        }

        private void KI_LostFocus(object sender, EventArgs e)
        {
            gkh.HookForAny = false;
            current = null;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            WindowState = FormWindowState.Minimized;

            base.OnClosing(e);
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to exit KeyCur?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                gkh.unhook();
                timer.Stop();
                Application.Exit();
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            GKH_GlobalKeyPress(this, e);
        }

        private void mouse_panel_Click(object sender, EventArgs e)
        {
            mouse_panel.Focus();
        }

        private void Configure_Click(object sender, EventArgs e)
        {
            mouse_panel.Focus();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        #region Input Interactions

        private string GetStartUpPath()
        {
            return Application.ExecutablePath + " /minimized";
        }

        private void click_speed_ValueChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.ClickSpeed != (int)click_speed.Value)
            {
            Exchange.Preference.ClickSpeed = (int)click_speed.Value;
            Exchange.Preference.Save();
            }
        }

        private void double_click_delay_ValueChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.DoubleClickDelay != (int)double_click_delay.Value)
            {
                Exchange.Preference.DoubleClickDelay = (int)double_click_delay.Value;
                Exchange.Preference.Save();
            }
        }

        private void movement_acceleration_ValueChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.MovementAcceleration != (int)movement_acceleration.Value)
            {
                Exchange.Preference.MovementAcceleration = (int)movement_acceleration.Value;
                Exchange.Preference.Save();
            }
        }

        private void max_movement_speed_ValueChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.MaxSpeed != (int)max_movement_speed.Value)
            {
                Exchange.Preference.MaxSpeed = (int)max_movement_speed.Value;
                Exchange.Preference.Save();
            }
        }

        private void wheel_acceleration_ValueChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.WheelAcceleration != (int)wheel_acceleration.Value)
            {
                Exchange.Preference.WheelAcceleration = (int)wheel_acceleration.Value;
                Exchange.Preference.Save();
            }
        }

        private void max_wheel_speed_ValueChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.MaxWheelSpeed != (int)max_wheel_speed.Value)
            {
                Exchange.Preference.MaxWheelSpeed = (int)max_wheel_speed.Value;
                Exchange.Preference.Save();
            }
        }

        private void ballon_alert_CheckedChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.ShowBallonAlert != ballon_alert.Checked)
            {
                Exchange.Preference.ShowBallonAlert = ballon_alert.Checked;
                Exchange.Preference.Save();
            }
        }

        private void sound_alert_CheckedChanged(object sender, EventArgs e)
        {
            if (Exchange.Preference.PlaySoundAlert != sound_alert.Checked)
            {
                Exchange.Preference.PlaySoundAlert = sound_alert.Checked;
                Exchange.Preference.Save();
            }
        }

        #endregion
    }
}
