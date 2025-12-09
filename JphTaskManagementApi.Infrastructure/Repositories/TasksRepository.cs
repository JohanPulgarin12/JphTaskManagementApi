using Dapper;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using JphTaskManagementApi.Infrastructure.Repositories._UnitOfWork;
using JphTaskManagementApi.Infrastructure.Repositories.Interfaces;


namespace JphTaskManagementApi.Infrastructure.Repositories
{
    public class TasksRepository : Repository, ITasksRepository
    {
        public TasksRepository() { }
        public TasksRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #region POST
        public bool PostTasks(Tasks tasks)
        {
            var prms = new DynamicParameters();
            prms.Add("Title", tasks.Title);
            prms.Add("Description", tasks.Description);
            prms.Add("DueDate", tasks.DueDate);
            prms.Add("StateId", tasks.StateId);
            var response = Execute<int>("sp_CreateTask", prms) > 0 ? true : false;
            return response;
        }
        #endregion

        public Tasks GetTaskById(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("Id", id);
            return GetDataOfProcedure<Tasks>("sp_GetTaskById", prms);
        }


        #region PUT
        public bool UpdateTask(Tasks taks)
        {
            var prms = new DynamicParameters();
            prms.Add("Id", taks.Id);
            prms.Add("Title", taks.Title);
            prms.Add("Description", taks.Description);
            prms.Add("DueDate", taks.DueDate);
            prms.Add("StateId", taks.StateId);

            var response = Execute<int>("sp_UpdateTask", prms);
            return response > 0;
        }
        #endregion

        #region DELETE
        public bool DeleteTask(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("Id", id);
            var response = Execute<int>("sp_DeleteTask", prms) > 0 ? true : false;
            return response;
        }
        #endregion

    }
}
