namespace Ecommerce.Services.Data.Contracts
{
    public interface ISqlFileReaderEngine
    {
        string GetSqlCode(string fileName, string databaseName);
    }
}
