using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Brands.Constants;
using Application.Features.Adverts.Constants;
using Application.Features.Appointments.Constants;
using Application.Features.Blogs.Constants;
using Application.Features.BlogItemTags.Constants;
using Application.Features.BodyShellParts.Constants;
using Application.Features.BodyTypes.Constants;
using Application.Features.Campaigns.Constants;
using Application.Features.Cars.Constants;
using Application.Features.CarColors.Constants;
using Application.Features.CarModels.Constants;
using Application.Features.ChassisParts.Constants;
using Application.Features.CustomerAdvertLogs.Constants;
using Application.Features.Engines.Constants;
using Application.Features.ExpertizeResults.Constants;
using Application.Features.FuelConsumptions.Constants;
using Application.Features.FuelTypes.Constants;
using Application.Features.Generations.Constants;
using Application.Features.Licences.Constants;
using Application.Features.Locations.Constants;
using Application.Features.ModalExtensions.Constants;
using Application.Features.Tags.Constants;
using Application.Features.Transmissions.Constants;
using Application.Features.Customers.Constants;
using Application.Features.Sellers.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Brands CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Adverts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Read },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Write },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Create },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Update },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Appointments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Read },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Write },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Create },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Update },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Blogs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BlogsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BlogsOperationClaims.Read },
                new() { Id = ++lastId, Name = BlogsOperationClaims.Write },
                new() { Id = ++lastId, Name = BlogsOperationClaims.Create },
                new() { Id = ++lastId, Name = BlogsOperationClaims.Update },
                new() { Id = ++lastId, Name = BlogsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BlogItemTags CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BlogItemTagsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BlogItemTagsOperationClaims.Read },
                new() { Id = ++lastId, Name = BlogItemTagsOperationClaims.Write },
                new() { Id = ++lastId, Name = BlogItemTagsOperationClaims.Create },
                new() { Id = ++lastId, Name = BlogItemTagsOperationClaims.Update },
                new() { Id = ++lastId, Name = BlogItemTagsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BodyShellParts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BodyShellPartsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BodyShellPartsOperationClaims.Read },
                new() { Id = ++lastId, Name = BodyShellPartsOperationClaims.Write },
                new() { Id = ++lastId, Name = BodyShellPartsOperationClaims.Create },
                new() { Id = ++lastId, Name = BodyShellPartsOperationClaims.Update },
                new() { Id = ++lastId, Name = BodyShellPartsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BodyTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BodyTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BodyTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = BodyTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = BodyTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = BodyTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = BodyTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Campaigns CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Read },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Write },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Create },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Update },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cars CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarsOperationClaims.Delete },
            ]
        );
        #endregion
        
        #region CarColors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarColorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarColorsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarColorsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarColorsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarColorsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarColorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CarModels CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ChassisParts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ChassisPartsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ChassisPartsOperationClaims.Read },
                new() { Id = ++lastId, Name = ChassisPartsOperationClaims.Write },
                new() { Id = ++lastId, Name = ChassisPartsOperationClaims.Create },
                new() { Id = ++lastId, Name = ChassisPartsOperationClaims.Update },
                new() { Id = ++lastId, Name = ChassisPartsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CustomerAdvertLogs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomerAdvertLogsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomerAdvertLogsOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomerAdvertLogsOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomerAdvertLogsOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomerAdvertLogsOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomerAdvertLogsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Engines CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EnginesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EnginesOperationClaims.Read },
                new() { Id = ++lastId, Name = EnginesOperationClaims.Write },
                new() { Id = ++lastId, Name = EnginesOperationClaims.Create },
                new() { Id = ++lastId, Name = EnginesOperationClaims.Update },
                new() { Id = ++lastId, Name = EnginesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ExpertizeResults CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Read },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Write },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Create },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Update },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FuelConsumptions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FuelConsumptionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FuelConsumptionsOperationClaims.Read },
                new() { Id = ++lastId, Name = FuelConsumptionsOperationClaims.Write },
                new() { Id = ++lastId, Name = FuelConsumptionsOperationClaims.Create },
                new() { Id = ++lastId, Name = FuelConsumptionsOperationClaims.Update },
                new() { Id = ++lastId, Name = FuelConsumptionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FuelTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FuelTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = FuelTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = FuelTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = FuelTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = FuelTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = FuelTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Generations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GenerationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = GenerationsOperationClaims.Read },
                new() { Id = ++lastId, Name = GenerationsOperationClaims.Write },
                new() { Id = ++lastId, Name = GenerationsOperationClaims.Create },
                new() { Id = ++lastId, Name = GenerationsOperationClaims.Update },
                new() { Id = ++lastId, Name = GenerationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Licences CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LicencesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LicencesOperationClaims.Read },
                new() { Id = ++lastId, Name = LicencesOperationClaims.Write },
                new() { Id = ++lastId, Name = LicencesOperationClaims.Create },
                new() { Id = ++lastId, Name = LicencesOperationClaims.Update },
                new() { Id = ++lastId, Name = LicencesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ModalExtensions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Tags CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TagsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TagsOperationClaims.Read },
                new() { Id = ++lastId, Name = TagsOperationClaims.Write },
                new() { Id = ++lastId, Name = TagsOperationClaims.Create },
                new() { Id = ++lastId, Name = TagsOperationClaims.Update },
                new() { Id = ++lastId, Name = TagsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Transmissions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Read },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Write },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Create },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Update },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Customers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Sellers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SellersOperationClaims.Admin },
                new() { Id = ++lastId, Name = SellersOperationClaims.Read },
                new() { Id = ++lastId, Name = SellersOperationClaims.Write },
                new() { Id = ++lastId, Name = SellersOperationClaims.Create },
                new() { Id = ++lastId, Name = SellersOperationClaims.Update },
                new() { Id = ++lastId, Name = SellersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        
        #region Cars CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Customers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Customers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Sellers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SellersOperationClaims.Admin },
                new() { Id = ++lastId, Name = SellersOperationClaims.Read },
                new() { Id = ++lastId, Name = SellersOperationClaims.Write },
                new() { Id = ++lastId, Name = SellersOperationClaims.Create },
                new() { Id = ++lastId, Name = SellersOperationClaims.Update },
                new() { Id = ++lastId, Name = SellersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ExpertizeResults CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Read },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Write },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Create },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Update },
                new() { Id = ++lastId, Name = ExpertizeResultsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CarModels CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ModalExtensions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModalExtensionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
