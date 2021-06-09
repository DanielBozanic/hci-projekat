using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Models
{
    class ZabavaPoruka
    {
        public int Id { get; set; }
        public int ZabavaId { get; set; }
        public string Poruka { get; set; }
        public int KreatorId { get; set; }
    }
}
