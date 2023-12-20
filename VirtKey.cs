using System;
using System.Collections.Generic;

using static VirtKey;

[Flags]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1069:Enums values should not be duplicated")]
enum VirtKey : ushort
{
    IS_EXTENDED = 1 << 8,
    BASE_VK_MASK = 0xFF,

    LBUTTON = 0x01,
    RBUTTON = 0x02,
    CANCEL = 0x03,
    MBUTTON = 0x04,
    XBUTTON1 = 0x05,
    XBUTTON2 = 0x06,
    // 0x07 reserved
    BACK = 0x08,
    TAB = 0x09,
    // 0x0A-0X0B reserved 
    CLEAR = 0x0C,
    RETURN = 0x0D,
    // 0x0E-0X0F unassigned
    SHIFT = 0x10,
    CONTROL = 0x11,
    MENU = 0x12,
    ALT = 0x12,
    PAUSE = 0x13,
    CAPITAL = 0x14,

    KANA = 0x15,
    HANGUL = 0x15,
    IME_ON = 0x16,
    JUNJA = 0x17,
    FINAL = 0x18,
    HANJA = 0x19,
    KANJI = 0x19,
    IME_OFF = 0x1A,
    ESCAPE = 0x1B,

    CONVERT = 0x1C,
    NONCONVERT = 0x1D,
    ACCEPT = 0x1E,
    MODECHANGE = 0x1F,

    SPACE = 0x20,
    PRIOR = 0x21,
    NEXT = 0x22,
    END = 0x23,
    HOME = 0x24,
    LEFT = 0x25,
    UP = 0x26,
    RIGHT = 0x27,
    DOWN = 0x28,
    SELECT = 0x29,
    PRINT = 0x2A,
    EXECUTE = 0x2B,
    SNAPSHOT = 0x2C,
    INSERT = 0x2D,
    DELETE = 0x2E,
    HELP = 0x2F,

    _0 = 0x30,
    _1 = 0x31,
    _2 = 0x32,
    _3 = 0x33,
    _4 = 0x34,
    _5 = 0x35,
    _6 = 0x36,
    _7 = 0x37,
    _8 = 0x38,
    _9 = 0x39,

    // 0x3A-0x40 Undefined

    A = 0x41,
    B = 0x42,
    C = 0x43,
    D = 0x44,
    E = 0x45,
    F = 0x46,
    G = 0x47,
    H = 0x48,
    I = 0x49,
    J = 0x4A,
    K = 0x4B,
    L = 0x4C,
    M = 0x4D,
    N = 0x4E,
    O = 0x4F,
    P = 0x50,
    Q = 0x51,
    R = 0x52,
    S = 0x53,
    T = 0x54,
    U = 0x55,
    V = 0x56,
    W = 0x57,
    X = 0x58,
    Y = 0x59,
    Z = 0x5A,

    LWIN = 0x5B,
    RWIN = 0x5C,
    APPS = 0x5D,
    // 0x5E Reserved
    SLEEP = 0x5F,

    NUMPAD0 = 0x60,
    NUMPAD1 = 0x61,
    NUMPAD2 = 0x62,
    NUMPAD3 = 0x63,
    NUMPAD4 = 0x64,
    NUMPAD5 = 0x65,
    NUMPAD6 = 0x66,
    NUMPAD7 = 0x67,
    NUMPAD8 = 0x68,
    NUMPAD9 = 0x69,
    MULTIPLY = 0x6A,
    ADD = 0x6B,
    SEPARATOR = 0x6C,
    SUBTRACT = 0x6D,
    DECIMAL = 0x6E,
    DIVIDE = 0x6F,

    F1 = 0x70,
    F2 = 0x71,
    F3 = 0x72,
    F4 = 0x73,
    F5 = 0x74,
    F6 = 0x75,
    F7 = 0x76,
    F8 = 0x77,
    F9 = 0x78,
    F10 = 0x79,
    F11 = 0x7A,
    F12 = 0x7B,
    F13 = 0x7C,
    F14 = 0x7D,
    F15 = 0x7E,
    F16 = 0x7F,
    F17 = 0x80,
    F18 = 0x81,
    F19 = 0x82,
    F20 = 0x83,
    F21 = 0x84,
    F22 = 0x85,
    F23 = 0x86,
    F24 = 0x87,

    // 0x88-0x8F reserved

    NUMLOCK = 0x90,
    SCROLL = 0x91,

    // 0x92-0x96 OEM specific
    // 0x97-0x9F unassigned

    LSHIFT = 0xA0,
    RSHIFT = 0xA1,
    LCONTROL = 0xA2,
    RCONTROL = 0xA3,

    LMENU = 0xA4,
    LALT = 0xA4,
    RMENU = 0xA5,
    RALT = 0xA5,

    BROWSER_BACK = 0xA6,
    BROWSER_FORWARD = 0xA7,
    BROWSER_REFRESH = 0xA8,
    BROWSER_STOP = 0xA9,
    BROWSER_SEARCH = 0xAA,
    BROWSER_FAVORITES = 0xAB,
    BROWSER_HOME = 0xAC,

