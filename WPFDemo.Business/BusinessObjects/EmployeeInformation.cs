using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.DAL.DTOs;

namespace WPFDemo.Business.BusinessObjects
{
    [Serializable]
    public class EmployeeInformation : ReadOnlyBase<EmployeeInformation>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { LoadProperty(FirstNameProperty, value); }
        }

        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { LoadProperty(LastNameProperty, value); }
        }

        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            set { LoadProperty(TitleProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> HireDateProperty = RegisterProperty<SmartDate>(c => c.HireDate);
        public SmartDate HireDate
        {
            get { return GetProperty(HireDateProperty); }
            set { LoadProperty(HireDateProperty, value); }
        }

        public static readonly PropertyInfo<string> AddressProperty = RegisterProperty<string>(c => c.Address);
        public string Address
        {
            get { return GetProperty(AddressProperty); }
            set { LoadProperty(AddressProperty, value); }
        }

        public static readonly PropertyInfo<string> CityProperty = RegisterProperty<string>(c => c.City);
        public string City
        {
            get { return GetProperty(CityProperty); }
            set { LoadProperty(CityProperty, value); }
        }

        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(c => c.State);
        public string State
        {
            get { return GetProperty(StateProperty); }
            set { LoadProperty(StateProperty, value); }
        }

        public static readonly PropertyInfo<string> ZipProperty = RegisterProperty<string>(c => c.Zip);
        public string Zip
        {
            get { return GetProperty(ZipProperty); }
            set { LoadProperty(ZipProperty, value); }
        }

        public static readonly PropertyInfo<string> ProfilePictureProperty = RegisterProperty<string>(c => c.ProfilePicture);
        public string ProfilePicture
        {
            get { return GetProperty(ProfilePictureProperty); }
            set { LoadProperty(ProfilePictureProperty, value); }
        }

        private void Child_Fetch(EmployeeInformationDto item)
        {
            Id = item.Id;
            FirstName = item.FirstName;
            LastName = item.LastName;
            Title = item.Title;
            Address = item.Address;
            City = item.City;
            State = item.State;
            Zip = item.Zip;
            ProfilePicture = item.ProfilePicture;
        }
    }
}
