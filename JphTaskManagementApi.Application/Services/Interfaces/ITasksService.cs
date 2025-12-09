using JphTaskManagementApi.Domain.Models.Dto;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Application.Services.Interfaces
{
    public interface ITasksService
    {
        ResultOperation<bool> PostTasks(Tasks tasks);
        ResultOperation<Tasks> GetTaskById(int id);
        ResultOperation<bool> UpdateTask(Tasks tasks);
        ResultOperation<bool> DeleteTask(int id);
    }
}
