using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestPlink
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathToPlink = @"C:\Program Files\PuTTY\plink.exe";
            string username = "m.burtsev";
            string destination = "static.spn.ru";
            string password = "Thu-2331";


            ProcessStartInfo PlinkProcess = new ProcessStartInfo();
            PlinkProcess.RedirectStandardInput = true;
            PlinkProcess.RedirectStandardOutput = true;
            PlinkProcess.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            PlinkProcess.UseShellExecute = false;
            PlinkProcess.CreateNoWindow = false;
            PlinkProcess.FileName = PathToPlink;
            PlinkProcess.Arguments = String.Format(" -ssh {0}@{1} -pw {2}", username, destination, password);

            Process process = Process.Start(PlinkProcess);
            process.StandardInput.WriteLine("ls -l");
            process.StandardInput.WriteLine("exit");
            string output = process.StandardOutput.ReadToEnd();

            Console.WriteLine(output);
            Thread.Sleep(1000);
            Console.ReadLine();

            if (process.HasExited)
            {
                process.Close();
                process.Dispose();
            }


        }
    }
}
