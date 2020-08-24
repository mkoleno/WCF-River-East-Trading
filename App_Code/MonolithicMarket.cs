using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class MonolithicMarket : IMonolithicMarket
{
	public async Task<IEnumerable<StockSymbol>> GetStockSymbols()
	{
		string requestUrl = @"https://finnhub.io/api/v1/stock/symbol?exchange=US&token=bt19fvf48v6qjjkjkn7g";
		using (var client = new HttpClient())
		{
			var content = await client.GetStringAsync(requestUrl);
			return JsonConvert.DeserializeObject<IEnumerable<StockSymbol>>(content);
		}

	}

	public async Task<IEnumerable<News>> GetNews()
	{
		string requestUrl = @"https://finnhub.io/api/v1/news?category=forex&minId=10&token=bt19fvf48v6qjjkjkn7g";
		using (var client = new HttpClient())
		{
			var content = await client.GetStringAsync(requestUrl);
			return JsonConvert.DeserializeObject<IEnumerable<News>>(content);
		}

	}

	public async Task<PriceTarget> GetStockPriceTarget(string tickerSymbol)
	{
		//string requestUrl = @"https://finnhub.io/api/v1/stock/price-target?symbol=JPM&token=bt19fvf48v6qjjkjkn7g";
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Formatting = Formatting.None,
            Converters = new List<JsonConverter> { new DecimalConverter() }
        };

        string requestUrl = String.Format(@"https://finnhub.io/api/v1/stock/price-target?symbol={0}&token=bt19fvf48v6qjjkjkn7g", tickerSymbol);
        using (var client = new HttpClient())
		{
            string content = await client.GetStringAsync(requestUrl);
            PriceTarget returnTarget = null;
            try
            {
                 returnTarget = JsonConvert.DeserializeObject<PriceTarget>(content, settings);
            }
            catch (JsonException je)
            {
                Console.WriteLine(je.Message);
            }

            return returnTarget;
		}

	}
}

class DecimalConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(decimal) || objectType == typeof(decimal?));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
        {
            return token.ToObject<decimal>();
        }
        if (token.Type == JTokenType.String)
        {
            // customize this to suit your needs
            return Decimal.Parse(token.ToString());
        }
        if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
        {
            return null;
        }
        throw new JsonSerializationException("Unexpected token type: " +
                                              token.Type.ToString());
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
