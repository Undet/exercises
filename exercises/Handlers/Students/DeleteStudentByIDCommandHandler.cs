using exercises.Commands.Studentss;
using exercises.Data;
using MediatR;

namespace exercises.Handlers.Students
{
    public class DeleteStudentByIDCommandHandler : IRequestHandler<DeleteStudentByIDCommand, Student>
    {
        private readonly IStudentDB _studentDB;
        public DeleteStudentByIDCommandHandler(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }
        public Task<Student> Handle(DeleteStudentByIDCommand request, CancellationToken cancellationToken)
        {
            return _studentDB.DeleteById(request.Id);
        }
    }
}
