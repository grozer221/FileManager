using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class StructureTable
    {
        public Bitmap Image { get; set; }
        public string Name { get; set; }
        public string FormatOrDateLastChanged { get; set; }
        public string TotalFreeSpaceOrType { get; set; }
        public string TotalSize { get; set; }
    }
}
