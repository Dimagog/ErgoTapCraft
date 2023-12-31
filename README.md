# ErgoTapCraft

Friendly key logger for yourself.

## Overview

ErgoTapCraft is an application designed for enthusiasts of programmable/ergonomic mechanical keyboards.
It helps to collect and analyze your personal keystrokes data to assist in creation of customized keyboard
layouts tailored for you, that optimize comfort and efficiency.

## Features

### Keystroke Collection

Collects all keys and key combos that you are pressing while working into a simple text file.

### Keystroke Analytics

Analyze every key press to gain insights into your typing habits. Helps answering questions like:

- **Which keys am I pressing most often?**
  Then you can move these keys into most ergonomic positions like main layer and thumb cluster.
- **Do I press them alone or as part of combos?** Helps with configuring tap dances for most frequent ones.
- *[future feature] Which 2 and 3 key sequences are so common that maybe I should create macros for them?*

### Data Privacy

Your data stays on your device. ErgoTapCraft is committed to privacy and does not function as spyware.

### Compatibility

Windows-only

## Why ErgoTapCraft?

ErgoTapCraft is not just another keylogger. It's a specialized tool for keyboard enthusiasts who want to
delve into the ergonomics of typing. Whether you're a programmer, writer, or gaming aficionado,
ErgoTapCraft helps you design a keyboard that fits your hands and habits perfectly.

## Getting Started

To get started with ErgoTapCraft:

