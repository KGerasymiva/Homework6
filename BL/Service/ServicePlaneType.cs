using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.Infrastructure;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;

namespace BL.Service
{
    public class ServicePlaneType : IServicePlaneType
    {
        IUnitOfWork Database { get; set; }
        private IMapper mapper;

        public ServicePlaneType(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            this.mapper = mapper;
        }

        public IEnumerable<PlaneTypeDTO> GetPlaneTypes()
        {
            return mapper.Map<IEnumerable<PlaneTypeDTO>>(Database.Set<PlaneType>().Get());
        }

        public PlaneTypeDTO GetPlaneType(int? id)
        {
            if (id == null)
                throw new ValidationException("There is no plane type", "");

            var planeType = Database.Set<PlaneType>().Get().FirstOrDefault(x => x.Id == id.Value);

            if (planeType == null)
                throw new ValidationException("PlaneType not found", "");

            return mapper.Map<PlaneTypeDTO>(planeType);
        }
    }
}
