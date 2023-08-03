namespace KLO128.D3ORM.Sample.Presentation.WebApi.Extensions
{
    public class ClaimDTO
    {
        public string Type { get; set; } = null!;

        public string Value { get; set; } = null!;

        public ClaimDTO(string Type, string Value)
        {
            this.Type = Type;
            this.Value = Value;
        }

        public ClaimDTO()
        {

        }
    }
}
