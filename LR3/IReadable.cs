using System.Collections.Generic;

namespace LR3
{
    interface IReadable
    {
        public List<string> GetNextLine(string path);
    }
}
