﻿using Domain.Interfaces.Repositories;
using Domain.Models;
using Service.Interfaces.Services;
using Service.ViewModels;
using Services.Mappers;

namespace SearchApp.Services;

public class ConsignedCreditFormService : IConsignedCreditFormService
{
    private readonly IRepositoryBase<Person> _personRepository;
    private readonly IRepositoryBase<Response> _responseRepository;
    private readonly IQuestionRepository _questionRepository;

    public ConsignedCreditFormService(IRepositoryBase<Person> personRepository, 
                                      IRepositoryBase<Response> responseRepository,
                                      IQuestionRepository questionRepository)
    {
        _personRepository = personRepository;
        _responseRepository = responseRepository;
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<QuestionViewModel>> GetQuestions()
    {
        var questions = (await _questionRepository.GetAll()).OrderBy(x => x.Description[0]).ToList();
        return questions.Select(x => x.MapToViewModel());
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
