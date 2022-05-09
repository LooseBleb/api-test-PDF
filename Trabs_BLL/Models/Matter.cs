using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabs_BLL.Models
{
    public class Matter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[]? Icon { get; set; }
        public virtual ICollection<Work>? Works { get; set; }
    }
}
