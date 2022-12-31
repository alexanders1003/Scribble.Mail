namespace Scribble.Mail.Web;

public class MailSenderConfiguration
{
    private readonly string _host = null!;
    public string Host
    {
        get => _host;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(Host),
                    $"'{nameof(Host)}' cannot be null or empty. Check the appsettings.json file");
            }

            _host = value;
        }
    }

    private readonly int _port;
    public int Port
    {
        get => _port;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    $"'{nameof(Port)}' cannot be less than zero. Check the appsettings.json file", nameof(Port));
            }

            _port = value;
        }
    }

    private readonly string _senderName = null!;
    public string SenderName
    {
        get => _senderName;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(SenderName),
                    $"'{nameof(SenderName)}' cannot be null or empty. Check the appsettings.json file");
            }

            _senderName = value;
        }
    }

    private readonly string _senderAddress = null!;
    public string SenderAddress
    {
        get => _senderAddress;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(SenderAddress),
                    $"'{nameof(SenderAddress)}' cannot be null or empty. Check the appsettings.json file");
            }

            _senderAddress = value;
        }
    }

    private readonly string _password = null!;
    public string Password
    {
        get => _password;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(Password),
                    $"'{nameof(Password)}' cannot be null or empty. Check the appsettings.json file");
            }

            _password = value;
        }
    }
    public bool UseSsl { get; set; }
}