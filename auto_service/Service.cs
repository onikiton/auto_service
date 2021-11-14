using System;
using System.Collections.Generic;

#nullable disable

namespace auto_service
{
    public partial class Service
    {
        public Service()
        {
            ClientServices = new HashSet<ClientService>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int DurationInSeconds { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public string MainImagePath { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }
        
    }
}
