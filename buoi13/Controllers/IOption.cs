using buoi13.Helpers;

namespace buoi13.Controllers
{
    public interface IOption<T>
    {
        SQLConfig value { get; }
    }
}