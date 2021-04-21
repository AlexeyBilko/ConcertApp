using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.DAL.Context
{
    public class Tickets
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public string Type { get; set; }

        public int? ConcertId { get; set; }
        public virtual Concerts Concert { get; set; }
    
        public int? UserId { get; set; }
        public Users User { get; set; }
       
    }
}
