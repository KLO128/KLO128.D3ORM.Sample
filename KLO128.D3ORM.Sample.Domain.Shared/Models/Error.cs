using System.Net;

namespace KLO128.D3ORM.Sample.Domain.Shared.Models
{
    public class Error : Exception
    {
        public string ErrCode { get; set; } = null!;

        public HttpStatusCode Status { get; set; } = HttpStatusCode.BadRequest;

        public string[] ErrArgs { get; set; } = null!;
    }
}
