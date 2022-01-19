using Samsung.Placing.BusinessObjects;
using System;
using System.Collections.Generic;
using Samsung.Placing.UnitOfWorks;
using AutoMapper;
using System.Linq;

namespace Samsung.Placing.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IPlacingUnitOfWork _placingUnitOfWork;
        private readonly IMapper _mapper;

        public DeveloperService(IPlacingUnitOfWork placingUnitOfWork, IMapper mapper)
        {
            _placingUnitOfWork = placingUnitOfWork;
            _mapper = mapper;
        }

        public void CreateDeveloper(Developer developer)
        {
            _placingUnitOfWork.DeveloperRepository.Add(
                _mapper.Map<Entities.Developer>(developer));

            _placingUnitOfWork.Save();
        }

        public void DeleteDeveloper(int developerId)
        {
            _placingUnitOfWork.DeveloperRepository.Remove(developerId);
            _placingUnitOfWork.Save();
        }

        public IList<Developer> GetAllDevelopers()
        {
            var developerEntities = _placingUnitOfWork.DeveloperRepository.GetAll();
            var developers = new List<Developer>();

            foreach (var entity in developerEntities)
            {
                developers.Add(_mapper.Map<Developer>(entity));
            }

            return developers;
        }

        public Developer GetDeveloper(int id)
        {
            var developer = _placingUnitOfWork.DeveloperRepository.GetById(id);

            if (developer == null) return null;

            return _mapper.Map<Developer>(developer);
        }

        public (IList<Developer> records, int total, int totalDisplay) 
            GetDevelopers(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var developerData = _placingUnitOfWork.DeveloperRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize); ;

            var result = (from developer in developerData.data
                          select _mapper.Map<Developer>(developer)).ToList();

            return (result, developerData.total, developerData.totalDisplay);
        }

        public void UpdateDeveloper(Developer developer)
        {
            var developerEntity = _placingUnitOfWork.DeveloperRepository.GetById(developer.Id);

            if (developerEntity != null)
            {
                _mapper.Map(developer, developerEntity);
                _placingUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Developer");
            }
        }
    }
}