    VOLUME_MUTE = 0xAD,
    VOLUME_DOWN = 0xAE,
    VOLUME_UP = 0xAF,
    MEDIA_NEXT_TRACK = 0xB0,
    MEDIA_PREV_TRACK = 0xB1,
    MEDIA_STOP = 0xB2,
    MEDIA_PLAY_PAUSE = 0xB3,
    LAUNCH_MAIL = 0xB4,
    LAUNCH_MEDIA_SELECT = 0xB5,
    LAUNCH_APP1 = 0xB6,
    LAUNCH_APP2 = 0xB7,

    // 0xB8-0xB9 reserved

    OEM_1 = 0xBA,
    OEM_PLUS = 0xBB,
    OEM_COMMA = 0xBC,
    OEM_MINUS = 0xBD,
    OEM_PERIOD = 0xBE,
    OEM_2 = 0xBF,
    OEM_3 = 0xC0,

    // 0xC1-0xDA Reserved

    OEM_4 = 0xDB,
    OEM_5 = 0xDC,
    OEM_6 = 0xDD,
    OEM_7 = 0xDE,
    OEM_8 = 0xDF,
    // 0xE0 Reserved  
    // 0xE1 OEM specific
    OEM_102 = 0xE2,

    // 0xE3-0xE4 OEM specific

    PROCESSKEY = 0xE5,
    // 0xE6 OEM specific 
    PACKET = 0xE7,

    // 0xE8 Unassigned
    // 0xE9-0xF5 OEM specific

    ATTN = 0xF6,
    CRSEL = 0xF7,
    EXSEL = 0xF8,
    EREOF = 0xF9,
    PLAY = 0xFA,
    ZOOM = 0xFB,
    NONAME = 0xFC,
    PA1 = 0xFD,
    OEM_CLEAR = 0xFE
}


static class VirtKeyMethods
{
    public static bool IsExtended(this VirtKey vk) => (vk & IS_EXTENDED) != 0;
    public static VirtKey GetBaseVKCode(this VirtKey vk) => vk & BASE_VK_MASK;


    public static bool IsModifier(this VirtKey vk) => modifiers.Contains(vk.GetBaseVKCode());

    public static bool IsLetter(this VirtKey vk) => vk >= A && vk <= Z;

    public static VirtKey RemoveLeftRight(this VirtKey vk)
    {
        if (removeLeftRight.TryGetValue(vk.GetBaseVKCode(), out var newk))
        {
            // IS_EXTENDED bit is cleared on purpose
            return newk;
        }
        else
        {
            return vk;
        }
    }

    readonly static Dictionary<VirtKey, VirtKey> removeLeftRight = new() {
        {LALT,ALT},
        {LCONTROL,CONTROL},
        {LSHIFT,SHIFT},
        {RALT,ALT},
        {RCONTROL,CONTROL},
        {RSHIFT,SHIFT},
        {RWIN, LWIN},
        {LWIN, LWIN}, // this clears Extended bit
    };

    public static string GetKeyName(this VirtKey vk)
    {
        if (!keyNames.TryGetValue(vk, out var name)
            && !keyNames.TryGetValue(vk.GetBaseVKCode(), out name))
        {
            name = $"UNKNOWN_{(int)vk:X}";
        }

        return name;
    }

    readonly static HashSet<VirtKey> modifiers = [
        ALT,
        CONTROL,
        SHIFT,
        LALT,
        LCONTROL,
        LSHIFT,
        LWIN,
        RALT,
        RCONTROL,
        RSHIFT,
        RWIN
    ];

