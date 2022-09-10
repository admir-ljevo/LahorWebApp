﻿using AutoMapper;
using Lahor.API.Services.UserManager;
using Lahor.Services.BaseService;
using Microsoft.AspNetCore.Mvc;

namespace Lahor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<dtoEntity, dtoInsertEntity, dtoUpdateEntity> : ControllerBase where dtoEntity : class
    {
        private readonly IMapper Mapper;

        protected IBaseService<dtoEntity> BaseService { get; }

        public BaseController(IBaseService<dtoEntity> baseService, IMapper mapper)
        {
            BaseService = baseService;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<List<dtoEntity>> Get()
        {
            return await BaseService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<dtoEntity> Get(int id)
        {
            return await BaseService.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<dtoEntity> Post(dtoInsertEntity insertEntity)
        {
            return await BaseService.AddAsync(Mapper.Map<dtoEntity>(insertEntity));
        }

        [HttpPut("{id}")]
        public virtual async Task<dtoEntity> Put(int id, dtoUpdateEntity updateEntity)
        {
            return await BaseService.UpdateAsync(Mapper.Map<dtoEntity>(updateEntity));
        }

    }
}