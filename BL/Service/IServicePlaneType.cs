using System.Collections.Generic;
using DTO;

namespace BL.Service
{
    public interface IServicePlaneType
    {
        PlaneTypeDTO GetPlaneType(int? id);
        IEnumerable<PlaneTypeDTO> GetPlaneTypes();
    }
}