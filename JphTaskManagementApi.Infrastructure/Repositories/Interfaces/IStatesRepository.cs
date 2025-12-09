using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Infrastructure.Repositories.Interfaces
{
    public interface IStatesRepository
    {
        bool PostState(State state);
        List<State> GetStates();
        State GetStateById(int id);
        bool UpdateState(State state);
        bool DeleteState(int id);
    }
}
