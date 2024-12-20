namespace IpApi;

public class IpApiClientException : Exception
{
    public IpApiClientException() : base()
    {
        
    }

    public IpApiClientException(string message) : base(message)
    {

    }

    public IpApiClientException(string message, Exception innerException) : base(message, innerException)
    {

    }
}