namespace ConcertApp.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tickets
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Row { get; set; }

        public int Place { get; set; }

        public string Type { get; set; }

        public int? ConcertId { get; set; }

        public int? UserId { get; set; }

        public virtual Concerts Concerts { get; set; }

        public virtual Users Users { get; set; }
    }
}
