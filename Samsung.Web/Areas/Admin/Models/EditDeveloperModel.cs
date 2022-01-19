using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Samsung.Placing.BusinessObjects;
using Samsung.Placing.Services;
using AutoMapper;
using Autofac;

namespace Samsung.Web.Areas.Admin.Models
{
    public class EditDeveloperModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public string Skills { get; set; }
        public int TeamId { get; set; }

        public readonly IDeveloperService _developerService;
        public readonly IMapper _mapper;

        public EditDeveloperModel()
        {
            _developerService = Startup.AutofacContainer.Resolve<IDeveloperService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public EditDeveloperModel(IDeveloperService developerService)
        {
            _developerService = developerService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void LoadModelData(int id)
        {
            _mapper.Map(_developerService.GetDeveloper(id), this);
        }

        public void Update()
        {
            _developerService.UpdateDeveloper(_mapper.Map(this, new Developer()));
        }
    }
}
