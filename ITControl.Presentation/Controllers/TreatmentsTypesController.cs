using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("treatments-types")]
    [ApiController]
    public class TreatmentsTypesController(
        ITreatmentsTypesView treatmentsTypesView) : ControllerBase
    {
        [HttpGet]
        public FindManyResponse<TranslatableField> Index()
        {
            var data = treatmentsTypesView.FindMany();
            return new FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
