using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcoSystemAPI.Context.Models;
using EcoSystemAPI.Context;
using EcoSystemAPI.uow.Interfaces;

namespace EcoSystemAPI.uow.Repositories
{
    public class SqlStateRepo:IStateRepo
    {
        private readonly EcosystemContext _context;

        public SqlStateRepo(EcosystemContext ecosystemContext)
        {
            _context = ecosystemContext;
        }


        public void CreateState(State state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            _context.State.Add(state);
        }

        public IEnumerable<State> GetAllStates()
        {
            return _context.State.ToList();
        }

        public State GetStateById(int id)
        {
            return _context.State.FirstOrDefault(state => state.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateState(State teams)
        {

        }
    }
}
