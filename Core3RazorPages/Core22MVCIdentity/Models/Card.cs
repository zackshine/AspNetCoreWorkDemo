using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core22MVCIdentity.Models
{
    public class Card
    {
        [Key]
        public int ID { get; set; }
        public string Context { get; set; }
        public string Receiver { get; set; }

        //public int? CatId { get; set; }
  
        //[ForeignKey("CatId")]public CatTbl Cat { get; set; }
    }

    public class SpecialCard : Card
    {
        public string SpecialCardText { get; set; }
    }
}
