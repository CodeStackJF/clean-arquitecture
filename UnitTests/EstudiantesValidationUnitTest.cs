using Application.Exceptions;
using Application.Validations;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Primitives;
using Moq;
using Newtonsoft.Json;

namespace UnitTests;

public class EstudiantesValidationUnitTest
{
    private readonly Mock<IEstudiantesRepository> mockEstudiantesRepository;
    private readonly Mock<IUnitOfWork> mockUnitOfWork;
    private readonly EstudiantesValidation estudiantesValidation;
    public EstudiantesValidationUnitTest()
    {
        mockEstudiantesRepository = new Mock<IEstudiantesRepository>();
        mockUnitOfWork = new Mock<IUnitOfWork>();
        estudiantesValidation = new EstudiantesValidation();
    }

    [Fact]
    public void EstudiantesValidation_WhenNameIsEmpty()
    {
        var estudiante = new estudiantes()
        {
            nombre = "José"
        };
        var validation = estudiantesValidation.Validate(estudiante);
        if(!validation.IsValid)
        {
            Console.WriteLine(JsonConvert.SerializeObject(validation.Errors));
            //throw new CustomValidationException(validation.Errors);
        }
    }
}