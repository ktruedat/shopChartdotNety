using FluentValidation;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using shopChart.Models;
using shopChart.Repository;

namespace shopChart.Logic;

public class ProductValidator : AbstractValidator<ProductModel>
{
    public ProductValidator(ICategoryRepositorySubset categoryRepositorySubset)
    {
        RuleFor(p => p).MustAsync(async (productModel, cancellation) =>
        {
            if (productModel.CategoryId == 0) return true;
            var category = await categoryRepositorySubset.GetCategoryByIdAsync(productModel.CategoryId);
            if (category?.Name != "Footwear") return true;
            return productModel.Price <= 200.00M;
        }).WithMessage("Price cannot be more than 200.00 for footwear");
    }
}