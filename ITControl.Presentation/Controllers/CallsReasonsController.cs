using ITControl.Application.Calls.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("calls-reasons")]
    [ApiController]
    public class CallsReasonsController(
        ICallsReasonsView callsReasonsView) : ControllerBase
    {
        [HttpGet]
        public FindManyResponse<TranslatableField> Index()
        {
            var data = callsReasonsView.FindMany();
            return new FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
