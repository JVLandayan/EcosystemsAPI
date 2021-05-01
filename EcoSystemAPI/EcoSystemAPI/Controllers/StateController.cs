using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcoSystemAPI.uow.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using EcoSystemAPI.Core.Dtos;
using EcoSystemAPI.Context.Models;
using EcoSystemAPI.core.Dtos;

namespace EcoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStateRepo _repository;
        private readonly IMapper _mapper;

        public StateController(IConfiguration configuration, IStateRepo repository, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetStateById")]
        public ActionResult<IEnumerable<StateReadDto>> GetStateById(int id)
        {
            var stateData = _repository.GetStateById(id);
            if (stateData != null)
            {
                return Ok(_mapper.Map<StateReadDto>(stateData));
            }
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<StateReadDto> CreateState(StateCreateDto createDto)
        {
            var stateModel = _mapper.Map<State>(createDto);
            _repository.CreateState(stateModel);
            _repository.SaveChanges();

            var stateReadDto = _mapper.Map<StateReadDto>(stateModel);
            return CreatedAtRoute(nameof(GetStateById), new { Id = stateReadDto.Id }, stateReadDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult UpdateState(int id, StateUpdateDto stateUpdateDto)
        {
            var stateModelfromRepo = _repository.GetStateById(id);
            if (stateModelfromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(stateUpdateDto, stateModelfromRepo);
            _repository.UpdateState(stateModelfromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


    }
}
