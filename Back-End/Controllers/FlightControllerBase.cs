using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightControllerBase : ControllerBase
    {
        private ISender? _mediator;
        //Nếu _mediatorlà null, phía bên phải của ??=toán tử sẽ được thực thi.
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();//lấy ISenderphiên bản từ vùng chứa Dependency Injection
        //GetRequiredServiceđưa ra ngoại lệ nếu ISender chưa được đăng ký trong DI
    }
}
