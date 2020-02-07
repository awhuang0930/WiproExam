using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiprobackend.DtoModels;

namespace Wiprobackend.Services
{
    public interface ITrainingService
    {
        int AddTraining(TrainingDto training);
    }
}
