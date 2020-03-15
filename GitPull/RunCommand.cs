using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace GitPull
{
    class RunCommand
    {
        // pulls from a local list of file paths
        // these paths represent projects
        // these projects will ( if they have updates ) be updated via GIT
        public void PullList()
        {
            Helpers.LogMethod();
            //
            string _files = ReadFile("projects.txt");
            //
            int _count = _files.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None).Length;
            string[] _list = new string[_count];
            //
            _list = _files.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            //
            foreach (string _item in _list)
            {
                Pull(_item);
            }
        }
        public string Pull(string path)
        {
            Helpers.LogMethod(path);
            try
            {
                //
                string response = "";
                //Set the current directory.
                Directory.SetCurrentDirectory(path);
                //
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "git",
                        Arguments = @"pull origin master",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                //
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    response += proc.StandardOutput.ReadLine() + System.Environment.NewLine;
                    Console.WriteLine(proc.StandardOutput.ReadLine());
                    Helpers.WriteLog(proc.StandardOutput.ReadLine());
                }

                return response;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }

            return "An Unknown Error Occured";
        }
        public static string ReadFile(string path)
        {
            string re = "";
            // Open the stream and read it back.
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    re += temp.GetString(b);
                }
            }

            return re.Replace("\0", "");
        }
    }
}
