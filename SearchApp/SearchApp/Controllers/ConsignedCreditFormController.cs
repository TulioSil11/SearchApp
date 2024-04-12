using Microsoft.AspNetCore.Mvc;
using SearchApp.Interfaces.Services;
using SearchApp.ViewModels;

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
        var questions = await _appService.GetQuestions();
        return View(new ConsignedCreditFormViewModel() { Questions = questions});
    }

    public IActionResult Register(ConsignedCreditFormViewModel viewModel)
    {
        return View();
    }
}
