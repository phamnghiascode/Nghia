using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nghia.API.Models.Domain;
using Nghia.API.Models.DTO;
using Nghia.API.Repositories;

namespace Nghia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAndUpdateWalkDTO createAndUpdateWalkDTO)
        {
            // map from createDTO to model
            var createWalkModel = mapper.Map<Walk>(createAndUpdateWalkDTO);

            await walkRepository.CreateAsync(createWalkModel);

            //map from model to dto to return
            return Ok(mapper.Map<WalkDTO>(createWalkModel));
        }
    }
}
