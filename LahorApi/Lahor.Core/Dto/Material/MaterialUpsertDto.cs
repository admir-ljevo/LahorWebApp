using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Core.Dto.Material
{
    public class MaterialUpsertDto: BaseDto
    {
        public string Name { get; set; }    
        public float Price { get; set; }   

    }
}
