using static System.Console;

namespace CoreSchool.Util
{
    public static class Printer
    {
        public static void DrawLine(int length = 10, char charType = '-')
            => WriteLine("".PadLeft(length, charType));

        public static string GetLine(int length = 10, char charType = '-')
            => "".PadLeft(length, charType);

        public static void WriteTitle(string title)
        {
            int size = title.Length + 4;
            DrawLine(size);
            WriteLine($"| {title} |");
            DrawLine(size);

        }

        public static void SoundBeep(int hz = 2000, int beepMs = 500, int times = 1, int sleepMs = 0)
        {
            while (times > 0)
            {
                Beep(hz, beepMs);
                Thread.Sleep(sleepMs);
                times -= 1;
            }
        }

        public static void EnterPause(string msg = "ENTER to continue ...")
        {
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}