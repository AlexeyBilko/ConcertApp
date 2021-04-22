namespace ConcertApp.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Concerts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concerts()
        {
            Tickets = new HashSet<Tickets>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string City { get; set; }

        public string Organizer { get; set; }

        public string Photo { get; set; }

        public string Actors { get; set; }

        public string Address { get; set; }

        public DateTime StartTime { get; set; }

        public string TypeOfEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
