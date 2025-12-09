using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Infrastructure.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        bool PostTasks(Tasks tasks);
        Tasks GetTaskById(int id);
        bool UpdateTask(Tasks taks);
        bool DeleteTask(int id);
    }
}
