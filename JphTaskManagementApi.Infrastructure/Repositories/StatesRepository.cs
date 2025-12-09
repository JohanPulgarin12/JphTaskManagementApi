using Dapper;
using JphTaskManagementApi.Domain.Models.Farma.SP;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using JphTaskManagementApi.Infrastructure.Repositories._UnitOfWork;
using JphTaskManagementApi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Infrastructure.Repositories
{
    public class StatesRepository : Repository, IStatesRepository
    {
        public StatesRepository() { }
        public StatesRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public bool PostState(State state)
        {
            var prms = new DynamicParameters();
            prms.Add("name", state.Name);
            var response = Execute<int>("sp_CreateState", prms) > 0 ? true : false;
            return response;
        }

        public List<State> GetStates()
        {
            var response = GetDataListOfProcedure<State>("sp_GetStates");
            return response;
        }

        public State GetStateById(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("Id", id);

            return GetDataOfProcedure<State>("sp_GetStateById", prms);
        }

        public bool UpdateState(State state)
        {
            var prms = new DynamicParameters();
            prms.Add("Id", state.Id);
            prms.Add("Name", state.Name);
            var response = Execute<int>("sp_UpdateState", prms);
            return response > 0;
        }

        public bool DeleteState(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("Id", id);
            var response = Execute<int>("sp_DeleteState", prms) > 0 ? true : false;
            return response;
        }

    }
}
