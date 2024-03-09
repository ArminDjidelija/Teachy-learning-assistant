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
		public async Task<ActionResult> Post([FromBody] VM_Korisnik_Response request)
		{
			var studentTestID = await _applicationDbContext.StudentiTestovi.Where(s => s.StudentId == request.listaKorisnika[0].StudentID && request.listaKorisnika[0].TestID == s.TestId).FirstOrDefaultAsync();
			if(studentTestID == null)
			{
				studentTestID = new StudentiTestovi()
				{
					StudentId = request.listaKorisnika[0].StudentID,
					TestId = request.listaKorisnika[0].TestID,
					DatumPocetka = DateTime.Now
				};
				_applicationDbContext.Add(studentTestID);
				_applicationDbContext.SaveChanges();
			}
            var noviZapis = new List<StudentiTestoviOdgovori>();
            foreach (var item in request.listaKorisnika)
			{
				if (item != null)
				{
                    noviZapis.Add(new StudentiTestoviOdgovori
                    {
                        OdgovorId = item.OdgovorID,
                        StudentiTestoviId = studentTestID.Id

                    });
                }

			}
			
			_applicationDbContext.AddRange(noviZapis);
			_applicationDbContext.SaveChanges();
			var obj = _applicationDbContext.StudentiTestoviOdgovori.Include(s=>s.Odgovor).Where(s=>s.StudentiTestoviId==studentTestID.Id).ToList();
            var obj2 = _applicationDbContext.StudentiTestovi.Where(x => x.StudentId == request.listaKorisnika[0].StudentID && x.TestId == request.listaKorisnika[0].TestID).FirstOrDefault();

            obj2.DatumZavrsetka = DateTime.Now;



			_applicationDbContext.UpdateRange(obj);

            _applicationDbContext.SaveChanges();

			
			
			return Ok(obj);
		}
	}

	public class VM_Korisnik_Response
	{
		public List<VM_Korisnik_Odgovor> listaKorisnika { get; set; }
	}
	public class VM_Korisnik_Odgovor
	{
		public int StudentID { get; set; }
		public int TestID { get; set; }
		public int? OdgovorID { get; set; }
		public string? esejsko { get; set; }
	}
}
