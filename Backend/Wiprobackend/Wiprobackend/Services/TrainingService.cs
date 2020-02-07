using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiprobackend.DtoModels;
using Wiprobackend.DomainModels;
using Wiprobackend.Repo;

namespace Wiprobackend.Services
{
    public class TrainingService : ITrainingService
    {
        ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public int AddTraining( TrainingDto trainingDto)
        {
            Training training = new Training()
            {
                Id = 0,
                Name = trainingDto.Name,
                StartDate = trainingDto.StartDate,
                EndDate = trainingDto.EndDate
            };

            _trainingRepository.Add(training);

            return (int)(trainingDto.EndDate - trainingDto.StartDate).TotalDays;
        }
    }
}
