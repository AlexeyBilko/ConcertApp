using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NumberPhone { get; set; }

        public int? CardId { get; set; }

        public ICollection<TicketDTO> Tickets { get; set; } = new HashSet<TicketDTO>();

    }
}
