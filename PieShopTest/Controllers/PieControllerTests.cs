using Microsoft.AspNetCore.Mvc;
using PieShop.Controllers;
using PieShop.ViewModels;
using PieShopTest.Mocks;

namespace PieShopTest.Controllers;

public class PieControllerTests
{
    [Fact]
    public void List_EmptyCategory_ReturnsAllPies()
    {
        //arange
        var mockPieRepository = RepositoryMocks.GetPieRepository();
        var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

        var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);
        
        //act
        var result = pieController.List("");
        
        //assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
        Assert.Equal(10, pieListViewModel.Pies.Count());
    }

}