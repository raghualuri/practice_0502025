namespace practice_0502025.Application.Interfaces
{
    public interface IGenericService<TEntity,TEntityDto>
        where TEntityDto : class // Or define a common base DTO with an Id
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto?> GetByIdAsync(int id); // Changed to TEntityDto? for nullability
        Task<TEntityDto> CreateAsync(TEntityDto dto);
        Task UpdateAsync(int id, TEntityDto dto);
        Task DeleteAsync(int id);
    }
}
