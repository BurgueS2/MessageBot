using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageBot;

public class MessengerService
{
    private const string AccountSid = "ACXXXXXXXX"; // Substitua pelo SID da sua conta
    private const string AuthToken = "your_auth_token"; // Substitua pelo token de autenticação da sua conta
    private const string FromPhoneNumber = "whatsapp:+15017122661"; // Substitua pelo número de telefone da sua conta

    static MessengerService()
    {
        TwilioClient.Init(AccountSid, AuthToken);
    }

    public static void SendMessage(string message, List<string> numbers)
    {
        foreach (var number in numbers)
        {
            var messageOptions = CreateMessageOptions(message, number);
            var msg = MessageResource.Create(messageOptions);
            Console.WriteLine($"Mensagem enviada para {number}: {msg.Sid}");
        }
    }

    private static CreateMessageOptions CreateMessageOptions(string message, string number)
    {
        return new CreateMessageOptions(new PhoneNumber($"whatsapp:{number}"))
        {
            From = new PhoneNumber(FromPhoneNumber),
            Body = message
        };
    }
}