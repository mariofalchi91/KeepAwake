# KeepAwake

A lightweight Windows console application that prevents your computer from sleeping or locking while running.

## Description

KeepAwake is a simple utility designed to keep your computer awake by:
- Preventing the display from turning off
- Preventing the system from entering sleep mode
- Simulating periodic keyboard input (F15 key presses every 5 minutes)

This is useful when you need to maintain an active session without user interaction for extended periods, such as during long-running processes, file downloads, or presentations.

## Features

- **System-wide keep awake**: Uses Windows API to maintain system execution state
- **Display lock prevention**: Keeps the display on while running
- **Periodic key simulation**: Sends F15 key presses every 5 minutes to maintain activity
- **Simple interface**: Minimalist console application with clear status messages
- **Easy to use**: Just run the application and press Enter to exit

## Requirements

- Windows operating system (uses Windows-specific APIs: `kernel32.dll` and `user32.dll`)
- .NET 10 or later

## Building

```bash
dotnet build
```

## Running

```bash
dotnet run
```

The application will start keeping your system awake and display:
```
Keep Awake is running. Press enter to exit...
```

It will periodically log when it presses the F15 key:
```
[14:23:45] F15 key pressed to keep awake.
[14:28:45] F15 key pressed to keep awake.
```

Press Enter in the console window to stop the application.

## How It Works

The application uses two key Windows API functions:

1. **SetThreadExecutionState** (`kernel32.dll`): Sets the system execution state to prevent sleep and keep the display on
2. **keybd_event** (`user32.dll`): Simulates keyboard input by sending F15 key press and release events

A timer triggers the F15 key simulation every 5 minutes (300,000 milliseconds) to maintain system activity.

## Technical Details

- **Language**: C#
- **Framework**: .NET 10
- **Platform**: Windows only (uses platform-specific P/Invoke calls)
- **Type**: Console Application

## Usage Notes

- The application runs in the foreground and requires the console window to remain open
- Closing the console window or pressing Enter will stop the keep-awake functionality
- The F15 key is used because it's a relatively neutral key that rarely conflicts with application functionality
- Works with any Windows application or system state

## License

[Add your license information here]

## Contributing

[Add contribution guidelines here]
