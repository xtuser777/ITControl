using ITControl.Presentation.Calls.Interfaces;
using ITControl.Presentation.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Controllers
{
    [Route("calls-reasons")]
    [ApiController]
    public class CallsReasonsController(
        ICallsReasonsView callsReasonsView) : ControllerBase
    {
        [HttpGet]
        public Shared.Responses.FindManyResponse<TranslatableField> Index()
        {
            var data = callsReasonsView.FindMany();
            return new Shared.Responses.FindManyResponse<TranslatableField>()
            {
                Data = data,
            };
        }
    }
}
