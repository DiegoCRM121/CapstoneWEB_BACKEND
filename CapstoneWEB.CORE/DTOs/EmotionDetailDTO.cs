using CapstoneWEB.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneWEB.CORE.DTOs
{
    public class EmotionDetailDTO
    {
        public int? IdUser { get; set; }

        public int? IdFile { get; set; }

        public string? Detail { get; set; }

        public virtual Entities.File? IdFileNavigation { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }

    public class EmotionDetailInsertDTO
    {
        public string? Detail { get; set; }
    }
}
