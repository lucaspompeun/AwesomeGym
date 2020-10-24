using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Controllers
{
	[ApiController]
	[Route("api/alunos")]
	public class AlunosController : ControllerBase
	{
		private readonly AwesomeGymDbContext _awesomeGymDbContext;
		public AlunosController(AwesomeGymDbContext awesomeDbContext)
		{
			_awesomeGymDbContext = awesomeDbContext;
		}

		[HttpGet]
		public IActionResult Get()
		{
            var alunos = _awesomeGymDbContext
				.Alunos
				.ToList();

			return Ok(alunos);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var alunos = _awesomeGymDbContext.Alunos.SingleOrDefault(a => a.Id == id);

            if (alunos == null)
            {
				return NotFound();
            }

			return Ok(alunos);
		}

		[HttpPost]
		public IActionResult Post([FromBody]Aluno aluno)
		{
			var professor = new Professor("professor1", "endereco 1", aluno.IdUnidade);
			_awesomeGymDbContext.Professores.Add(professor);
			_awesomeGymDbContext.SaveChanges();

			_awesomeGymDbContext.Alunos.Add(aluno);
			_awesomeGymDbContext.SaveChanges();

			return NoContent();
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Aluno aluno)
		{
			if (!_awesomeGymDbContext.Alunos.Any(a => a.Id == id))
            {
				return NotFound();
            }

			_awesomeGymDbContext.Alunos.Update(aluno);
			_awesomeGymDbContext.SaveChanges();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var aluno = _awesomeGymDbContext.Alunos.SingleOrDefault(aluno => aluno.Id == id);

			if (aluno == null)
            {
				return NotFound();
            }

			aluno.MudarStatusParaInativo();
			_awesomeGymDbContext.SaveChanges();

			return NoContent();
		}
	}
}
