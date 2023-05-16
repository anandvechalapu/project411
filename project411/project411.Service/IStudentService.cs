using System;

namespace project411.Service
{
    public interface IStudentService
    {
        StudentDTO GetStudent(int id);
        void AddStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
        void DeleteStudent(int id);
    }
}

using project411.DTO;

namespace project411.Service
{
    public interface IStudentService
    {
        StudentDTO GetStudent(int id);
        void AddStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
        void DeleteStudent(int id);
    }
}