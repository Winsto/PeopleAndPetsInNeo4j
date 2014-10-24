
namespace DomainModel
{
    public class Animal
    {
        public string FamilyName { get; private set; }

        public string TrivialName { get; private set; }

        public Animal(string familyName, string trivialName)
        {
            FamilyName = familyName;

            TrivialName = trivialName;
        }
    }
}
