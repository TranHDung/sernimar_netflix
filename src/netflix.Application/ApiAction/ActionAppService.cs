﻿using Abp.Application.Services;
using Abp.Domain.Repositories;
using netflix.Entities;
using netflix.Medias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = netflix.Entities.Action;

namespace netflix.ApiAction
{
    public class ActionAppService : ApplicationService, IActionAppService
    {
        private readonly IRepository<Entities.Action> _actionRepository;
        private readonly IRepository<ActionType> _actionTypeRepository;
        public ActionAppService(IRepository<Entities.Action> actionRepository,
                                IRepository<ActionType> actionTypeRepository)
        {
            _actionRepository = actionRepository;
            _actionTypeRepository = actionTypeRepository;
        }

        public async Task<int> Add(Action action)
        {
            int id = 0;
            action.CreatedDate = DateTime.Today;
            try
            {
                id = await _actionRepository.InsertAndGetIdAsync(action);
            }
            catch (Exception e)
            {
                var x = 2;
            }
            return id;
        }

        public async Task<int> AddActionType(ActionType actionType)
        {
            var entity = await _actionTypeRepository.InsertAsync(actionType);
            return entity.Id;
        }

        public async Task Delete(int actionId)
        {
            var entity = await _actionRepository.FirstOrDefaultAsync(a =>a.Id == actionId);
            await _actionRepository.DeleteAsync(entity);
        }

        public async Task DeleteActionType(int actionTypeId)
        {
            var entity = await _actionTypeRepository.FirstOrDefaultAsync(a => a.Id == actionTypeId);
            await _actionTypeRepository.DeleteAsync(entity);
        }

        public async Task<List<Entities.Action>> GetAll()
        {
            var entities = await _actionRepository.GetAllListAsync();
            return entities;
        }

        public async Task<List<ActionType>> GetAllActionType()
        {
            var entities = await _actionTypeRepository.GetAllListAsync();
            return entities;
        }

        public async Task<MediaStat> GetMediaStat()
        {
            var allAction = _actionRepository.GetAllIncluding(i=>i.Media).ToList();
            var res = new MediaStat();
            // action type id = 1 is Watch
            res.YesterdayView = allAction.Where(i => i.ActionTypeId == 1).Where(i => i.CreatedDate == DateTime.Today.AddDays(-1)).ToList().Count();
            res.ToDayView = allAction.Where(i => i.ActionTypeId == 1).Where(i => i.CreatedDate == DateTime.Today).ToList().Count();

            res.MediaViews= new List<MediaAndView>();
            allAction.ToList().ForEach(i =>
            {
                var curMedia = res.MediaViews.Where(m => m.Media.Id == i.MediaId).FirstOrDefault();
                if(curMedia is not null)
                // new media da ton tai trong list thi +1
                {
                    curMedia.ViewCount += 1;
                }
                else
                {
                    var m = new MediaAndView()
                    {
                        Media = i.Media,
                        ViewCount = 1,
                    };
                    res.MediaViews.Add(m);
                }
            });
            res.MediaViews = res.MediaViews.Where(m => m.ViewCount != 0).Select(i => new MediaAndView()
            {
                Media = new Media()
                {
                    Id = i.Media.Id,
                    Name = i.Media.Name,
                },
                ViewCount = i.ViewCount
            }).ToList();
            return res;
        }

        public async Task Update(Entities.Action action)
        {
            await _actionRepository.UpdateAsync(action);
        }

        public async Task UpdateActionType(ActionType actionType)
        {
            await _actionTypeRepository.UpdateAsync(actionType);
        }
    }
}
