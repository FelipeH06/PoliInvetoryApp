using AutoMapper;
using PoliInventory.Application.DTOs;
using PoliInventory.Application.Interfaces;
using PoliInventory.Domain.Entities;

namespace PoliInventory.Application.Features.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Add(CategoryDto categoryDto)
        {
            CategoryEntity entity = _mapper.Map<CategoryEntity>(categoryDto);
            await _categoryRepository.Add(entity);
            if (!await _categoryRepository.SaveChanges()) throw new Exception("Ha ocurrido un erro al tratar de almacenar la categoria");

            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task Delete(int id)
        {
            CategoryEntity entity = await _categoryRepository.GetById(id);
            if (entity == null) throw new Exception("No se ha encontrado la categoria");

            _categoryRepository.Delete(entity);
            await _categoryRepository.SaveChanges();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            List<CategoryEntity> categories = await Task.Run(() => _categoryRepository.GetAll().ToList());
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            CategoryEntity entity = await _categoryRepository.GetById(id);
            if (entity == null) throw new Exception("No se ha encontrado la categoria");
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            CategoryEntity entity = await _categoryRepository.GetById(categoryDto.Id);
            if (entity == null) throw new Exception("No se ha encontrado la categoria");
            entity.Name = categoryDto.Name;
            entity.Description = categoryDto.Description;  
            entity.State = categoryDto.State;
             _categoryRepository.Update(entity);
            await _categoryRepository.SaveChanges();
            return _mapper.Map<CategoryDto>(entity);
        }
    }
}
