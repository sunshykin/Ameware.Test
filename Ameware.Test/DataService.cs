using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ameware.Test
{
	public class DataService
	{
		private readonly HttpClient _httpClient;
		public DataService(HttpClient httpClient) => _httpClient = httpClient;

		public async Task<IEnumerable<Item>> GetItemsAsync()
		{
			using var resp = await _httpClient.GetAsync("");
			var json = await resp.Content.ReadAsStringAsync();

			Console.WriteLine(json);
			return JsonConvert.DeserializeObject<Item[]>(json);
		}
	}
}