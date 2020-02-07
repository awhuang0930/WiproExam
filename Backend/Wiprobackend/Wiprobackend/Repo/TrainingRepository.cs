using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiprobackend.DomainModels;

namespace Wiprobackend.Repo
{
    public class TrainingRepository : BaseRepository<Training>, ITrainingRepository
    {
        public WiprotestContext Context
        {
            get => _context as WiprotestContext;
            set => _context = value;
        }

        public TrainingRepository() : base()
        {
            Context = new WiprotestContext();
        }
    }
}
