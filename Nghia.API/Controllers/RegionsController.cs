using AutoMapper;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nghia.API.Data;
using Nghia.API.Models.Domain;
using Nghia.API.Models.DTO;
using Nghia.API.Repositories;

namespace Nghia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            //get regions from db
            var regions = await regionRepository.GetAllAsync();

            //convert to DTO manualy
            //var regionsDTO = new List<RegionDTO>();
            //foreach (var region in regions) 
            //{
            //    regionsDTO.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}


            //use mapper
            //var regionsDTO  = mapper.Map<List<RegionDTO>>(regions);
            //return Ok(regionsDTO);
            return Ok(mapper.Map<List<RegionDTO>>(regions));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            //get data from db
            var region = await regionRepository.GetByIdAsync(id);
            if (region == null) 
            {
                return NotFound();
            }
            
            return Ok(mapper.Map<RegionDTO>(region));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAndUpdateRegionDTO createRegionDTO)
        {
            //convert dto to model
            var region = mapper.Map<Region>(createRegionDTO);
            // add to dbcontext and save
            region = await regionRepository.CreateAsync(region);

            // convert model to dto to return 
            var regionDTO = mapper.Map<RegionDTO>(region);

            return CreatedAtAction(nameof(Get), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] CreateAndUpdateRegionDTO updateRegionDTO) 
        {
            //map to model to put it in the updateAsync
            var regionModel = mapper.Map<Region>(updateRegionDTO);

            //find the region
            var region = await regionRepository.UpdateAsync(id, regionModel);
            if(region == null)
            {
                return NotFound();
            }
            
            // convert model to dto to return 
        

            return Ok(mapper.Map<RegionDTO>(region));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id) 
        {
            var regionModel = await regionRepository.DeleteAsync(id);
            if(regionModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDTO>(regionModel));
        }

    }
}
