using System;
using System.Linq;

namespace UnipPim.Hotel.Pagamento.AntiCorruption
{
    public interface IConfigurationManager
    {
        string GetValue(string node);
    }
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetValue(string node)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
