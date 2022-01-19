using System.Collections.Generic;
using Samsung.Placing.BusinessObjects;

namespace Samsung.Placing.Services
{
    public interface IDeveloperService
    {
        IList<Developer> GetAllDevelopers();
        void CreateDeveloper(Developer developer);
        (IList<Developer> records, int total, int totalDisplay) GetDevelopers(int pageIndex, int pageSize, string searchText, string sortText);
        Developer GetDeveloper(int id);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int developerId);
    }
}
