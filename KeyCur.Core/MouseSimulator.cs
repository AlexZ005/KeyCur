using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyCur
{
    public class MouseSimulator
    {
        const UInt32 MOUSEEVENTF_ABSOLUTE = 0x8000;
        const UInt32 MOUSEEVENTF_MOVE = 0x1;
        const UInt32 MOUSEEVENTF_LEFTDOWN = 0x2;
        const UInt32 MOUSEEVENTF_LEFTUP = 0x4;
        const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x20;
        const UInt32 MOUSEEVENTF_MIDDLEUP = 0x40;
        const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x8;
        const UInt32 MOUSEEVENTF_RIGHTUP = 0x10;
        const UInt32 MOUSEEVENTF_WHEEL = 0x800;

        [DllImport("user32.dll")]
        static extern void mouse_event(UInt32 dwFlags, int dx, int dy, int dwData, UInt32 dwExtraInfo);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        [DllImport("user32.dll")]
        static extern UInt32 SendInput(UInt32 nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        public void ButtonDown(Buttons button)
        {
            MOUSEEVENTF button_code = MOUSEEVENTF.LEFTDOWN;

            switch (button)
            {
                case Buttons.LMB: button_code = MOUSEEVENTF.LEFTDOWN; break;
                case Buttons.RMB: button_code = MOUSEEVENTF.RIGHTDOWN; break;
                case Buttons.MMB: button_code = MOUSEEVENTF.MIDDLEDOWN; break;
            }

            //mouse_event(button_code, 0, 0, 0, 0);

            INPUT[] inputs = new INPUT[]{new INPUT(){
                dwType = INPUTTYPE.MOUSE,
                 union = new INPUT.UnionTag()
                 {
                      mi=new MOUSEINPUT()
                      {
                           dx=0,
                           dy=0,
                           dwExtraInfo=UIntPtr.Zero,
                           dwFlags= button_code,
                           mouseData=0
                      }
                 }
            }};

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(inputs[0]));
        }

        public void ButtonUp(Buttons button)
        {
            MOUSEEVENTF button_code = MOUSEEVENTF.LEFTUP;

            switch (button)
            {
                case Buttons.LMB: button_code = MOUSEEVENTF.LEFTUP; break;
                case Buttons.RMB: button_code = MOUSEEVENTF.RIGHTUP; break;
                case Buttons.MMB: button_code = MOUSEEVENTF.MIDDLEUP; break;
            }

            //mouse_event(button_code, 0, 0, 0, 0);

            INPUT[] inputs = new INPUT[]{new INPUT(){
                dwType = INPUTTYPE.MOUSE,
                 union = new INPUT.UnionTag()
                 {
                      mi=new MOUSEINPUT()
                      {
                           dx=0,
                           dy=0,
                           dwExtraInfo=UIntPtr.Zero,
                           dwFlags= button_code,
                           mouseData=0
                      }
                 }
            }};

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(inputs[0]));
        }

        public void Wheel(int delta)
        {
            //mouse_event(MOUSEEVENTF_WHEEL, 0, 0, delta, 0);

            INPUT[] inputs = new INPUT[]{new INPUT(){
                dwType = INPUTTYPE.MOUSE,
                 union = new INPUT.UnionTag()
                 {
                      mi=new MOUSEINPUT()
                      {
                           dx=0,
                           dy=0,
                           dwExtraInfo=UIntPtr.Zero,
                           dwFlags= MOUSEEVENTF.WHEEL,
                           mouseData=delta
                      }
                 }
            }};

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(inputs[0]));
        }

        public void Move(int x, int y)
        {
            //mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);

            INPUT[] inputs = new INPUT[]{new INPUT(){
                dwType = INPUTTYPE.MOUSE,
                 union = new INPUT.UnionTag()
                 {
                      mi=new MOUSEINPUT()
                      {
                           dx=x,
                           dy=y,
                           dwExtraInfo=UIntPtr.Zero,
                           dwFlags= MOUSEEVENTF.MOVE,
                           mouseData=0
                      }
                 }
            }};

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(inputs[0]));
        }
    }

    public enum Buttons
    {
        LMB, RMB, MMB
    }
}
