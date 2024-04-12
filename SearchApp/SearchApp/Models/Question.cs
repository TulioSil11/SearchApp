namespace SearchApp.Models;

public class Question: BaseEntity
{
    public string Description { get; set; }
    public List<QuestionOption> QuestionOptions { get; set; }

    public Question() { }

    public Question(string description, List<QuestionOption> questionOptions)
    {
        Description = description;
        QuestionOptions = questionOptions;
    }
}
