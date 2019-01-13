using System;
using System.IO;
using System.Text;

namespace AutomationFramework
{
    public class CSVWriter
    {

        public static void Write(string path, string content)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("This are the results for version " + Driver.BaseAddress);
                }
            }

            //Create the file.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(content);
            }
        }
    }
}