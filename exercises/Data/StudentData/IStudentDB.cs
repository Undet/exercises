﻿using exercises.Data.Models;

namespace exercises.Data
{
    public interface IStudentDB
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        Task<Student> DeleteById(int id);
        Task<string> SetRole(Student student, string role);

    }
}
