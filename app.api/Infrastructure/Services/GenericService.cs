using app.api.Core;
using app.api.Features.Productos.Dtos;
using app.api.Infrastructure.Data;
using app.api.SharedKernel;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Features.Productos.Services
{
    public class GenericService<TSource, TTarget, TIdType> : IGenericService<TSource, TTarget, TIdType> where TSource : IAggregateRoot where TTarget : class, new()
    {
        private readonly IGenericRepository<TSource, TIdType> _repository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TTarget>().ReverseMap());

        public GenericService(IGenericRepository<TSource, TIdType> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(TTarget newProducto)
        {
            var producto = _mapper.Map<TTarget, TSource>(newProducto);
            await _repository.AddAsync(producto);
        }

        public async Task Update(TTarget newProducto)
        {
            var producto = _mapper.Map<TTarget, TSource>(newProducto);
            await _repository.UpdateAsync(producto);
        }

        public async Task Delete(TIdType idProducto)
        {
            await _repository.DeleteAsync(idProducto);
        }

        public async Task Delete(TTarget newProducto)
        {
            var producto = _mapper.Map<TTarget, TSource>(newProducto);
            await _repository.DeleteAsync(producto);
        }

        public async Task<IEnumerable<TTarget>> GetAll()
        {
            return await _repository.GetAll().ProjectTo<TTarget>(_config).ToListAsync();
        }

        public async Task<TTarget> Get(TIdType idProducto)
        {
            var producto = await _repository.GetByIdAsync(idProducto);
            return _mapper.Map<TSource, TTarget>(producto);
        }

    }
}
