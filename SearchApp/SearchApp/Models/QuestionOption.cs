namespace SearchApp.Models;

public class QuestionOption: BaseEntity
{
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public Option Option { get; set; }
    public string Description { get; set; }
    public bool IsSelected { get; set; }

    public QuestionOption() { }

    public QuestionOption(Guid questionId, Option option, string description)
    {
        QuestionId = questionId;
        Option = option;
        Description = description;
    }
}
