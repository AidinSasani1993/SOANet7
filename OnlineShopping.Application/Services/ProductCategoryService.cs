using AutoMapper;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.ProductCategory;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Services
{
    [ScopedService]
    public class ProductCategoryService : IProductCategoryService
    {

        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<OperationResult> CreateAsync(CreateOrUpdateProductCategory input)
        {
            var operation = new OperationResult();

            if (await productCategoryRepository.Exists(a => a.Name == input.Name)) 
            {
                return operation.Failed("Not");
            }
            var category = new ProductCategory
                (input.Name, input.Description, input.Picture,
                    input.PictureAlt, input.PictureTitle, input.Keywords,
                        input.MetaDescription, input.Slug);

             await productCategoryRepository.InsertAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        }

        public async Task<ProductCategoryDto> GetAsync(Guid id)
        {
            var query = await productCategoryRepository.GetByIdAsync(id);
            return mapper.Map<ProductCategoryDto>(query);
        }

        public List<ProductCategoryDto> GetList()
        {
            var query =  productCategoryRepository.GetAllAsync();
            return mapper.Map<List<ProductCategoryDto>>(query);
        }

        public async Task<List<ProductCategoryDto>> GetListAsync()
        {
            var query = await productCategoryRepository.GetAllAsync();
            return mapper.Map<List<ProductCategoryDto>>(query);
        }

        public async Task<OperationResult> UpdateMetaDescriptionAsync(Guid id, CreateOrUpdateProductCategory input)
        {
            var operation = new OperationResult();
            var category = await productCategoryRepository.GetByIdAsync(id);

            if (await productCategoryRepository.Exists(a => a.Id != id))
            {
                return operation.Failed("NotFound");
            }

            category.ModifyMetaDescription(input.MetaDescription);
            await productCategoryRepository.UpdateAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        }

        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductCategory input)
        {
            var operation = new OperationResult();
            var category = await productCategoryRepository.GetByIdAsync(id);

            //if (await productCategoryRepository.Exists(a => a.Id != id))
            //{
            //    return operation.Failed("Not");
            //}

            category.Modify(input.Name, input.Description, input.Picture,
                            input.PictureAlt, input.PictureTitle, input.Keywords,
                            input.MetaDescription, input.Slug);
            await productCategoryRepository.UpdateAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        }

        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();
            var category = await productCategoryRepository.GetByIdAsync(id);

            if (await productCategoryRepository.Exists(a => a.Id != id)) 
            {
                return operation.NotFound(ApplicationMessages.RecordNotFound);
            }

            category.Remove();
            await productCategoryRepository.SaveChangesAsync();
            return operation.Succedded(ApplicationMessages.Succeded);
        }

        public async Task<int> GetCountProductCategoryAsync()
        {
            return await productCategoryRepository.GetCountProductCategoryAsync();
        }
    }
}
