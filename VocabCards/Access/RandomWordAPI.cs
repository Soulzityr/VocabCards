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
					return word;
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
