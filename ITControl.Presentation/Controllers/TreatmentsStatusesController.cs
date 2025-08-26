using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("treatments-statuses")]
    [ApiController]
    public class TreatmentsStatusesController(
        ITreatmentsStatusesView treatmentsStatusesView) : ControllerBase
    {
        [HttpGet]
        public FindManyResponse<TranslatableField> Index()
        {
            var data = treatmentsStatusesView.FindMany();
            return new FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
