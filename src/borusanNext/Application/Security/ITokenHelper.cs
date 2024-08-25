using Domain.Entities;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.JWT;

namespace Application.Security;
public interface ITokenHelper<TOperationClaimId, TRefreshTokenId>
{
    AccessToken CreateToken(User user, IList<OperationClaim<TOperationClaimId>> operationClaims);

    RefreshToken<TRefreshTokenId, Guid> CreateRefreshToken(User user, string ipAddress);
}