    readonly static Dictionary<VirtKey, string> keyNames = new()
    {
        {LBUTTON, "Left Mouse"},
        {RBUTTON, "Right Mouse"},
        {CANCEL, "Ctrl-Break"},
        {MBUTTON, "Middle Mouse"},
        {XBUTTON1, "X1 Mouse"},
        {XBUTTON2, "X2 Mouse"},
        {BACK, "Backspace"},
        {TAB, "Tab"},
        {CLEAR, "Clear"},
        {RETURN, "Enter"},
        {RETURN | IS_EXTENDED, "Numpad Enter"},
        {SHIFT, "Shift"},
        {CONTROL, "Ctrl"},
        {MENU, "Alt"},
        {PAUSE, "Pause"},
        {CAPITAL, "Caps Lock"},
        {KANA, "IME Kana/Hangul"},
        {JUNJA, "IME Junja"},
        {FINAL, "IME Final"},
        {HANJA, "IME Hanja/Kanji"},
        {ESCAPE, "Esc"},
        {CONVERT, "IME Convert"},
        {NONCONVERT, "IME Nonconvert"},
        {ACCEPT, "IME Accept"},
        {MODECHANGE, "IME Mode Change"},
        {SPACE, "Spacebar"},
        {PRIOR, "Page Up"},
        {NEXT, "Page Down"},
        {END, "End"},
        {HOME, "Home"},
        {LEFT, "Left Arrow"},
        {UP, "Up Arrow"},
        {RIGHT, "Right Arrow"},
        {DOWN, "Down Arrow"},
        {SELECT, "Select"},
        {PRINT, "Print"},
        {EXECUTE, "Execute"},
        {SNAPSHOT, "Print Screen"},
        {INSERT, "Ins"},
        {DELETE, "Del"},
        {HELP, "Help"},
        {_0, "0"},
        {_1, "1"},
        {_2, "2"},
        {_3, "3"},
        {_4, "4"},
        {_5, "5"},
        {_6, "6"},
        {_7, "7"},
        {_8, "8"},
        {_9, "9"},
        {A, "A"},
        {B, "B"},
        {C, "C"},
        {D, "D"},
        {E, "E"},
        {F, "F"},
        {G, "G"},
        {H, "H"},
        {I, "I"},
        {J, "J"},
        {K, "K"},
        {L, "L"},
        {M, "M"},
        {N, "N"},
        {O, "O"},
        {P, "P"},
        {Q, "Q"},
        {R, "R"},
        {S, "S"},
        {T, "T"},
        {U, "U"},
        {V, "V"},
        {W, "W"},
        {X, "X"},
        {Y, "Y"},
        {Z, "Z"},
        {LWIN, "Win"},
        {LWIN | IS_EXTENDED, "Left Win"},
        {RWIN, "Right Win"},
        {APPS, "App"},
        {SLEEP, "Sleep"},
        {NUMPAD0, "Numpad 0"},
        {NUMPAD1, "Numpad 1"},
        {NUMPAD2, "Numpad 2"},
        {NUMPAD3, "Numpad 3"},
        {NUMPAD4, "Numpad 4"},
        {NUMPAD5, "Numpad 5"},
        {NUMPAD6, "Numpad 6"},
        {NUMPAD7, "Numpad 7"},
        {NUMPAD8, "Numpad 8"},
        {NUMPAD9, "Numpad 9"},
        {MULTIPLY, "Numpad *"},
        {ADD, "Numpad +"},
        {SEPARATOR, "Separator"},
        {SUBTRACT, "Numpad -"},
        {DECIMAL, "Numpad ."},
        {DIVIDE, "Numpad /"},
        {F1, "F1"},
        {F2, "F2"},
        {F3, "F3"},
        {F4, "F4"},
        {F5, "F5"},
        {F6, "F6"},
        {F7, "F7"},
        {F8, "F8"},
        {F9, "F9"},
        {F10, "F10"},
        {F11, "F11"},
        {F12, "F12"},
        {F13, "F13"},
        {F14, "F14"},
        {F15, "F15"},
        {F16, "F16"},
        {F17, "F17"},
        {F18, "F18"},
        {F19, "F19"},
        {F20, "F20"},
        {F21, "F21"},
        {F22, "F22"},
        {F23, "F23"},
        {F24, "F24"},
        {NUMLOCK, "Num Lock"},
        {SCROLL, "Scroll Lock"},
        {LSHIFT, "Left Shift"},
        {RSHIFT, "Right Shift"},
        {LCONTROL, "Left Ctrl"},
        {RCONTROL, "Right Ctrl"},
        {LMENU, "Left Alt"},
        {RMENU, "Right Alt"},
        {BROWSER_BACK, "Browser Back"},
        {BROWSER_FORWARD, "Browser Forward"},
        {BROWSER_REFRESH, "Browser Refresh"},
        {BROWSER_STOP, "Browser Stop"},
        {BROWSER_SEARCH, "Browser Search"},
        {BROWSER_FAVORITES, "Browser Favorites"},
        {BROWSER_HOME, "Browser Home"},
        {VOLUME_MUTE, "Mute"},
        {VOLUME_DOWN, "Volume Down"},
        {VOLUME_UP, "Volume Up"},
        {MEDIA_NEXT_TRACK, "Next Track"},
        {MEDIA_PREV_TRACK, "Previous Track"},
        {MEDIA_STOP, "Stop Media"},
        {MEDIA_PLAY_PAUSE, "Play/Pause Media"},
        {LAUNCH_MAIL, "Start Mail"},
        {LAUNCH_MEDIA_SELECT, "Select Media"},
        {LAUNCH_APP1, "Start App 1"},
        {LAUNCH_APP2, "Start App 2"},
        {OEM_1, ";"},
        {OEM_PLUS, "="},
        {OEM_COMMA, ","},
        {OEM_MINUS, "-"},
        {OEM_PERIOD, "."},
        {OEM_2, "/"},
        {OEM_3, "`"},
        {OEM_4, "["},
        {OEM_5, "\\"},
        {OEM_6, "]"},
        {OEM_7, "'"},
        {OEM_8, "Misc"},
        {OEM_102, "`<>` or `\\|`"},
        {PROCESSKEY, "IME Process"},
        {PACKET, "Unicode Keystroke"},
        {ATTN, "Attn"},
        {CRSEL, "CrSel"},
        {EXSEL, "ExSel"},
        {EREOF, "Erase EOF"},
        {PLAY, "Play"},
        {ZOOM, "Zoom"},
        {NONAME, "Reserved"},
        {PA1, "PA1"},
        {OEM_CLEAR, "Clear"}
    };
}