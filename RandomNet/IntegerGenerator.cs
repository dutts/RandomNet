using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNet
{
    public static class RandomOrg
    {
        public static IEnumerable<int> IntegerGenerator(int numberOfInts, int minValue, int maxValue)
        {
            var uri = $"http://www.random.org/integers/?num={numberOfInts}&min={minValue}&max={maxValue}&col=1&base=10&format=plain&rnd=new";

            try
            {
                using (var response = Request.Create(uri).GetResponse())
                using (var dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream))
                {
                    var responseFromServer = reader.ReadToEnd();
                    var numbers = responseFromServer.Split('\n');
                    return numbers.Where(n => n.Length > 0).Select(int.Parse);
                }
            }
            catch (Exception e)
            {
                throw new ConnectionException("Unable to connect to Random.org.", e);
            }
        }

        public static async Task<IEnumerable<int>> IntegerGeneratorAsync(int numberOfInts, int minValue, int maxValue)
        {
            var uri = $"http://www.random.org/integers/?num={numberOfInts}&min={minValue}&max={maxValue}";

            try
            {
                var response = await Request.Create(uri).GetResponseAsync();
                
                using (var dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream))
                {
                    var responseFromServer = reader.ReadToEnd();
                    response.Dispose();
                    return responseFromServer.Split('\n').Select(int.Parse);
                }
            }
            catch (Exception e)
            {
                throw new ConnectionException("Unable to connect to Random.org.", e);
            }
        } 

    }
}
