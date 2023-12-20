using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

readonly record struct KeyEvent(bool KeyDown, VirtKey VKey)
{
    public bool KeyUp => !KeyDown;
}

class KeyboardEventWatcher : IDisposable
{
    readonly IWriteChannel<KeyEvent> ch;
    IntPtr hookHandle;

    public KeyboardEventWatcher(IWriteChannel<KeyEvent> ch)
    {
        this.ch = ch;

        using Process curProcess = Process.GetCurrentProcess();
        using ProcessModule curModule = curProcess.MainModule!;
        hookHandle = Win32.SetWindowsHookEx(Win32.WH_KEYBOARD_LL, LowLevelKeyboardCallback, Win32.GetModuleHandle(curModule.ModuleName), 0);
    }

    ~KeyboardEventWatcher()
    {
        Dispose();
    }

    public void Dispose()
    {
        Win32.UnhookWindowsHookEx(hookHandle);
        hookHandle = IntPtr.Zero;

        GC.SuppressFinalize(this);
    }

    IntPtr LowLevelKeyboardCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            var keyUpDown = (int)wParam;
            bool writeEvent;
            bool keyDown = default;
            switch (keyUpDown)
            {
                case Win32.WM_KEYUP:
                case Win32.WM_SYSKEYUP:
                    keyDown = false;
                    writeEvent = true;
                    break;
                case Win32.WM_KEYDOWN:
                case Win32.WM_SYSKEYDOWN:
                    keyDown = true;
                    writeEvent = true;
                    break;
                default:
                    writeEvent = false;
                    break;
            }

            if (writeEvent)
            {
                var kbdStruct = (Win32.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32.KBDLLHOOKSTRUCT))!;
                VirtKey extKey = (VirtKey)kbdStruct.vkCode;
                if ((kbdStruct.flags & Win32.KBDLLHOOKSTRUCT.FLAGS.EXTENDED) != 0)
                {
                    extKey |= VirtKey.IS_EXTENDED;
                }
                ch.Write(new KeyEvent(keyDown, extKey));
            }
        }

        return Win32.CallNextHookEx(hookHandle, nCode, wParam, lParam);
    }
}
