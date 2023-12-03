using AutoMapper;
using Moq;
using PoliInventory.Application.DTOs;
using PoliInventory.Application.Features.Categories;
using PoliInventory.Application.Interfaces;
using PoliInventory.Application.Mappings;
using PoliInventory.Domain.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PoliInventory.Test.Application.Features.Categories
{
    public class CategoryServiceTest
    {
        /// <summary>
        /// Mock of category repository
        /// </summary>
        public Mock<IGenericRepository<CategoryEntity>> _categoryRepositoryMock = new Mock<IGenericRepository<CategoryEntity>>();

        [Fact]
        public async Task GetById_Success_Test()
        {
            // Arrange
            _categoryRepositoryMock.Setup(m => m.GetById(1)).ReturnsAsync(new CategoryEntity()
            {
                Id = 1,
                Name = "Test Category",
                CreationDate = DateTime.Now,
                Description = "Test Category Descripton",
                State = true
            });

            //auto mapper configuration
            MapperConfiguration? mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            IMapper? mapper = mockMapper.CreateMapper();

            CategoryService categoryService = new CategoryService(_categoryRepositoryMock.Object, mapper);

            // Act

            CategoryDto category = await categoryService.GetById(1);

            //Assert
            Assert.NotNull(category);
        }

        [Fact]
        public async Task GetById_NotFound_Test()
        {
            // Arrange
            _categoryRepositoryMock.Setup(m => m.GetById(1)).ReturnsAsync(new CategoryEntity()
            {
                Id = 1,
                Name = "Test Category",
                CreationDate = DateTime.Now,
                Description = "Test Category Descripton",
                State = true
            });

            //auto mapper configuration
            MapperConfiguration? mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            IMapper? mapper = mockMapper.CreateMapper();

            CategoryService categoryService = new CategoryService(_categoryRepositoryMock.Object, mapper);

            // Act
            Exception exception = await Assert.ThrowsAsync<Exception>(() => categoryService.GetById(2));

            //Assert
            Assert.Equal("No se ha encontrado la categoria", exception.Message);
        }
    }
}
