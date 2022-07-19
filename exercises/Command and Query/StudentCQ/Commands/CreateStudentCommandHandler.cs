using exercises.Data;
using MediatR;

namespace exercises.Command_and_Query.Students.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentDB _studentDB;
        CreateStudentCommandHandler(IStudentDB studentDB)
        { 
         _studentDB = studentDB;
        }
        public Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return _studentDB.Add(request.Student);
        }
    }
}
