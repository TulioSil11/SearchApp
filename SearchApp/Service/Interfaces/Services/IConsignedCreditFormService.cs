using Service.ViewModels;

namespace Service.Interfaces.Services;

public interface IConsignedCreditFormService
{
    Task<IEnumerable<QuestionViewModel>> GetQuestions();
    void Register(ConsignedCreditFormViewModel viewModel);
}
