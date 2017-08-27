namespace Menou.Services.Data.Contracts
{
    public interface ISqlFileReader
    {
        string GetSqlCode(string fileName, string databaseName);
    }
}
