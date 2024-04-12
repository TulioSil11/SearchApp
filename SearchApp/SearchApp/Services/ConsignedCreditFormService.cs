using SearchApp.Interfaces.Repositories;
using SearchApp.Interfaces.Services;
using SearchApp.Models;
using SearchApp.ViewModels;
using System.Collections.Generic;

namespace SearchApp.Services;

public class ConsignedCreditFormService : IConsignedCreditFormService
{
    private readonly IRepositoryBase<Person> _personRepository;
    private readonly IRepositoryBase<Response> _responseRepository;
    private readonly IRepositoryBase<Question> _questionRepository;

    public ConsignedCreditFormService(IRepositoryBase<Person> personRepository, 
                                      IRepositoryBase<Response> responseRepository,
                                      IRepositoryBase<Question> questionRepository)
    {
        _personRepository = personRepository;
        _responseRepository = responseRepository;
        _questionRepository = questionRepository;
    }

    public async Task<List<QuestionViewModel>> GetQuestions()
    {
      //  var questions = await _questionRepository.GetAsync();
       // return questions;

        List<QuestionViewModel> questions = new();
        var question1 = new QuestionViewModel();
        question1.Id = Guid.NewGuid();
        question1.Description = "1. Qual sua faixa de Idade:";
        question1.QuestionOptions = new List<QuestionOptionViewModel>
        {
            new QuestionOptionViewModel(question1.Id, Option.A, "a. Até 30 Anos"),
            new QuestionOptionViewModel(question1.Id, Option.B, "b. De 30 a 50 anos"),
            new QuestionOptionViewModel(question1.Id, Option.C, "c. De 50 a 65 anos"),
            new QuestionOptionViewModel(question1.Id, Option.D, "d. Acima de 65 anos"),
        };

        var question2 = new QuestionViewModel();
        question2.Id = Guid.NewGuid();
        question2.Description = "2. Qual seu convênio:";
        question2.QuestionOptions = new List<QuestionOptionViewModel>
        {
            new QuestionOptionViewModel(question2.Id, Option.A, "a. INSS"),
            new QuestionOptionViewModel(question2.Id, Option.B, "b. SIAPE"),
            new QuestionOptionViewModel(question2.Id, Option.C, "c. Forças Armadas"),
            new QuestionOptionViewModel(question2.Id, Option.D, "d. Outros"),
        };

        var question3 = new QuestionViewModel();
        question3.Id = Guid.NewGuid();
        question3.Description = "3. Qual sua faixa salarial:";
        question3.QuestionOptions = new List<QuestionOptionViewModel>
        {
            new QuestionOptionViewModel(question3.Id, Option.A, "a. Até 2 SM"),
            new QuestionOptionViewModel(question3.Id, Option.B, "b. De 2 a 4 SM"),
            new QuestionOptionViewModel(question3.Id, Option.C, "c. De 4 a 6 SM"),
            new QuestionOptionViewModel(question3.Id, Option.D, "d. Acima de 6 SM"),
        };

        var question4 = new QuestionViewModel();
        question4.Id = Guid.NewGuid();
        question4.Description = "4. Por que você realizou o empréstimo:";
        question4.QuestionOptions = new List<QuestionOptionViewModel>
        {
            new QuestionOptionViewModel(question4.Id, Option.A, "a. Pagar contas"),
            new QuestionOptionViewModel(question4.Id, Option.B, "b. Reforma da Casa"),
            new QuestionOptionViewModel(question4.Id, Option.C, "c. Compra de Carro"),
            new QuestionOptionViewModel(question4.Id, Option.D, "c. Compra de Carro"),
        };

        questions.Add(question1);
        questions.Add(question2);
        questions.Add(question3);
        questions.Add(question4);
        return await Task.FromResult(questions);
    }

    public void Register(ConsignedCreditFormViewModel viewModel)
    {
        var isValid = viewModel.IsValid();
        if (!isValid.Item1) throw new Exception(isValid.Item2);

        var person = new Person(viewModel.NameOfUser, viewModel.CPF, viewModel.Phone, null);
        _personRepository.Post(person);
        _personRepository.Commit();

        foreach (var question in viewModel.Questions)
        {
            var response = new Response(person.Id, question.Id, question.QuestionOptions.FirstOrDefault(qo => qo.IsSelected).Id, null);
           _responseRepository.Post(response);
        }
        _personRepository.Commit();
    }
}
