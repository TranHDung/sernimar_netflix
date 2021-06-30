using Abp.Application.Services;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiAction
{
    public interface IActionAppService : IApplicationService
    {
        public Task<int> Add(Entities.Action action);
        public Task Update(Entities.Action action);
        public Task<List<Entities.Action>> GetAll();
        public Task Delete(int actionId);

        public Task<int> AddActionType(ActionType actionType);
        public Task UpdateActionType(ActionType actionType);
        public Task<List<ActionType>> GetAllActionType();
        public Task DeleteActionType(int actionTypeId);
    }
}
