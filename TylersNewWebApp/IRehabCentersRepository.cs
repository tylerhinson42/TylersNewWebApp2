using System;
using Dapper;
using System.Collections.Generic;
using TylersNewWebApp.Models;

namespace TylersNewWebApp
{
    public interface IRehabCentersRepository
    {
        public IEnumerable<RehabCenters> GetAllRehabCenters();
        public RehabCenters GetRehabCenters(int id);
        public void UpdateRehabCenters(RehabCenters rehabCenters);
        public void InsertRehabCenters(RehabCenters rehabCentersToInsert);
        //public IEnumerable<Category> GetCategories();
        //public RehabCenters AssignCategory();
        //void UpdateRehabCenters(RehabCenters rehabCenters);
        public void DeleteRehabCenters(RehabCenters rehabCenters);
    }
}
