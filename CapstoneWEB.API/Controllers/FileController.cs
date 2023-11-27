using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Services;

namespace CapstoneWEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _fileService.GetAll();
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(FileInsertDTO file)
        {
            var result = await _fileService.Insert(file);
            if (!result)
                return BadRequest("Ocurrió un error");

            return Ok(result);

        }
    }
}
