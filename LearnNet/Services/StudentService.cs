using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Services
{
    public class StudentService : IService<StudentViewModel>
    {
        private readonly IRepository<StudentEntity> _studentRepository;

        public StudentService(IRepository<StudentEntity> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async Task Create(StudentViewModel studentViewModel)
        {
            try
            {
                var students = await _studentRepository.GetAll();
                var Isexists = students.Any(w => w.Email == studentViewModel.Email);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var student = new StudentEntity()
                {
                    StudentId = Guid.NewGuid().ToString(),
                    StudentName = studentViewModel.StudentName,
                    Email = studentViewModel.Email,
                };
                await _studentRepository.Create(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Email already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _studentRepository.Delete(id);
        }

        public async Task<IList<StudentViewModel>> GetAll()
        {
            var students = await _studentRepository.GetAll();
            return students.Select(s => new StudentViewModel
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                Email = s.Email,
            }).ToList();
        }

        public async Task<StudentViewModel> GetById(string id)
        {
            var studentEntity = await _studentRepository.GetById(id);
            return new StudentViewModel()
            {
                StudentId = studentEntity.StudentId,
                StudentName = studentEntity.StudentName,
                Email = studentEntity.Email,
            };
        }

        public async Task Update(StudentViewModel studentViewModel)
        {
            try
            {
                var students = await _studentRepository.GetAll();
                var Isexist = students.Where(w => w.Email == studentViewModel.Email).Any();
                if (Isexist)
                {
                    throw new Exception("Email already exist in the System.");
                }
                else
                {
                    var student = new StudentEntity()
                    {
                        StudentId = studentViewModel.StudentId,
                        StudentName = studentViewModel.StudentName,
                        Email = studentViewModel.Email,
                        ModifiedAt = DateTime.Now
                    };

                    await _studentRepository.Update(student);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public void Create(StudentViewModel studentViewModel)
        //{
        //    try
        //    {
        //        var IsStudentAlreadyExist = _studentRepository.GetAll().Where(w => w.Email == studentViewModel.Email).Any();
        //        if (IsStudentAlreadyExist)
        //        {
        //            throw new Exception("Email already exists in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var student = new StudentEntity()
        //        {
        //            StudentId = Guid.NewGuid().ToString(),
        //            StudentName = studentViewModel.StudentName,
        //            Email = studentViewModel.Email,
        //        };
        //        _studentRepository.Create(student);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _studentRepository.Delete(id);
        //}

        //public IList<StudentViewModel> GetAll()
        //{
        //    return _studentRepository.GetAll().Select(
        //         s => new StudentViewModel
        //         {
        //             StudentId = s.StudentId,
        //             StudentName = s.StudentName,
        //             Email = s.Email,
        //         }).ToList();
        //}

        //public StudentViewModel GetById(string id)
        //{
        //    var studentEntity = _studentRepository.GetById(id);
        //    return new StudentViewModel()
        //    {
        //        StudentId = studentEntity.StudentId,
        //        StudentName = studentEntity.StudentName,
        //        Email = studentEntity.Email,
        //    };
        //}

        //public void Update(StudentViewModel studentViewModel)
        //{
        //    try
        //    {
        //        var IsStudentAlreadyExist = _studentRepository.GetAll().Where(w => w.Email == studentViewModel.Email).Any();
        //        if (IsStudentAlreadyExist)
        //        {
        //            throw new Exception("Email already exists in the System.");
        //        }
        //        var student = new StudentEntity()
        //        {
        //           StudentId = studentViewModel.StudentId,
        //            StudentName = studentViewModel.StudentName,
        //            Email = studentViewModel.Email,
        //            ModifiedAt = DateTime.Now
        //        };
        //        _studentRepository.Update(student);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}