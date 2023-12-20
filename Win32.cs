using System;
using System.Runtime.InteropServices;

static partial class Win32
{
    #region Message Loop

    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public uint message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public int ptX; // X coordinate of the point
        public int ptY; // Y coordinate of the point
    }

    [LibraryImport("user32.dll", EntryPoint = "GetMessageW")]
    public static partial int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

    [LibraryImport("user32.dll", EntryPoint = "TranslateMessageW")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool TranslateMessage(ref MSG lpMsg);

    [LibraryImport("user32.dll", EntryPoint = "DispatchMessageW")]
    public static partial IntPtr DispatchMessage(ref MSG lpmsg);

    #endregion

    #region Keyboard Hook

    public const int WM_KEYDOWN = 0x100;
    public const int WM_KEYUP = 0x101;
    public const int WM_SYSKEYDOWN = 0x104;
    public const int WM_SYSKEYUP = 0x105;

    public const int WH_KEYBOARD_LL = 13;

    public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    public class KBDLLHOOKSTRUCT
    {
        [Flags]
        public enum FLAGS : uint
        {
            None = 0,
            EXTENDED = 0x0001,
            LOWER_IL_INJECTED = 0x0002,
            INJECTED = 0x0010,
            ALTDOWN = 0x0020,
            UP = 0x0080,
        }

        public int vkCode;
        public int scanCode;
        public FLAGS flags;
        public uint time;
        public UIntPtr dwExtraInfo;
    }

    [LibraryImport("user32.dll", EntryPoint = "SetWindowsHookExW", SetLastError = true)]
    public static partial IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hmod, uint dwThreadId);

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool UnhookWindowsHookEx(IntPtr hhk);

    [LibraryImport("user32.dll", SetLastError = true)]
    public static partial IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [LibraryImport("kernel32.dll", EntryPoint = "GetModuleHandleW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial IntPtr GetModuleHandle(string lpModuleName);

    #endregion
}
