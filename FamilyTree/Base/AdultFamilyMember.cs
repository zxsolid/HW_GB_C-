namespace FamilyTree.Base
{
    public class AdultFamilyMember : FamilyMember
    {
        public List<FamilyMember> Children { get; set; }

        public override void Print(int indent = 0)
        {
            base.Print(indent);

            if (Children != null && Children.Count > 0)
            {
                Console.WriteLine($"{new String(' ', indent * 4)} Дети:");
                foreach (var child in Children)
                {
                    child.Print(indent + 1);
                }
            }
        }
    }
}