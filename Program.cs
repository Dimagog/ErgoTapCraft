using DocoptNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

static class Program
{
    static void HumanLogger(IEnumerable<KeyEvent> events)
    {
        Stopwatch lastEvent = new Stopwatch();
        foreach (var evt in events)
        {
            var key = evt.VKey;
            var humanKey = key.GetKeyName();
            var baseCode = key.GetBaseVKCode();
            Console.WriteLine($"{(evt.KeyDown ? '+' : '-')} {humanKey,-12} vkCode={(int)baseCode:x2}, VT_{baseCode,-10} extended={key.IsExtended()}, timeDelta={lastEvent.ElapsedMilliseconds}");
            lastEvent.Restart();
        }
    }

    static void CombosLogger(IEnumerable<KeyEvent> events)
    {
        static void LogKeys(IEnumerable<VirtKey> keys)
        {
            var keyNames = keys.Select(k => k.GetKeyName());
            Console.WriteLine(string.Join(" + ", keyNames));
        }

        HashSet<VirtKey> pressedModifiers = [];
        bool hadRealKey = false;
        int maxKeysPressed = 0;
        foreach (var evt in events)
        {
            var key = evt.VKey;
            var isModifier = key.IsModifier();

            if (evt.KeyDown)
            {
                if (isModifier)
                {
                    pressedModifiers.Add(key);
                    maxKeysPressed = Math.Max(maxKeysPressed, pressedModifiers.Count);
                }
                else
                {
                    hadRealKey = true;
                    maxKeysPressed = Math.Max(maxKeysPressed, pressedModifiers.Count + 1);
                    LogKeys(pressedModifiers.Order().Append(key));
                }
            }
            else if (isModifier)
            {
                bool firstUp = pressedModifiers.Count == maxKeysPressed;

                if (!hadRealKey && firstUp)
                {
                    LogKeys(pressedModifiers.Order().DefaultIfEmpty(key));
                }

                pressedModifiers.Remove(key);

                if (pressedModifiers.Count == 0)
                {
                    hadRealKey = false;
                    maxKeysPressed = 0;
                }
            }
        }
    }

    static void CSVLogger(IEnumerable<KeyEvent> events)
    {
        foreach (var evt in events)
        {
            var key = evt.VKey;
            Console.WriteLine($"{(evt.KeyDown ? '1' : '0')},{(key.IsExtended() ? '1' : '0')},{(int)key.GetBaseVKCode():X2}");
        }
    }

    public static IEnumerable<T> RemoveConsecutiveDuplicates<T>(
        this IEnumerable<T> source,
        IEqualityComparer<T>? comparer = null)
    {
        comparer ??= EqualityComparer<T>.Default;
        var en = source.GetEnumerator();
        if (!en.MoveNext())
        {
            yield break;
        }

        T prev = en.Current;
        yield return prev;

        while (en.MoveNext())
        {
            var item = en.Current;
            if (!comparer.Equals(prev, item))
            {
                yield return item;
            }

            prev = item;
        }
    }

    public static IEnumerable<KeyEvent> PasswordMode(this IEnumerable<KeyEvent> source)
    {
        const int pauseTimeout = 10000;
        var paused = new Stopwatch();

        foreach (var evt in source)
        {
            if (paused.IsRunning && paused.ElapsedMilliseconds > pauseTimeout)
            {
                paused.Stop();
            }

            if (evt.VKey.GetBaseVKCode() == VirtKey.SCROLL)
            {
                if (evt.KeyUp)
                {
                    if (!paused.IsRunning)
                    {
                        paused.Restart();
                    }
                    else
                    {
                        paused.Stop();
                    }
                }
            }
            else if (!paused.IsRunning)
            {
                yield return evt;
            }
        }
    }

    const string usage = """
        ErgoTapCraft. Friendly key logger for yourself.

        Usage:
          ErgoTapCraft [options]
          ErgoTapCraft -h | --help

        Options:
          -r, --repeats          Keep key repeats when holding a key
          -f, --format=<format>  Should be combos, human or csv [default: combos]
          -l, --lr               Distinguish Left and Right modifier keys
          --pp=<opt1,opt2,...>   Password protection options [default: slp]
                                 A comma-separated list of the following possible options:
                                 slp: Scroll Lock Pause.
                                      Stop logging on Scroll Lock press and resume on another Scroll Lock or after 10 seconds.
                                 nl: No Letters. All English letters (A-Z) are not logged.
                                 WARNING: If you disable all options with `--pp=`, your passwords will be logged as you type them.

          -h, --help             Show this screen.
          --version              Show version.
        """;

    static void Fail(string message)
    {
        Console.WriteLine(usage);
        Console.WriteLine();
        Console.WriteLine(message);
        Environment.Exit(1);
    }

    static void Main(string[] args)
    {
        var opts = new Docopt().Apply(usage, args, version: "1.0", exit: true)!;

        string format = opts["--format"].ToString();
        bool repeats = opts["--repeats"].IsTrue;
        bool lr = opts["--lr"].IsTrue;
        string[] passwordProtections = opts["--pp"].ToString().Split(',');

        Action<IEnumerable<KeyEvent>> logger;
        switch (format)
        {
            case "combos":
                logger = CombosLogger;
                repeats = false;
                break;
            case "human":
                logger = HumanLogger;
                break;
            case "csv":
                logger = CSVLogger;
                break;
            default:
                Fail($"Unsupported format '{format}'");
                logger = CSVLogger; // to make compiler happy that logger is initialized
                break;
        }

        using var ch = new Channel<KeyEvent>();
        IEnumerable<KeyEvent> events = ch;
        if (!repeats)
        {
            events = events.RemoveConsecutiveDuplicates();
        }
        if (!lr)
        {
            events = events.Select(e => new KeyEvent(e.KeyDown, VirtKeyMethods.RemoveLeftRight(e.VKey)));
        }

        foreach (var pp in passwordProtections)
        {
            switch (pp)
            {
                case "slp":
                    events = events.PasswordMode();
                    break;
                case "nl":
                    events = events.Where(e => !e.VKey.IsLetter());
                    break;
                case "":
                    // skip
                    break;
                default:
                    Fail($"Unsupported password protection option '{pp}'");
                    break;
            }
        }

        Task.Run(() => logger(events));

        using var keys = new KeyboardEventWatcher(ch);

        while (Win32.GetMessage(out Win32.MSG msg, IntPtr.Zero, 0, 0) > 0)
        {
            Win32.TranslateMessage(ref msg);
            Win32.DispatchMessage(ref msg);
        }
    }
}
