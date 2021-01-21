using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Persistence.Services
{
    public sealed class Cache
    {
        /*
         * TODO:
         * - expiration
         * - unused
         */
        private static Cache _instance;
        private static readonly object _lock = new object();

        private const string KeyPrefix = "CobreezeCache";

        private Dictionary<string, string> _cache = new Dictionary<string, string>();

        private Cache() { }

        public static Cache GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Cache();
                    }
                }
            }

            return _instance;
        }

        public T Get<T>(string key)
        {
            key = $"{KeyPrefix}_{key}";

            if (_cache.ContainsKey(key))
            {
                string data = _cache[key];
                T parsedData = JsonSerializer.Deserialize<T>(data);
                return parsedData;
            }

            return default(T);
        }

        public void Set(string key, object data)
        {
            key = $"{KeyPrefix}_{key}";
            string formattedData = JsonSerializer.Serialize(data);
            _cache[key] = formattedData;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n\n\n--------------- {KeyPrefix.ToUpper()} ---------------\n\n");
            stringBuilder.Append("Keys:\n");
            foreach (string key in _cache.Keys)
            {
                stringBuilder.Append($"\t- {key}\n");
            }
            stringBuilder.Append("\n");
            stringBuilder.Append("Values:\n");
            foreach (string key in _cache.Keys)
            {
                stringBuilder.Append($"\n\t- {key}:\n\t\t{_cache[key]}\n\n");
            }
            stringBuilder.Append($"\n\n---------------------------------------------\n\n\n");
            return stringBuilder.ToString();
        }
    }
}
