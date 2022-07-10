using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class ArtisteModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Histoire1 { get; set; }
        public string Histoire2 { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
    }
}