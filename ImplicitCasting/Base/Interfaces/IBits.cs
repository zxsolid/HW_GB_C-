namespace ImplicitCasting.Base.Interfaces
{
    public interface IBits<T> where T : struct
    {
        bool GetBit(int index);
        void SetBit(bool bit, int index);
    }
}