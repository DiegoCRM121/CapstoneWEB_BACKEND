using System;
using System.Collections.Generic;

namespace CapstoneWEB.CORE.Entities;

public partial class File
{
    public int IdFile { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }
}
