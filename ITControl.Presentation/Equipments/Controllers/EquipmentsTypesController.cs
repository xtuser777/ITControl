using ITControl.Application.Equipments.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Controllers
{
    [Route("equipments-types")]
    [ApiController]
    public class EquipmentsTypesController(
        IEquipmentsTypesView equipmentsTypesView) : ControllerBase
    {
        [HttpGet]
        public FindManyResponse<TranslatableField> Index()
        {
            var data = equipmentsTypesView.FindMany();
            return new FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
