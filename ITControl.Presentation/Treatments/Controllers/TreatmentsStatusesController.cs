using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Treatments.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Controllers
{
    [Route("treatments-statuses")]
    [ApiController]
    public class TreatmentsStatusesController(
        ITreatmentsStatusesView treatmentsStatusesView) : ControllerBase
    {
        [HttpGet]
        public Shared.Responses.FindManyResponse<TranslatableField> Index()
        {
            var data = treatmentsStatusesView.FindMany();
            return new Shared.Responses.FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
