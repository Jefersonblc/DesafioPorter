using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPorter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DesafioController : ControllerBase
    {
        [HttpGet(Name = "NumberToWords")]
        public ActionResult<string> NumberToWords(int number)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "ArraySum")]
        public ActionResult<string> ArraySum(params int[] numbers)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "EvaluateExpression")]
        public ActionResult<int> EvaluateExpression(string expression)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "UniqueList")]
        public ActionResult<string> UniqueList(params object[] objects)
        {
            throw new NotImplementedException();
        }

    }
}
