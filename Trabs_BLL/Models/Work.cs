using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabs_BLL.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int MatterId { get; set; }
        public Matter? Matter { get; set; }
        public string PDF { get; set; }
    }
}
