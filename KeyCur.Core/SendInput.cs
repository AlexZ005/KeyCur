using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KeyCur
{
    [Flags]
    internal enum INPUTTYPE : uint
    {
        MOUSE = 0,
        KEYBOARD = 1,
        HARDWARE = 2
    }

    [Flags]
    internal enum MOUSEEVENTF : uint
    {
        MOVE = 0x1,  // mouse move
        LEFTDOWN = 0x2,  // left button down
        LEFTUP = 0x4, // left button up
        RIGHTDOWN = 0x8,  // right button down
        RIGHTUP = 0x10, // right button up
        MIDDLEDOWN = 0x20, // middle button down
        MIDDLEUP = 0x40,  // middle button up
        XDOWN = 0x80,  // x button down
        XUP = 0x100,  // x button down
        WHEEL = 0x800, // wheel button rolled
        HWHEEL = 0x1000,  // hwheel button rolled
        MOVE_NOCOALESCE = 0x2000,  // do not coalesce mouse moves
        VIRTUALDESK = 0x4000,  // map to entire virtual desktop
        ABSOLUTE = 0x8000  // absolute move
    }

    [Flags]
    internal enum KEYEVENTF : uint
    {
        EXTENDEDKEY = 0x1,
        KEYUP = 0x2,
        UNICODE = 0x4,
        SCANCODE = 0x8
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        public Int32 uMsg;
        public Int16 wParamL;
        public Int16 wParamH;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        public Int16 wVk;
        public Int16 wScan;
        public KEYEVENTF dwFlags;
        public UInt32 time;
        public UIntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        public Int32 dx;
        public Int32 dy;
        public Int32 mouseData;
        public MOUSEEVENTF dwFlags;
        public UInt32 time;
        public UIntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct INPUT
    {
        public INPUTTYPE dwType;

        public UnionTag union;

        [StructLayout(LayoutKind.Explicit)]
        public struct UnionTag
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
    }
}
