using System;
using System.Collections.Generic;
using System.Text;
using EcoSystemAPI.Context.Models;

namespace EcoSystemAPI.uow.Interfaces
{
    public interface IStateRepo
    {
        bool SaveChanges();
        IEnumerable<State> GetAllStates();
        State GetStateById(int id);
        void CreateState(State teams);
        void UpdateState(State teams);

    }
}
