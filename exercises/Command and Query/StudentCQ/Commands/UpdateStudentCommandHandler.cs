using exercises.Data;
using MediatR;

namespace exercises.Command_and_Query.Students.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentDB _studentDB;
        UpdateStudentCommandHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return _studentDB.Update(request.Student);
        }
    }
}
