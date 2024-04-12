using SearchApp.Models;
using SearchApp.ViewModels;

namespace SearchApp.Mappers;

public static class QuestionOptionMapper
{
    public static QuestionOption MapToDomain(this QuestionOptionViewModel vm) =>
    new QuestionOption(vm.QuestionId, vm.Option, vm.Description, vm.IsSelected, null);

    public static QuestionOptionViewModel MapToViewModel(this QuestionOption model) =>
    new QuestionOptionViewModel()
    {
        QuestionId = model.QuestionId,
        Option = model.Option,
        Description = model.Description,
        IsSelected = model.IsSelected
    };
}
