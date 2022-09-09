using System;
using System.Diagnostics;
using System.IO;

namespace Juabat
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine($"Juabat path\\to\\exe path\\to\\commandline_file");
                return;
            }
            string exe = args[0];
            string txt = args[1];

            if (!File.Exists(exe))
            {
                Console.WriteLine($"{exe} not found.");
                return;
            }
            if (!File.Exists(txt))
            {
                Console.WriteLine($"{txt} not found.");
                return;
            }
            ProcessStartInfo pro = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = exe,
                Arguments = File.ReadAllText(txt),/*,
                RedirectStandardOutput = true,*/
                UseShellExecute = false
            };
            Process process = Process.Start(pro);
            //var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            //Console.WriteLine(output);
        }
    }
}