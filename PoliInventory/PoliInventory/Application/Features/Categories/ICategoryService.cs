using PoliInventory.Application.DTOs;

namespace PoliInventory.Application.Features.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto> Add(CategoryDto categoryDto);
        Task Delete(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<CategoryDto> Update(CategoryDto categoryDto);
    }
}