using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core22MVCIdentity.Models
{
    public class Panels
    {
        [Key]
        public int ID { get; set; }
        public string Desc { get; set; }

        public int FrameID { get; set; }

        [ForeignKey("FrameID")]
        public PanelFrames Frame { get; set; }

        public bool AC240v { get; set; }

    }

    public class PanelFrames
    {
        [Key]
        public int PanelFramesID { get; set; }
        public string Name { get; set; }

        public List<Panels> Panels { get; set; }
    }
}
