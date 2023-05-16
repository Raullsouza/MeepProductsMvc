namespace MeepProductsMvc.Exceptions
{
    public class OmieException : Exception
    {
        public HttpResponseMessage Response { get; }

        public OmieException(HttpResponseMessage response, string message) : base(message)
        {
            Response = response;
        }
    }

}
