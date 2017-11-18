namespace GoogleSearchSeo.Core.Logic.Conctract
{
    public interface IAssetEngine
    {
        /// <summary>
        /// Attempts to determine the absolute path of the relative file path passed in using the system runtime.
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        string GetFilePath(string relativeFilePath);
    }
}
