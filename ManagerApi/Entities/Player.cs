using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManagerApi.Entities
{
    public class Player : PlayerInterface
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public PositionEnum Position { get; set; }
        public int Age { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
