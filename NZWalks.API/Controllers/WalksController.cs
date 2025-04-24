﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper , IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }


        //POST: api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //map dto to domain 
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //map domain to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }


        //GET: api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            //map domain to dto
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        //GET: api/walks/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //map domain to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //PUT: api/walks/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            //map dto to domain 
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //map domain to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));


        }

        //DELETE: api/walks/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);
            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }
            //map domain to dto
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));

        }

    }
}
