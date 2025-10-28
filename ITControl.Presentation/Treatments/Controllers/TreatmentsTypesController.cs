using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Treatments.Interfaces;

namespace ITControl.Presentation.Treatments.Controllers
{
    [Route("treatments-types")]
    [ApiController]
    public class TreatmentsTypesController(
        ITreatmentsTypesView treatmentsTypesView) : ControllerBase
    {
        [HttpGet]
        public Shared.Responses.FindManyResponse<TranslatableField> Index()
        {
            var data = treatmentsTypesView.FindMany();
            return new Shared.Responses.FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
