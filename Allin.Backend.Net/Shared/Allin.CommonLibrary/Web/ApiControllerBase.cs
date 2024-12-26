using Microsoft.AspNetCore.Mvc;

namespace Allin.Common.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
