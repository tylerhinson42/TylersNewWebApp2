using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using TylersNewWebApp.Models;

namespace TylersNewWebApp
{
    public class RehabCentersRepository : IRehabCentersRepository
    {
        private readonly IDbConnection _conn;

        public RehabCenters GetRehabCenters(int id)
        {
            return (RehabCenters)_conn.QuerySingle<RehabCenters>("SELECT * FROM RehabCenters WHERE ID = @id",
                new { id = id });
        }

        public RehabCentersRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<RehabCenters> GetAllRehabCenters()
        {
            return _conn.Query<RehabCenters>("SELECT * FROM RehabCenters;");
        }

        public void InsertRehabCenters(RehabCenters rehabCentersToInsert)
        {
            {
                _conn.Execute("INSERT INTO RehabCenters (ID, NAME, ADDRESS, PHONENUMBER, WEBSITE, SPECIALTY, SPECIALTYID) VALUES (@id, @name, @address, @phonenumber, @website, @specialty, @specialtyID);",
                    new { name = rehabCentersToInsert.Name, address = rehabCentersToInsert.Address,
                        ID = rehabCentersToInsert.ID, phoneNumber = rehabCentersToInsert.PhoneNumber,
                        website = rehabCentersToInsert.Website, specialty = rehabCentersToInsert.Specialty,
                        specialtyID = rehabCentersToInsert.SpecialtyID});
            }
;
        }

        //public IEnumerable<Category> GetCategories(string specialtyID)
        //{
        //    return _conn.Query<Category>("SELECT * FROM RehabCenters WHERE SpecialtyID = @specialtyID;");
        //}

        //public RehabCenters AssignCategory()
        //{
        //    var categoryList = GetCategories();
        //    var rehabCenters = new RehabCenters();
        //    rehabCenters.Categories = categoryList;

        //    return rehabCenters;
        //}

        public void UpdateRehabCenters(RehabCenters rehabCenters)
        {
            _conn.Execute("UPDATE RehabCenters SET Name = @name WHERE ID = @id",
                new { name = rehabCenters.Name, website = rehabCenters.Website, id = rehabCenters.ID });
                                        
        }

        public void DeleteRehabCenters(RehabCenters rehabCenters)
        {
            _conn.Execute("DELETE FROM RehabCenters WHERE ID = @id;",
                                       new { id = rehabCenters.ID });           
        }

    }
}
