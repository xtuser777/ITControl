using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("calls-statuses")]
    [ApiController]
    public class CallsStatusesController(
        ICallsStatusesView callsStatusesView) : ControllerBase
    {
        [HttpGet]
        public FindManyResponse<TranslatableField> Index()
        {
            var data = callsStatusesView.FindMany();
            return new FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
