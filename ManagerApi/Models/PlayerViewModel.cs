using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
        [Required]
        [Range(0, 40)]
        public int Age { get; set; }

        public int TeamId { get; set; }
    }
}
