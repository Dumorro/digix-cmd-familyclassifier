using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Services;
using Digix.Raking.Domain.Services.ScoreRules;
using Digix.Raking.Tests.Base;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Digix.Raking.Tests
{
    public class ScoreFamilyServiceManagerTest : TestBase
    {
        private Family TestFamily;

        public ScoreFamilyServiceManagerTest()
        {
            ConfigureTests();
        }

        private void ConfigureTests()
        {
            var jsonFamily =
           @"{
              'id': '3dac7da3-d742-4e51-95f9-bbb37f522413',
              'people': [
                { 'id': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'name': 'João', 'type': 'Pretendente', 'birthDate': '1974-12-30' },
                { 'id': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'name': 'Maria', 'type': 'Cônjuge', 'birthDate': '1989-12-30' },
                { 'id': '79820382-a181-42d2-bfae-6c012489e65e', 'name': 'José', 'type': 'Dependente', 'birthDate': '2012-12-30' },
                { 'id': '80fa071e-17fb-4b87-99db-a7db0bfc23c2', 'name': 'Angela', 'type': 'Dependente', 'birthDate': '2015-12-30' },
                { 'id': '80fa071e-17fb-4b87-99db-a7db0bfc23c2', 'name': 'Angela', 'type': 'Dependente', 'birthDate': '2016-12-31' }
              ],
              'incomes': [
                { 'personId': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'value': 850 }
              ],
              'status': '0'
            }";

            TestFamily = JsonConvert.DeserializeObject<Family>(jsonFamily);
        }

        [Fact]
        public void Test_calcule_FamilyScore_ok()
        {
            var TOTAL_SCORE = 11;
            var TOTAL_CRITERIAS = 3;

            var score = ScoreFamilyServiceManager.CalculateScore(this.TestFamily);

            Assert.Equal(score.Score, TOTAL_SCORE);
            Assert.Equal(score.TotalCriterias, TOTAL_CRITERIAS);
        }

        [Fact]
        public void Test_calcule_FamilyAgeApplicantScore_ok()
        {
            var TOTAL_SCORE = 3;

            var score = ScoreFactory.CreateScoreRule<FamilyAgeApplicantScore>(TestFamily);
            score.CalculateScore();

            Assert.Equal(TOTAL_SCORE, score.Score);
            Assert.True(score.IsClassified);
        }

        [Fact]
        public void Test_calcule_FamilyDedependentScore_ok()
        {
            var TOTAL_SCORE = 3;

            var score = ScoreFactory.CreateScoreRule<FamilyDedependentScore>(TestFamily);
            score.CalculateScore();

            Assert.Equal(TOTAL_SCORE, score.Score);
            Assert.True(score.IsClassified);
        }

        [Fact]
        public void Test_calcule_FamilyIncomeScore_ok()
        {
            var TOTAL_SCORE = 5;

            var score = ScoreFactory.CreateScoreRule<FamilyIncomeScore>(TestFamily);
            score.CalculateScore();

            Assert.Equal(TOTAL_SCORE, score.Score);
            Assert.True(score.IsClassified);
        }




        [Fact]
        public void Test_without_calcule_FamilyAgeApplicantScore()
        {
            var TOTAL_SCORE = 0;

            var score = ScoreFactory.CreateScoreRule<FamilyAgeApplicantScore>(TestFamily);

            Assert.Equal(TOTAL_SCORE, score.Score);
            Assert.False(score.IsClassified);
        }

        [Fact]
        public void Test_without_calcule_FamilyDedependentScore()
        {
            var TOTAL_SCORE = 0;

            var score = ScoreFactory.CreateScoreRule<FamilyDedependentScore>(TestFamily);

            Assert.Equal(TOTAL_SCORE, score.Score);
            Assert.False(score.IsClassified);
        }

        [Fact]
        public void Test_without_calcule_FamilyIncomeScore()
        {
            var TOTAL_SCORE = 0;

            var score = ScoreFactory.CreateScoreRule<FamilyIncomeScore>(TestFamily);

            Assert.Equal(TOTAL_SCORE, score.Score);
            Assert.False(score.IsClassified);
        }
    }
}
