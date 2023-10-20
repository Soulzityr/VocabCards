using System.Text.Json;
using VocabCards.DataModels;

namespace VocabCards.Access
{
	public class RandomWordAPI
	{
		private string _endpointUrl = "https://random-word-api.herokuapp.com/word";

		public async Task<string?> GetWord()
		{
			try
			{
				var client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(_endpointUrl);
				if (response.IsSuccessStatusCode)
				{
					var word = await response.Content.ReadAsStringAsync();
					var deserializedWord = JsonSerializer.Deserialize<RandomWord>(word);
					return deserializedWord.Word;
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
