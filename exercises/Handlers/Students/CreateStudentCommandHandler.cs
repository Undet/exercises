using exercises.Commands.Students;
using exercises.Data;
using MediatR;

namespace exercises.Handlers.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentDB _studentDB;
        public CreateStudentCommandHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return _studentDB.Add(request.Student);
        }
    }
}
