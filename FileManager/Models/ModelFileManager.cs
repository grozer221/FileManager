using System.Drawing;

namespace FileManager.Core
{
    public class ModelFileManager
    {
        public Bitmap Image { get; set; }
        public string Name { get; set; }
        public string FormatOrDateLastChanged { get; set; }
        public string TotalFreeSpaceOrType { get; set; }
        public string TotalSize { get; set; }
    }
}
