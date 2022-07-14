using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace LR3
{
   public class Read : IReadable
    {
        public List<string> GetNextLine(string path)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((file.ReadLine()) != null)
                {
                    return File.ReadLines(path).ToList();
                }
                file.Close();
                return File.ReadLines(path).ToList();
            }
            else throw new NotImplementedException();
        }
    }
}
