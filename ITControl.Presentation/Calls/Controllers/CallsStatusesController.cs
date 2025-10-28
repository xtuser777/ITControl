using ITControl.Presentation.Calls.Interfaces;
using ITControl.Presentation.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Controllers
{
    [Route("calls-statuses")]
    [ApiController]
    public class CallsStatusesController(
        ICallsStatusesView callsStatusesView) : ControllerBase
    {
        [HttpGet]
        public Shared.Responses.FindManyResponse<TranslatableField> Index()
        {
            var data = callsStatusesView.FindMany();
            return new Shared.Responses.FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
