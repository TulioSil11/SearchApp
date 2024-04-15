using Domain.Models;
using Service.ViewModels;

namespace Services.Mappers;

public static class QuestionMapper
{
    public static Question MapToDomain(this QuestionViewModel vm) =>
    new Question(vm.Description, vm.QuestionOptions.Select(x => x.MapToDomain()).ToList(), null);

    public static QuestionViewModel MapToViewModel(this Question model) =>
    new QuestionViewModel()
    {
        Id = model.Id,
        Description = model.Description,
        QuestionOptions = model.QuestionOptions.Select(x => x.MapToViewModel()).ToList()
    };
}
