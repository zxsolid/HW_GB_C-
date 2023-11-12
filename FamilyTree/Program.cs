using FamilyTree.Base;

namespace FamilyTrees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Пример использования
            var grandfather = new AdultFamilyMember { Name = "Дедушка", Sex = GenderEnum.Male };
            var grandmother = new AdultFamilyMember { Name = "Бабушка", Sex = GenderEnum.Female };

            var father = new AdultFamilyMember { Name = "Папа", Sex = GenderEnum.Male, Father = grandfather, Mother = grandmother };
            var mother = new AdultFamilyMember { Name = "Мама", Sex = GenderEnum.Female };

            var child1 = new FamilyMember { Name = "Ребенок 1", Sex = GenderEnum.Male, Father = father, Mother = mother };
            var child2 = new FamilyMember { Name = "Ребенок 2", Sex = GenderEnum.Female, Father = father, Mother = mother };

            father.Children = new List<FamilyMember> { child1, child2 };
            mother.Children = new List<FamilyMember> { child1, child2 };

            var spouse = new SpouseFamilyMember { Name = "Супруг(а)", Sex = GenderEnum.Female, Spouse = father };
            var spouse2 = new SpouseFamilyMember { Name = "Супруг(а)", Sex = GenderEnum.Female, Spouse = mother };

            var familyMembers = new List<FamilyMember> { grandfather, grandmother, father, mother, child1, child2, spouse, spouse2 };

            foreach (var member in familyMembers)
            {
                member.Print();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}