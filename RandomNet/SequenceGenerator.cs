using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RandomNet.Exceptions;

namespace RandomNet
{
    public static class SequenceGenerator
    {
        public static async Task<IEnumerable<int>> GenerateAsync(int minValue, int maxValue)
        {
            if (minValue == maxValue) return new List<int> {minValue};
            if (maxValue < minValue) throw new ArgumentException("max cannot be less than min");
            if (maxValue - minValue + 1 > Math.Pow(10,3)) throw new ArgumentException("Range requested cannot be larger than 10,000");
            if (minValue < -Math.Pow(10, 8) || minValue > Math.Pow(10, 8)) throw new ArgumentException("Value of min must be between -1e9 and 1e9", nameof(minValue));
            if (maxValue < -Math.Pow(10, 8) || maxValue > Math.Pow(10, 8)) throw new ArgumentException("Value of max must be between -1e9 and 1e9", nameof(maxValue));

            var uri = $"http://www.random.org/sequences/?min={minValue}&max={maxValue}&col=1&base=10&format=plain&rnd=new";

            try
            {
                var response = await Request.Create(uri).GetResponseAsync();
                
                using (var dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream))
                {
                    var responseFromServer = reader.ReadToEnd();
                    response.Dispose();
                    return responseFromServer.Split('\n').Where(n => n.Length > 0).Select(int.Parse);
                }
            }
            catch (Exception e)
            {
                throw new ConnectionException("Unable to connect to Random.org.", e);
            }
        } 

    }
}
