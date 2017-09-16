using NFluent;
using NFluent.Extensibility;

namespace YAGLi.Tests.Utils.Extensions.Assertions
{
    public static class DegreeAssertionsExtensions
    {
        public static ICheckLink<ICheck<Degree>> IsImpossible(this ICheck<Degree> check)
        {
            var checker = ExtensibilityHelper.ExtractChecker(check);

            return checker.ExecuteCheck(
                () =>
                {
                    if (checker.Value != Degree.Impossible)
                    {
                        var errorMessage = FluentMessage.BuildMessage("The {0} is not impossible.").For(typeof(Degree).Name).On(checker.Value).ToString();

                        throw new FluentCheckException(errorMessage);
                    }
                },
                FluentMessage.BuildMessage("The {0} is not impossible whereas it must be.").For(typeof(Degree).Name).On(checker.Value).ToString()
            );
        }
    }
}
