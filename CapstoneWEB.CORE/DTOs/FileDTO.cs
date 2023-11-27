using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneWEB.CORE.DTOs
{
    public class FileDTO
    {
        public int IdFile { get; set; }

        public string? FileName { get; set; }

        public string? FileType { get; set; }
    }

    public class FileInsertDTO
    {
        public string? FileName { get; set; }

        public string? FileType { get; set; }
    }
}
