using DemoQA.Models;

namespace DemoQA.Factories
{
    public static class PracticeFormFactory
    {
        public static PracticeFormModel Create()
        {
            return new PracticeFormModel
            {
                FirstName = "Ventsi",
                LastName = "Batman",
                Email = "DJBuro@gmail.com",
                Gender = "Male",
                PhoneNumber = "87654321588",
            };
        }
    }
}
