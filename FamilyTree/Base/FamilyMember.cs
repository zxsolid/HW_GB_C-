namespace FamilyTree.Base
{
    public class FamilyMember
    {
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public string Name { get; set; }
        public GenderEnum Sex { get; set; }

        public virtual void Print(int indent = 0)
        {
            string indentChars = new String(' ', indent * 4);
            Console.WriteLine($"{indentChars} Имя: {Name}");

            if (Mother != null && Father != null)
            {
                Console.WriteLine($"{indentChars} Родители:");
                Console.WriteLine($"{indentChars}{new String(' ', 4)} Мать: {Mother.Name}");
                Console.WriteLine($"{indentChars}{new String(' ', 4)} Отец: {Father.Name}");
            }
        }
    }
}