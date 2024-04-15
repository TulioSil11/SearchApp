namespace Domain.Models;

public class QuestionOption: BaseEntity
{
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public Option Option { get; set; }
    public string Description { get; set; }
    public bool IsSelected { get; set; }

    public QuestionOption() { }
    public QuestionOption(Guid id, Guid questionId, Option option, string description, bool isSelected, DateTime? dateAdded)
    {
        Id = id;
        QuestionId = questionId;
        Option = option;
        Description = description;
        DateAdded = dateAdded ?? DateTime.UtcNow;
        DateUpdated = DateTime.UtcNow;
    }

    public QuestionOption(Guid questionId, Option option, string description, bool isSelected, DateTime? dateAdded): this(Guid.NewGuid(), questionId, option, description, isSelected, dateAdded)
    {
    }
}
