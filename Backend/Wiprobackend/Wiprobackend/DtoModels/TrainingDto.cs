using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiprobackend.DtoModels
{
    public class TrainingDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
