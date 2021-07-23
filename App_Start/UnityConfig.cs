using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Webtonic.Models.Entities;
using Webtonic.Models.Services.Interface;
using Webtonic.Models.Services.Repository;

namespace Webtonic
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IStudentResultsRepository, StudentResultsRepository>();
            container.RegisterType<IStudentRepository, StudentsRepository>();
            container.RegisterType<ICoursesRepository, CoursesRepository>();
            container.RegisterType<IGradesRepository, GradesRepository>();

            //container.RegisterType<IabstractGeneric<Students>, StudentsRepository>();
            //container.RegisterType<IabstractGeneric<Courses>, CoursesRepository>();
            //container.RegisterType<IabstractGeneric<Grades>, GradesRepository>();
            //container.RegisterType<IabstractGeneric<StudentResults>, StudentResultsRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}