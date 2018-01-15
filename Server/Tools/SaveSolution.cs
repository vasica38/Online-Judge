using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Tools
{
    public class SaveSolution
    {
        public SaveSolution(string code, string path, string name, string extension)
        {
            Code = code;
            Path = path;
            Name = name;
            Extension = extension;
        }

        public string Code { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }

        public void SaveFile()
        {
            string totalPath = Path + "\\" + Name + "." + Extension;
            System.IO.File.WriteAllText(totalPath, Code);
        }

        public string GetCodePath()
        {
            string totalPath = Path + "\\" + Name + "." + Extension;
            return totalPath;
        }

    }
}
