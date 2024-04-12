using SearchApp.ViewModels;

namespace SearchApp.Interfaces.Services;

public interface IConsignedCreditFormService
{
    Task<List<QuestionViewModel>> GetQuestions();
    void Register(ConsignedCreditFormViewModel viewModel);
}
