using Nameless.Ledger.BI.Repositories.Interfaces;
using Nameless.Ledger.BI.Services.Interfaces;
using Nameless.Ledger.Models;
using Nameless.WebApi.Repositories;

namespace Nameless.Ledger.BI.Repositories.Implements
{
    public class SubCategoryRepository :
        GenericRepository<SubCategory>, ISubCategoryRepository, IContextAccesible
    {
        NamelessBIContext IContextAccesible.Context => (NamelessBIContext)this._context;

        CategoryRepository _catRepository;
        public SubCategoryRepository(NamelessBIContext context, CategoryRepository catRepository)
            : base(context)
        {
            this.DataIsSelected = SelectCategory;
            _catRepository = catRepository;
        }

        private async void SelectCategory(SubCategory subCategory)
        {
            subCategory.Category = await this._catRepository.GetById(subCategory.CategoryId);
        }
    }
}
