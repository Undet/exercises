using exercises.Commands.Students;
using exercises.Data;
using MediatR;

namespace exercises.Handlers.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentDB _studentDB;
        public UpdateStudentCommandHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return _studentDB.Update(request.Student);
        }
    }
}
