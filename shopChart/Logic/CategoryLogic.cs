using shopChart.Repository;

namespace shopChart.Logic;

public class CategoryLogic : ICategoryLogic
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryLogic(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


}