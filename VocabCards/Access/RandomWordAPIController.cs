using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocabCards.Access
{
	[Route("api/[controller]")]
	[ApiController]
	public class RandomWordAPIController : ControllerBase
	{
		HttpClient client = new HttpClient();
		private string _endpointUrl { 
			get {
				return "https://random-word-api.herokuapp.com/word";
			} 
		}

		// GET: api/<RandomWordAPIController>
		[HttpGet]
		public async Task<string?> Get()
		{
			try
			{
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
		
		// GET api/<RandomWordAPIController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<RandomWordAPIController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<RandomWordAPIController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<RandomWordAPIController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
