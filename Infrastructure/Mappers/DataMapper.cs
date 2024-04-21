using DomainModel.Snapshots;
using Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    internal static class DataMapper
    {
        private static PersianCalendar pc = new PersianCalendar();

        internal static PersonDataModel ToDataModel(this PersonSnapShot snapShot)
        {
            var personDataModel = new PersonDataModel
            {
                Id = snapShot.Id,
                Age = snapShot.Age,
                CreateDateTime = DateTime.Now,
                CreateDateTimeInPersianFormat = $"{pc.GetYear(DateTime.Now)}-{pc.GetMonth(DateTime.Now)}-{pc.GetDayOfMonth(DateTime.Now)}" ,
                Name = snapShot.Name,
            };

            personDataModel.HomeAddress = snapShot.HomeAddress.ToDataModel();
            personDataModel.WorkAddress = snapShot.WorkAddress?.ToDataModel();

            personDataModel.Documents = snapShot.EducationalDocuments.Select(c => c.ToDataModel(nameof(snapShot.EducationalDocuments))).Union(
                snapShot.IdentityDocuments.Select(c => c.ToDataModel(nameof(snapShot.IdentityDocuments)))).ToList();

            return personDataModel;
        }

        internal static DocumentDataModel ToDataModel(this DocumentSnapshot snapshot, string descriminator)
        {
            return new DocumentDataModel
            {
                Descriminator = descriminator,
                DocumentUrl = snapshot.DocumentUrl,
                Id = snapshot.Id,
                ValidUntile = snapshot.ValidUntile,
                PersianValidUntil_Year = pc.GetYear(snapshot.ValidUntile),
                PersianValidUntil_Month = pc.GetMonth(snapshot.ValidUntile),
                PersianValidUntil_Day = pc.GetDayOfMonth(snapshot.ValidUntile)
            };
        }

        internal static AddressDataModel ToDataModel(this AddressSnapshot snapShot)
        {

            return new AddressDataModel
            {
                Number = snapShot.Number,
                Street = snapShot.Street,
            };
        }


        internal static PersonSnapShot ToSnapshot(this PersonDataModel datamodel)
        {
            var snapShot = new PersonSnapShot
            {
                Id = datamodel.Id,
                Age = datamodel.Age,
                Name = datamodel.Name,
            };

            snapShot.WorkAddress = datamodel.WorkAddress?.ToSnapshot();
            snapShot.HomeAddress = datamodel.HomeAddress.ToSnapshot();

            snapShot.IdentityDocuments = datamodel.Documents.Where(c=>c.Descriminator==nameof(snapShot.IdentityDocuments)).Select(c=>c.ToSnapshot()).ToList();
            
            snapShot.EducationalDocuments= datamodel.Documents.Where(c=>c.Descriminator==nameof(snapShot.EducationalDocuments)).Select(c=>c.ToSnapshot()).ToList();

            return snapShot;
        }

        internal static AddressSnapshot ToSnapshot(this AddressDataModel datamodel)
        {

            return new AddressSnapshot
            {
                Number = datamodel.Number,
                Street = datamodel.Street,
            };
        }


        internal static DocumentSnapshot  ToSnapshot(this DocumentDataModel datamodel)
        {
            return new DocumentSnapshot
            {
                DocumentUrl = datamodel.DocumentUrl,
                Id = datamodel.Id,
                ValidUntile = datamodel.ValidUntile,
            };
        }

    }
}
