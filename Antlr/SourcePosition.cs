using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr
{
    public class SourcePosition
    {
        public string FileName { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public int ErrorLength { get; set; } = 1;
    }
}
