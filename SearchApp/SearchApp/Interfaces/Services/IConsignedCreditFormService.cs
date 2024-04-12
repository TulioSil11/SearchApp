using SearchApp.ViewModels;

namespace SearchApp.Interfaces.Services;

public interface IConsignedCreditFormService
{
    Task<IEnumerable<QuestionViewModel>> GetQuestions();
    void Register(ConsignedCreditFormViewModel viewModel);
}
