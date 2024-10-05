using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace MessageBot;

public static class CalendarServer
{
    private static readonly string[] Scopes = [CalendarService.Scope.CalendarReadonly];
    private const string ApplicationName = "MessageBot";
    private const string CredentialsFilePath = "credentials.json";
    private const string TokenFilePath = "token.json";
    
    public static Events GetEvents()
    {
        var credential = GetUserCredential();
        var service = CreateCalendarService(credential);
        
        return FetchEvents(service);
    }
    
    private static UserCredential GetUserCredential()
    {
        using var stream = new FileStream(CredentialsFilePath, FileMode.Open, FileAccess.Read); // Abre o arquivo de credenciais
        
        return GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromStream(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(TokenFilePath, true)).Result; // Salva o token de acesso
    }
    
    private static CalendarService CreateCalendarService(UserCredential userCredential)
    {
        return new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = userCredential,
            ApplicationName = ApplicationName
        });
    }
    
    private static Events FetchEvents(CalendarService service)
    {
        var request = service.Events.List("primary");

        request.TimeMinDateTimeOffset = DateTimeOffset.Now;
        request.TimeMaxDateTimeOffset = DateTimeOffset.Now.AddDays(1);
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        return request.Execute();
    }
}