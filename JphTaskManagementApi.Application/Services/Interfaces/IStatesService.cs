using JphTaskManagementApi.Domain.Models.Dto;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Application.Services.Interfaces
{
    public interface IStatesService
    {
        ResultOperation<bool> PostState(State state);
        ResultOperation<List<State>> GetStates();

        ResultOperation<State> GetStateById(int id);
        ResultOperation<bool> UpdateState(State state);
        ResultOperation<bool> DeleteState(int id);
    }
}
