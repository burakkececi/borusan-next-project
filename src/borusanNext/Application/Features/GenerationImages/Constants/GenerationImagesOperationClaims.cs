namespace Application.Features.GenerationImages.Constants;

public static class GenerationImagesOperationClaims
{
    private const string _section = "GenerationImages";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}