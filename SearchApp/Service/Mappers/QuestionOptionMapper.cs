using Domain.Models;
using Service.ViewModels;
namespace Services.Mappers;

public static class QuestionOptionMapper
{
    public static QuestionOption MapToDomain(this QuestionOptionViewModel vm) =>
    new QuestionOption(vm.QuestionId, vm.Option, vm.Description, vm.IsSelected, null);

    public static QuestionOptionViewModel MapToViewModel(this QuestionOption model) =>
    new QuestionOptionViewModel()
    {
        Id = model.Id,
        QuestionId = model.QuestionId,
        Option = model.Option,
        Description = model.Description,
        IsSelected = model.IsSelected
    };
}
