using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models.Client
{
    public class IdentifiableProject : Project
    {
        public string ProjectId { get; set; }
    }
}
