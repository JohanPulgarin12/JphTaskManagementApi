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
    public class StatesService : _Service, IStatesService
    {
        public StatesService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }

        public ResultOperation<bool> PostState(State state)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, StatesRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.PostState(state);
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

        public ResultOperation<List<State>> GetStates()
        {
            var result =
                WrapExecuteTrans<ResultOperation<List<State>>, StatesRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<List<State>>();
                    var stateList = new List<State>();

                    try
                    {
                        stateList = repo.GetStates();

                        rst.Result = stateList;
                        rst.stateOperation = true;

                        if (stateList.Count == 0)
                            rst.MessageResult = "No hay datos en la tabla State";
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

        public ResultOperation<State> GetStateById(int id)
        {
            var result =
                WrapExecuteTrans<ResultOperation<State>, StatesRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<State>();

                    try
                    {
                        var state = repo.GetStateById(id);

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



        public ResultOperation<bool> UpdateState(State state)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, StatesRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.UpdateState(state);
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

        public ResultOperation<bool> DeleteState(int id)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, StatesRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.DeleteState(id);
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
