using Digix.Raking.Domain.Core.Adapters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Digix.Raking.Adapters
{
    public class AttendedFamiliesAdapter : IAttendedFamiliesAdapter
    {
        public Task SaveAttendedFamily(Guid familyId, int score, int totalCriterias, DateTime dateTimeClassification)
        {
            return Task.Run(() => 
                Debugger.Log(0, "Info", $"Enviando dados família clissificada para outro contexto, Família: {familyId}, pontuação: {score}, total de critérios atendidos: {totalCriterias}")
            );
        }
    }
}
