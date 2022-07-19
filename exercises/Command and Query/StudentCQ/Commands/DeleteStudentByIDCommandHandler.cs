using exercises.Data;
using MediatR;

namespace exercises.Command_and_Query.StudentCQ.Commands
{
    public class DeleteStudentByIDCommandHandler : IRequestHandler<DeleteStudentByIDCommand, Student>
    {
        private readonly IStudentDB _studentDB;
        DeleteStudentByIDCommandHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(DeleteStudentByIDCommand request, CancellationToken cancellationToken)
        {
            return _studentDB.DeleteById(request.Id);
        }
    }
}
