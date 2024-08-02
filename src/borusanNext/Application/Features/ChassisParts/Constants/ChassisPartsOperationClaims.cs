namespace Application.Features.ChassisParts.Constants;

public static class ChassisPartsOperationClaims
{
    private const string _section = "ChassisParts";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
    public const string GetDynamic = $"{_section}.GetDynamic";
}