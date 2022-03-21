using Layer.Architecture.Infra.Data.Builder;

namespace Layer.Architecture.Infra.Data.Builder
{
    public interface IUserBuilder
    {
        bool Build(UserBuilderCommand command);
    }
}
