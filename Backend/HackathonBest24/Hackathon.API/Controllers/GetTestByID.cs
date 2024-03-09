using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class GetTestByID : ControllerBase
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public GetTestByID(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		[HttpGet]
		public async Task<ActionResult> Get([FromQuery] int Id)
		{
			var pitanjaOdgovori = new List<TestPitanjaODgovori>();
			var test = await _applicationDbContext.TestoviPitanja.Include(x=>x.Pitanje).Where(t=>t.TestId== Id).ToListAsync();
			foreach (var t in test)
			{
				var odgovori = await _applicationDbContext.Odgovor.Where(o=>o.PitanjeId == t.PitanjeId).ToListAsync();
				pitanjaOdgovori.Add(new TestPitanjaODgovori()
				{
					Pitanje = t.Pitanje,
					Odgovori = odgovori
				});
			}
			return Ok(pitanjaOdgovori);
		}
		public class TestPitanjaODgovori
		{
			public Pitanje Pitanje { get; set; }
			public List<Odgovor> Odgovori { get; set; }
		}
	}
}
