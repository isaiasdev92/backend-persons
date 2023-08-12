using System.Collections;
using AutoMapper;
using ExameSoftware.Dtos;
using ExameSoftware.Helpers.Validator;
using ExameSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Helpers;

namespace ExameSoftware.Controllers;

[ApiController]
[Route("api/examsimoftware/[controller]")]
[Produces("application/json")]
public class PeopleController : ControllerBase
{
    private DataContext _dataContext;
    private readonly IMapper _mapper;

    public PeopleController(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;

    }

    [HttpGet(Name = "people")]
    public ActionResult<List<PeopleItem>> Index()
    {
        var response = new ApiResponse<List<PeopleItem>>();
        var results = _dataContext.Peoples.ToList();
        var resulstMaps = _mapper.Map<List<PeopleItem>>(results);

        response.Data = resulstMaps;
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PeopleRequest request)
    {
        var peopleValidator = new PeopleValidator();

        //Validations
        var resultValidator = await peopleValidator.ValidateAsync(request);
        var response = new ApiResponse<bool>();

        if (!resultValidator.IsValid)
        {
            var errorMessages = resultValidator.Errors.Select(x => x.ErrorMessage).ToList();
            response.Errors = errorMessages;
            return BadRequest(response);
        }

        var existEmail = _dataContext.Peoples.Any(a => a.Email == request.Email);

        if (existEmail)
        {
            response.Errors =  new List<string> { "El correo ya existe"};
            return BadRequest(response);
        }


        var entityAdd = _mapper.Map<People>(request);


        _dataContext.Add(entityAdd);
        await _dataContext.SaveChangesAsync();

        response.Data = true;

        var location = Url.Action(nameof(Index)) ?? "/";

        return Created(location, response);
    }
}

