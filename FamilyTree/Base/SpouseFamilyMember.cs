namespace FamilyTree.Base
{
    public class SpouseFamilyMember : FamilyMember
    {
        public FamilyMember Spouse { get; set; }

        public override void Print(int indent = 0)
        {
            base.Print(indent);

            if (Spouse != null)
            {
                Console.WriteLine($"{new String(' ', indent * 4)} Супруг(а):");
                Spouse.Print(indent + 1);
            }
        }
    }
}