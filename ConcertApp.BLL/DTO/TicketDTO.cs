using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.BLL.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public string Type { get; set; }

        public int? ConcertId { get; set; }

        public int? UserId { get; set; }
    }
}
