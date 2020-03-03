using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Models
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<ItemDto> Item { get; set; }
            = new List<ItemDto>();
    }
}
