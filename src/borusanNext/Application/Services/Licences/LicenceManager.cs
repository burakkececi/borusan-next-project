using Application.Features.Licences.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Licences;

public class LicenceManager : ILicenceService
{
    private readonly ILicenceRepository _licenceRepository;
    private readonly LicenceBusinessRules _licenceBusinessRules;

    public LicenceManager(ILicenceRepository licenceRepository, LicenceBusinessRules licenceBusinessRules)
    {
        _licenceRepository = licenceRepository;
        _licenceBusinessRules = licenceBusinessRules;
    }

    public async Task<Licence?> GetAsync(
        Expression<Func<Licence, bool>> predicate,
        Func<IQueryable<Licence>, IIncludableQueryable<Licence, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Licence? licence = await _licenceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return licence;
    }

    public async Task<IPaginate<Licence>?> GetListAsync(
        Expression<Func<Licence, bool>>? predicate = null,
        Func<IQueryable<Licence>, IOrderedQueryable<Licence>>? orderBy = null,
        Func<IQueryable<Licence>, IIncludableQueryable<Licence, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Licence> licenceList = await _licenceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return licenceList;
    }

    public async Task<Licence> AddAsync(Licence licence)
    {
        Licence addedLicence = await _licenceRepository.AddAsync(licence);

        return addedLicence;
    }

    public async Task<Licence> UpdateAsync(Licence licence)
    {
        Licence updatedLicence = await _licenceRepository.UpdateAsync(licence);

        return updatedLicence;
    }

    public async Task<Licence> DeleteAsync(Licence licence, bool permanent = false)
    {
        Licence deletedLicence = await _licenceRepository.DeleteAsync(licence);

        return deletedLicence;
    }
}
