namespace NLayer.Core.DTOs
{
    public class TokenDto
    {
        public string Token { get; set; }
        public TokenDto(string token)
        {
            Token = token;
        }
    }
}
