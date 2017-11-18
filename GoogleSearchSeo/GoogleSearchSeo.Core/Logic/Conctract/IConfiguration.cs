namespace GoogleSearchSeo.Core.Logic.Conctract
{
    public interface IConfiguration
    {
        /// <summary>
        /// Retreives the value of hte key passed in as a string.
        /// </summary>
        /// <param name="key">The key to get the corresponding value for.</param>
        /// <returns></returns>
        string Get(string key);
    }
}
