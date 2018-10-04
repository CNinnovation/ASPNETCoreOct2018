namespace MyFirstMVCApp.Services
{
    public interface IMathService
    {
        int Add(int x, int y);
        int Divide(int x, int y);
        int Multiply(int x, int y);
        int Subtract(int x, int y);
    }
}