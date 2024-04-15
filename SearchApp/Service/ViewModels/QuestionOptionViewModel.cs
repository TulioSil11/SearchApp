using Domain.Models;

namespace Service.ViewModels;

public class QuestionOptionViewModel
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Option Option { get; set; }
    public string Description { get; set; }
    public bool IsSelected { get; set; }

    public QuestionOptionViewModel() { }

    public QuestionOptionViewModel(Guid questionId, Option option, string description)
    {
        QuestionId = questionId;
        Option = option;
        Description = description;
    }
}
