using Ecommerce.Services.Core.Logic.Concrete;
using Ecommerce.Services.Core.Logic.Contracts;
using Ecommerce.Services.Data.Contracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ecommerce.Services.Data.Concrete
{
    public class SqlFileReaderEngine : ISqlFileReaderEngine
    {
        private readonly IConfigurationSettings _configurationSettings;
        private readonly IAssetEngine _assetEngine;
        private readonly IMemoryCache _memoryCache;

        public SqlFileReaderEngine(IConfigurationSettings configurationSettings, IAssetEngine assetEngine, IMemoryCache memoryCache)
        {
            Guard.IsNotNull(configurationSettings, "configurationSettings");
            Guard.IsNotNull(assetEngine, "assetEngine");
            Guard.IsNotNull(memoryCache, "memoryCache");
            _configurationSettings = configurationSettings;
            _assetEngine = assetEngine;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Read in the code from the specified file to be used by ADO.Net.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public string GetSqlCode(string fileName, string databaseName)
        {
            Guard.IsNotNullOrEmpty(fileName, "fileName");
            Guard.IsNotNullOrEmpty(databaseName, "databaseName");

            // If the ADO.Net code dictionary has not been stored in memory yet.
            if (_memoryCache.Get("SqlCode") == null)
            {
                // Store a dictionary of string, string in memory for ADO.Net codes.
                _memoryCache.Set("SqlCode", new Dictionary<string, string>(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddDays(1)));
            }

            string code = string.Empty;

            // Determine if the code in the file name given has been stored in memory already.
            // If it has, retrieve the code from memory to be used by ADO.Net.
            bool fileNameKeyFound = ((Dictionary<string, string>)_memoryCache.Get("SqlCode")).ContainsKey(fileName);

            if (fileNameKeyFound)
            {
                code = ((Dictionary<string, string>)_memoryCache.Get("SqlCode"))[fileName];
            }
            // If the code has not yet been retrieved, then get it from the file.
            else
            {
                // Get the path to the file name specified.

                string absoluteFilePath = string.Format(@"{0}\{1}\", _assetEngine.GetFilePath(_configurationSettings.Settings("ScriptsFilePath")), databaseName);
                string sqlFileName = string.Format("{0}.sql", fileName);

                string filePath = Directory.GetFiles(absoluteFilePath, sqlFileName, SearchOption.AllDirectories).First();

                if (!string.IsNullOrEmpty(filePath))
                {
                    // Read in only the code from the file. Ignore var, and use areas.
                    string line = string.Empty;
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        using (StreamReader file = new StreamReader(stream))
                        {
                            bool getLine = false;

                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("\n", string.Empty).Replace("\t", string.Empty).Trim();

                                // Stop getting lines from --/code down.
                                if (line.Contains("--/code"))
                                {
                                    getLine = false;
                                }

                                // Get the sql line.
                                if (getLine)
                                {
                                    if (!string.IsNullOrEmpty(line))
                                    {
                                        code += line;
                                    }
                                }

                                // Start getting lines from --code down.
                                if (line.Contains("--code"))
                                {
                                    getLine = true;
                                }
                            }
                        }
                    }
                    code = code.Trim();

                    // Store the read in code in memory.
                    Dictionary<string, string> sqlCodes = (Dictionary<string, string>)_memoryCache.Get("SqlCode");
                    sqlCodes.Add(fileName, code);
                    _memoryCache.Set("SqlCode", sqlCodes);
                }
            }

            return code;
        }
    }
}
