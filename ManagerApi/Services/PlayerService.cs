using AutoMapper;
using ManagerApi.Entities;
using ManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ManagerApi.Services
{
    public class PlayerService : IService<Player, PlayerViewModel>
    {
        private readonly ServiceBase<Player> service;
        private readonly IMapper mapper;

        public PlayerService(ServiceBase<Player> _service, IMapper _mapper)
        {
            service = _service;
            mapper = _mapper;
        }

        public void Add(PlayerViewModel model, bool saveChanges = true)
        {
            try
            {
                var team = new Player();
                team = mapper.Map<Player>(model);
                service.AddEntity(team);
                if (saveChanges)
                    service.SaveChanges();

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Delete(int id, bool saveChanges = true)
        {
            try
            {
                service.DeleteEntity(id);
                if (saveChanges)
                    service.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public PlayerViewModel GetById(int id)
        {
            try
            {
                var team = service.GetEntityById(id);
                var model = mapper.Map<PlayerViewModel>(team);
                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PlayerViewModel> Get(Expression<Func<PlayerViewModel, bool>> predicate = null)
        {
            try
            {
                var list = service.GetEntities();
                var modellist = list.Select(mapper.Map<Player, PlayerViewModel>).ToList(); return modellist;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return service.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(PlayerViewModel model, bool saveChanges = true)
        {
            try
            {

                var modifyPlayer = mapper.Map<Player>(model);
                service.UpdateEntity(modifyPlayer);
                if (saveChanges)
                    service.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
