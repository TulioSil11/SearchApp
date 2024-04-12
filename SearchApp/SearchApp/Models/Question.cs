namespace SearchApp.Models;

public class Question: BaseEntity
{
    public string Description { get; set; }
    public List<QuestionOption> QuestionOptions { get; set; }

    public Question(Guid id, string description, List<QuestionOption> questionOptions, DateTime? dateAdded)
    {
        Id = id;
        Description = description;
        QuestionOptions = questionOptions;
        DateAdded = dateAdded ?? DateTime.UtcNow;
        DateUpdated = DateTime.UtcNow;
    }

    public Question(string description, List<QuestionOption> questionOptions, DateTime? dateAdded): this(Guid.NewGuid(), description, questionOptions, dateAdded)
    {
    }
}
