using System;
using Xunit;
using Moq;
using Wiprobackend.Services;
using Wiprobackend.Repo;
using Wiprobackend.DtoModels;

namespace TestProject
{
    public class UnitTest1
    {
        Mock<ITrainingRepository> _moqTrainingRepository = new Mock<ITrainingRepository>();

        [Theory]
        [InlineData(2020,1,20,2020,2,1,12)]
        [InlineData(2020, 1, 20, 2021, 2, 1, 378)]
        [InlineData(2030, 1, 20, 2030, 2, 1, 12)]
        [InlineData(1920, 12, 31, 1921, 12, 30, 364)]
        public void TestTrainingDate(int startYear, int startMonth, int StartDay, 
            int endYear, int endMonth, int endDay, int expected)
        {
            TrainingDto testTraining = new TrainingDto()
            {
                Name = "Test",
                StartDate = new DateTime(startYear, startMonth, StartDay),
                EndDate = new DateTime(endYear, endMonth, endDay)
            };
            ITrainingService trainingService = new TrainingService(_moqTrainingRepository.Object);
            int dayInTraining = trainingService.AddTraining(testTraining);
            Assert.Equal(expected, dayInTraining);
        }
    }
}
