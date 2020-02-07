using System;
using System.Collections.Generic;

namespace Wiprobackend.DomainModels
{
    public partial class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
