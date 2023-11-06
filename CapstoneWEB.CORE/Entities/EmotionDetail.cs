using System;
using System.Collections.Generic;

namespace CapstoneWEB.CORE.Entities;

public partial class EmotionDetail
{
    public int? IdUser { get; set; }

    public int? IdFile { get; set; }

    public string? Detail { get; set; }

    public virtual File? IdFileNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
