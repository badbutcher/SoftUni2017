namespace BashSoft.Contracts
{
    public interface IDirectoryChanger
    {
        void ChangeCurrentDirectoryRelative(string relativPath);

        void ChangeCurrentDirectoryAbsolute(string absolutePath);
    }
}