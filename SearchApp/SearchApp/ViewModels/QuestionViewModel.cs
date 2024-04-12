namespace SearchApp.ViewModels;

public class QuestionViewModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public List<QuestionOptionViewModel> QuestionOptions { get; set; }

    public QuestionViewModel() { }

    public QuestionViewModel(string description, List<QuestionOptionViewModel> questionOptions)
    {
        Description = description;
        QuestionOptions = questionOptions;
    }
}
