using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Services;
using Service.ViewModels;

namespace SearchApp.Controllers;

public class ConsignedCreditFormController: Controller
{
    private readonly IConsignedCreditFormService _appService;

    public ConsignedCreditFormController(IConsignedCreditFormService appService)
    {
        _appService = appService;
    }


    public async Task<IActionResult> Index()
    {       
        var questions = (await _appService.GetQuestions()).ToList();
        return View(new ConsignedCreditFormViewModel() { Questions = questions});
    }

    public IActionResult Register(ConsignedCreditFormViewModel viewModel)
    {
        try
        {
            _appService.Register(viewModel);
            return View("Result");
        }
        catch (Exception ex)
        {
            return View("Result", ex.Message);
            throw;
        }
        
    }
}
