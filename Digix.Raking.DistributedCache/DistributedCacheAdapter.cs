using Digix.Raking.Domain.Core.Adapters;
using System;
using System.Threading.Tasks;

namespace Digix.Raking.Adapters
{
    public class DistributedCacheAdapter : ICacheAdapter
    {
        public Task<bool> SaveOrUpdate(Guid familyId, int score, int totalCriterias, DateTime dateTimeClassification)
        {
            Task.Run(()=>
            Console.WriteLine($"Info - Enviando para contexto de consultas, Família: {familyId}, pontuação: {score}, total de critérios atendidos: {totalCriterias}")
            );

            return Task.FromResult(true);
        }
    }
}
