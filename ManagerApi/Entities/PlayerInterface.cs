using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Entities
{
    interface PlayerInterface
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PositionEnum Position { get; set; }

        [Range(16, 45)]
        public int Age { get; set; }
    }
}
