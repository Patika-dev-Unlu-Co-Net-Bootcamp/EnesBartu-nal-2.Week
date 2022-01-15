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
    public class TeamService : IService<Team, TeamViewModel>
    {
        private readonly ServiceBase<Team> service;
        private readonly IMapper mapper;

        public TeamService(ServiceBase<Team> _service, IMapper _mapper)
        {
            service = _service;
            mapper = _mapper;
        }

        public void Add(TeamViewModel model, bool saveChanges = true)
        {
            try
            {
                var team = new Team();
                team = mapper.Map<Team>(model);
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

        public TeamViewModel GetById(int id)
        {
            try
            {
                var team = service.GetEntityById(id);
                var model = mapper.Map<TeamViewModel>(team);
                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TeamViewModel> Get(Expression<Func<TeamViewModel, bool>> predicate = null)
        {
            try
            {
                var list = service.GetEntities();
                var modellist = list.Select(mapper.Map<Team, TeamViewModel>).ToList(); return modellist;
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

        public void Update(TeamViewModel model, bool saveChanges = true)
        {
            try
            {
               
                    var modifyteam = mapper.Map<Team>(model);
                    service.UpdateEntity(modifyteam);
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