1. **Install the Application** from [Releases](https://github.com/Dimagog/ErgoTapCraft/releases) or build it yourself with `dotnet publish`.
2. **Run**: `ErgoTapCraft >>mykeys.log`
3. **Start Typing**: Just use your keyboard as you normally would and collect enough data to analyze.
4. **Analyze** Use provided .nu scripts (requires [NuShell](https://www.nushell.sh/)), or write your own.
5. **Customize your keyboard layout**: Use the insights provided to craft your perfect keyboard layout.
6. **Repeat**: as you keep running ErgoTapCraft and collect more and more data you get additional insights.

> [!CAUTION]
> **Important Note On Protecting Passwords**
>
> As you keep working and collecting all of your keystrokes you will sometimes type passwords.
> And even though the collected data always stays on your PC, you probably don't want your passwords
> in a plain text file.
>
> There are 2 mechanisms for protecting your passwords:
>
> 1. Pressing ScrollLock temporarily suspends data collection. This is on by default.
> 2. Not logging letters at all. More secure, but less data is collected.
>
> See `--pp` option in Usage section below.

## Usage for data collection

```text
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

```

## Usage of data analysis scripts

> [!IMPORTANT]
> [Install NuShell first](https://www.nushell.sh/book/installation.html)

> [!TIP]
> You don't have to stop data collection (exit `ErgoTapCraft.exe`) to run the queries below.
> Just keep it running.

### Which keys am I pressing most often (by themselves or as part of combos)?

These keys are good candidates for premium locations like base layer and thumb cluster.

```nushell
nu Stats.nu -s mykeys.log
```

```text
╭────┬──────────────┬────────────┬────────────┬────────────┬──────────╮
│  # │     key      │ totalCount │ aloneCount │ comboCount │ comboPer │
├────┼──────────────┼────────────┼────────────┼────────────┼──────────┤
│  0 │ Shift        │       3062 │         80 │       2982 │    97.39 │
│  1 │ Ctrl         │       2911 │         97 │       2814 │    96.67 │
│  2 │ Backspace    │       2561 │       2356 │        205 │     8.00 │
│  3 │ Spacebar     │       2107 │       1998 │        109 │     5.17 │
│  4 │ Down Arrow   │       1932 │       1591 │        341 │    17.65 │
│  5 │ Up Arrow     │       1757 │       1703 │         54 │     3.07 │
│  6 │ Enter        │       1640 │       1592 │         48 │     2.93 │
│  7 │ Right Arrow  │       1192 │        721 │        471 │    39.51 │
│  8 │ Left Arrow   │       1166 │        726 │        440 │    37.74 │
│  9 │ Esc          │       1117 │       1096 │         21 │     1.88 │
│ 10 │ Del          │        850 │        575 │        275 │    32.35 │
│ 11 │ Tab          │        739 │        517 │        222 │    30.04 │
│ 12 │ Alt          │        524 │         20 │        504 │    96.18 │
...
```

### Which key combos am I pressing most often?

These are good candidates for tap dances.

```nushell
nu -c "use Stats.nu; Stats --trsh mykeys.log | where key =~ ' \+ '"
```

```text
╭────┬────────────────────────────┬───────┬──────────┬────────────┬───────────╮
│  # │            key             │ count │ quantile │ percentage │ frequency │
├────┼────────────────────────────┼───────┼──────────┼────────────┼───────────┤
│  0 │ Ctrl + Left Arrow          │   369 │     0.02 │ 1.61%      │ *         │
│  1 │ Ctrl + Right Arrow         │   337 │     0.01 │ 1.47%      │ *         │
│  2 │ Shift + Down Arrow         │   273 │     0.01 │ 1.19%      │ *         │
│  3 │ Ctrl + Z                   │   249 │     0.01 │ 1.09%      │ *         │
│  4 │ Ctrl + Backspace           │   186 │     0.01 │ 0.81%      │           │
│  5 │ Shift + Del                │   186 │     0.01 │ 0.81%      │           │
│  6 │ Ctrl + `                   │   171 │     0.01 │ 0.75%      │           │
│  7 │ Alt + Tab                  │   170 │     0.01 │ 0.74%      │           │
│  8 │ Ctrl + S                   │   136 │     0.01 │ 0.59%      │           │
│  9 │ Ctrl + C                   │   121 │     0.01 │ 0.53%      │           │
│ 10 │ Ctrl + V                   │   120 │     0.01 │ 0.52%      │           │
│ 11 │ Ctrl + E                   │   101 │     0.00 │ 0.44%      │           │
│ 12 │ Shift + Ins                │    93 │     0.00 │ 0.41%      │           │
│ 13 │ Shift + Ctrl + Right Arrow │    85 │     0.00 │ 0.37%      │           │
│ 14 │ Ctrl + D                   │    74 │     0.00 │ 0.32%      │           │
...
```

### Which keys am I using almost exclusively in combos?

These are also good candidates for tap dances, plus the keys themselves can be demoted from premium locations.

After running command below, you can look these keys up in table above to see which combos
contain these keys, or see the next section.

```nushell
nu MostlyCombos.nu E:\KMonad\mykeys.log
```

```text
╭────┬───────────┬────────────┬────────────┬────────────┬──────────╮
│  # │    key    │ totalCount │ aloneCount │ comboCount │ comboPer │
├────┼───────────┼────────────┼────────────┼────────────┼──────────┤
│  0 │ Ins       │        160 │         20 │        140 │    87.50 │
│  1 │ `         │        222 │         49 │        173 │    77.93 │
│  2 │ F5        │        105 │         44 │         61 │    58.10 │
│  3 │ 1         │         97 │         58 │         39 │    40.21 │
│  4 │ Page Up   │         88 │         55 │         33 │    37.50 │
│  5 │ Del       │        850 │        575 │        275 │    32.35 │
│  6 │ Tab       │        740 │        518 │        222 │       30 │
...
```

### How am I using a particular key?

Here is an example for `Ins` key:
```nushell
nu -c "use Stats.nu; Stats mykeys.log | where key =~ '\bIns'"
```
```text
╭───┬─────────────┬───────┬──────────┬────────────┬───────────╮
│ # │     key     │ count │ quantile │ percentage │ frequency │
├───┼─────────────┼───────┼──────────┼────────────┼───────────┤
│ 0 │ Shift + Ins │    93 │     0.00 │ 0.39%      │           │
│ 1 │ Ctrl + Ins  │    46 │     0.00 │ 0.20%      │           │
│ 2 │ Ins         │    20 │     0.00 │ 0.08%      │           │
╰───┴─────────────┴───────┴──────────┴────────────┴───────────╯
```

## License

MIT

## Disclaimer

All pompous readme sections are written by ChatGPT.
