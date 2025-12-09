using JphTaskManagementApi.Application.Services.Interfaces;
using JphTaskManagementApi.Domain.Entities.CustomEntities;
using JphTaskManagementApi.Domain.Models;
using JphTaskManagementApi.Domain.Models.Dto;
using JphTaskManagementApi.Domain.Models.Farma.Core;
using JphTaskManagementApi.Domain.Models.Farma.SP;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using JphTaskManagementApi.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JphTaskManagementApi.Application.Services
{
    public class TasksService : _Service, ITasksService
    {
        public TasksService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }

        #region POST
        public ResultOperation<bool> PostTasks(Tasks tasks)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, TasksRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.PostTasks(tasks);
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }
        #endregion

        public ResultOperation<Tasks> GetTaskById(int id)
        {
            var result =
                WrapExecuteTrans<ResultOperation<Tasks>, TasksRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<Tasks>();

                    try
                    {
                        var state = repo.GetTaskById(id);

                        if (state == null)
                        {
                            rst.MessageResult = "No existe un State con ese Id";
                        }

                        rst.Result = state;
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }


        public ResultOperation<bool> UpdateTask(Tasks tasks)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, TasksRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.UpdateTask(tasks);
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}";
                }

                return rst;
            });

            return result;
        }

        public ResultOperation<bool> DeleteTask(int id)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, TasksRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.DeleteTask(id);
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }


    }
}
