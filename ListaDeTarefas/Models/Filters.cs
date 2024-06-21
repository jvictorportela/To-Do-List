namespace ListaDeTarefas.Models;

public class Filters
{
    public string FilterString { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public string Expiration { get; set; } = string.Empty;
    public string StatusId { get; set; } = string.Empty;

    public bool HasACategory => CategoryId.ToLower() != "todos";
    public bool HasAExpiration => Expiration.ToLower() != "todos";
    public bool HasAStatus => StatusId.ToLower() != "todos";

    public static Dictionary<string, string> ExpirationValuesFilter => 
        new Dictionary<string, string>
        {
            {"futuro", "Futuro" },
            {"passado", "Passado" },
            {"hoje", "Hoje" }
        };

    public bool IsPast => Expiration.ToLower() == "passado";
    public bool IsFuture => Expiration.ToLower() == "futuro";
    public bool IsToday => Expiration.ToLower() == "hoje";

    public Filters(string filterStringCompleted)
    {
        FilterString = filterStringCompleted ?? "todos-todos-todos";
        string[] filters = FilterString.Split('-');

        CategoryId = filters[0];
        Expiration = filters[1];
        StatusId = filters[2];
    }
}
