using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.DAL.Context
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NumberPhone { get; set; }

        public int? CardId { get; set; }
        public virtual CreditCards Card { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; } = new HashSet<Tickets>();
    }
}
