using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneSLAs.Model
{
    public class SLA
    {
        public string Text { get; set; }
        public Guid Value { get; set; }
        public string MainEntity { get; set; }
    }
}
