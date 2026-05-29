using System.Runtime.InteropServices;

namespace KeepAwake;

class Program
{
    [Flags]
    enum ExecutionState : uint
    {
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001
    }

    [DllImport("kernel32.dll")]
    static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    const int VK_F15 = 0x7E;
    const int KEYEVENTF_KEYUP = 0x0002;

    static void Main(string[] args)
    {
        SetThreadExecutionState(ExecutionState.ES_CONTINUOUS | ExecutionState.ES_DISPLAY_REQUIRED | ExecutionState.ES_SYSTEM_REQUIRED);

        Console.WriteLine("Keep Awake is running. Press enter to exit...");

        using Timer timer = new(PressF15, null, 0, 60 * 5 * 1000);
        Console.ReadLine();
    }

    private static void PressF15(object state)
    {
        keybd_event(VK_F15, 0 ,0 , UIntPtr.Zero); // Press F15
        keybd_event(VK_F15, 0 ,KEYEVENTF_KEYUP , UIntPtr.Zero); // Release F15
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] F15 key pressed to keep awake.");
    }
}