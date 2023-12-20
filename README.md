# ErgoTapCraft

Friendly key logger for yourself.

## Overview

ErgoTapCraft is an application designed for enthusiasts of programmable/ergonomic mechanical keyboards. It helps to collect and analyze your personal keystrokes date to assist in creation of customized keyboard layouts tailored for you, that optimize comfort and efficiency.

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

ErgoTapCraft is not just another keylogger. It's a specialized tool for keyboard enthusiasts who want to delve into the ergonomics of typing. Whether you're a programmer, writer, or gaming aficionado, ErgoTapCraft helps you design a keyboard that fits your hands and habits perfectly.

## Getting Started

To get started with ErgoTapCraft:

1. **Install the Application** From Release or build it yourself with `dotnet publish`.
2. **Run**: `ErgoTapCraft >>mykeys.log`
3. **Start Typing**: Just use your keyboard as you normally would and collect enough data to analyze.
4. **Analyze** Use provided .nu scripts (require `NuShell`), or write your own.
5. **Customize your keyboard layout**: Use the insights provided to craft your perfect keyboard layout.
6. **Repeat**: as you keep running ErgoTapCraft and collect more and more data you get additional insights.

## **IMPORTANT NOTE ON PROTECTING PASSWORDS**

As you keep working and collecting all of your keystrokes you will sometimes type passwords. And even though the collected data always stays on your PC, you probably don't want your passwords in a plain text file.

There are 2 mechanisms for protecting your passwords:

1. Pressing ScrollLock temporarily suspends data collection. This is on by default.
2. Not logging letters at all. More secure, but less data is collected.

See `--pp` option in Usage section below.

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

## License

MIT

## Disclaimer

All pompous sections are written by ChatGPT.
