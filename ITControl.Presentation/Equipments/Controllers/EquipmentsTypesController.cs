using ITControl.Presentation.Equipments.Interfaces;
using ITControl.Presentation.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Controllers
{
    [Route("equipments-types")]
    [ApiController]
    public class EquipmentsTypesController(
        IEquipmentsTypesView equipmentsTypesView) : ControllerBase
    {
        [HttpGet]
        public Shared.Responses.FindManyResponse<TranslatableField> Index()
        {
            var data = equipmentsTypesView.FindMany();
            return new Shared.Responses.FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
