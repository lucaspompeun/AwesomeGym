using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Controllers
{
	[ApiController]
	[Route("api/professores")]
	public class ProfessoresController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok();
		}

		[HttpPost]
		public IActionResult Post()
		{
			return Ok();
		}

		[HttpPut]
		public IActionResult Put()
		{
			return Ok();
		}

		[HttpDelete]
		public IActionResult Delete()
		{
			return Ok();
		}
	}
}
