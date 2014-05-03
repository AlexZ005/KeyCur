using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyCur
{
    public struct MouseState
    {
        public ButtonState LeftButton, MiddleButton, RightButton;
    }

    public struct KeyState
    {
        public ButtonState Left, Right, Up, Down, WheelUp, WheelDown, Activation, DoubleClick, Drag, UpLeft, UpRight, DownLeft, DownRight;

        public int ih, iv, iw;
    }

    public enum ButtonState
    {
        Up,
        Down
    }
}
