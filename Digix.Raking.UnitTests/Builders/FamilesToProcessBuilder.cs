using Digix.Raking.Domain.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Tests.Builders
{
    public class FamilesToProcessBuilder
    {
        public IList<Family> Build()
        {
            var jsonFamily =
            @"{
              'id': '3dac7da3-d742-4e51-95f9-bbb37f522413',
              'people': [
                { 'id': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'name': 'João', 'type': 'Pretendente', 'birthDate': '1989-12-30' },
                { 'id': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'name': 'Maria', 'type': 'Cônjuge', 'birthDate': '1989-12-30' },
                { 'id': '79820382-a181-42d2-bfae-6c012489e65e', 'name': 'José', 'type': 'Dependente', 'birthDate': '2015-12-30' },
                { 'id': '80fa071e-17fb-4b87-99db-a7db0bfc23c2', 'name': 'Angela', 'type': 'Dependente', 'birthDate': '2015-12-30' }
              ],
              'incomes': [
                { 'personId': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'value': 1000 },
                { 'personId': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'value': 950 }
              ],
              'status': '2'
            }";

            var jsonFamily2 =
            @"{
              'id': '3dac7da3-d742-4e51-95f9-bbb37f522413',
              'people': [
                { 'id': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'name': 'Marcelo', 'type': 'Pretendente', 'birthDate': '1989-12-30' },
                { 'id': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'name': 'Nilda', 'type': 'Cônjuge', 'birthDate': '1989-12-30' },
                { 'id': '79820382-a181-42d2-bfae-6c012489e65e', 'name': 'José', 'type': 'Dependente', 'birthDate': '2015-12-30' },
              ],
              'incomes': [
                { 'personId': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'value': 1000 },
                { 'personId': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'value': 950 }
              ],
              'status': '0'
            }";


            var jsonFamily3 =
            @"{
              'id': '3dac7da3-d742-4e51-95f9-bbb37f522413',
              'people': [
                { 'id': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'name': 'Marcelo', 'type': 'Pretendente', 'birthDate': '1989-12-30' },
                { 'id': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'name': 'Nilda', 'type': 'Cônjuge', 'birthDate': '1989-12-30' },
                { 'id': '79820382-a181-42d2-bfae-6c012489e65e', 'name': 'José', 'type': 'Dependente', 'birthDate': '2015-12-30' },
              ],
              'incomes': [
                { 'personId': '5e65eea1-aa72-407e-9a67-88045c07b5de', 'value': 1000 },
                { 'personId': 'd467781a-8f06-45ba-be6f-879cf32a9f7e', 'value': 950 }
              ],
              'status': '0'
            }";

            var list = new List<Family>();

            list.Add(JsonConvert.DeserializeObject<Family>(jsonFamily));
            list.Add(JsonConvert.DeserializeObject<Family>(jsonFamily2));
            list.Add(JsonConvert.DeserializeObject<Family>(jsonFamily3));

            return list;
        }
    }
}
