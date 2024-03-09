using Hackathon.API.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentPitanjeController : ControllerBase
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public StudentPitanjeController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] VM_Korisnik_Odgovor request)
		{
			var studentTestID = await _applicationDbContext.StudentiTestovi.Where(s => s.StudentId == request.StudentID && request.StudentID == s.TestId).FirstOrDefaultAsync();
			if(studentTestID == null)
			{
				studentTestID = new StudentiTestovi()
				{
					StudentId = request.StudentID,
					TestId = request.TestID,
					DatumPocetka = DateTime.Now
				};
				_applicationDbContext.Add(studentTestID);
				_applicationDbContext.SaveChanges();
			}
			var noviZapis = new StudentiTestoviOdgovori()
			{
				OdgovorId = request.OdgovorID,
				StudentiTestoviId = studentTestID.Id
			};
			_applicationDbContext.Add(noviZapis);
			_applicationDbContext.SaveChanges();
			var obj = _applicationDbContext.StudentiTestoviOdgovori.Include(s=>s.Odgovor).Where(s=>s.Id==noviZapis.Id).FirstOrDefault();
			obj.Odgovor.Esejsko = request.esejsko;
			_applicationDbContext.Update(obj);
			_applicationDbContext.SaveChanges();
			return Ok(noviZapis);
		}
	}
	public class VM_Korisnik_Odgovor
	{
		public int StudentID { get; set; }
		public int TestID { get; set; }
		public int? OdgovorID { get; set; }
		public string? esejsko { get; set; }
	}
}
