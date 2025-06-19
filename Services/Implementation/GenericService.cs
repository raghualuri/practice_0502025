using AutoMapper;
using practice_0502025.Application.Interfaces; // For IGenericService and IGenericRepository
using System.Collections.Generic;
using System.Threading.Tasks;

namespace practice_0502025.Services.Implementations
{
    public class GenericService<TEntity, TEntityDto> : IGenericService<TEntityDto>
        where TEntity : class, new()
        where TEntityDto : class, new()
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TEntityDto>>(entities);
        }

        public async Task<TEntityDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task<TEntityDto> CreateAsync(TEntityDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task UpdateAsync(int id, TEntityDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            _mapper.Map(dto, existingEntity);

            _repository.Update(existingEntity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _repository.SaveChangesAsync();
            }
            // Optional: throw exception if not found, depending on desired behavior
        }
    }
}
