using Csla;
using Csla.Rules.CommonRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Business.Rules;
using WPFDemo.DAL;
using WPFDemo.DAL.DTOs;

namespace WPFDemo.Business.BusinessObjects
{
    [Serializable]
    public class EmployeeInformationEdit : BusinessBase<EmployeeInformationEdit>
    {

        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id, "Id");
        public int Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName, "First Name");
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }

        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName, "Last Name");
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title, "Title");
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            set { SetProperty(TitleProperty, value); }
        }

        public static readonly PropertyInfo<string> AddressProperty = RegisterProperty<string>(c => c.Address, "Address");
        public string Address
        {
            get { return GetProperty(AddressProperty); }
            set { SetProperty(AddressProperty, value); }
        }

        public static readonly PropertyInfo<string> CityProperty = RegisterProperty<string>(c => c.City, "City");
        public string City
        {
            get { return GetProperty(CityProperty); }
            set { SetProperty(CityProperty, value); }
        }

        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(c => c.State, "State");
        public string State
        {
            get { return GetProperty(StateProperty); }
            set { SetProperty(StateProperty, value); }
        }

        public static readonly PropertyInfo<string> ZipProperty = RegisterProperty<string>(c => c.Zip, "Zipcode");
        public string Zip
        {
            get { return GetProperty(ZipProperty); }
            set { SetProperty(ZipProperty, value); }
        }

        public static readonly PropertyInfo<string> ProfilePictureProperty = RegisterProperty<string>(c => c.ProfilePicture, "Profile Picture");
        public string ProfilePicture
        {
            get { return GetProperty(ProfilePictureProperty); }
            set { SetProperty(ProfilePictureProperty, value); }
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            // Common Rule Examples
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(FirstNameProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(FirstNameProperty, 20));

            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(LastNameProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(LastNameProperty, 20));

            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(TitleProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(TitleProperty, 40));

            BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(AddressProperty, 50));

            BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(CityProperty, 50));

            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(ProfilePictureProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(ProfilePictureProperty, 255));

            // Custom Rule Example (with dependency)
            BusinessRules.AddRule(new NYRule { PrimaryProperty = StateProperty });
            BusinessRules.AddRule(new Dependency(ZipProperty, StateProperty));

            // Require the city, state, or zip if the address has a value
            BusinessRules.AddRule(new RequiredWhenAnyHasValue(CityProperty, AddressProperty));
            BusinessRules.AddRule(new RequiredWhenAnyHasValue(StateProperty, AddressProperty));
            BusinessRules.AddRule(new RequiredWhenAnyHasValue(ZipProperty, AddressProperty));

        }

        public static EmployeeInformationEdit GetEmployee(int id)
        {
            return DataPortal.Fetch<EmployeeInformationEdit>(id);
        }

        protected override void DataPortal_Create()
        {
            //using (var ctx = DalFactory.GetManager())
            //{
            //    var dal = ctx.GetProvider<DAL.Interfaces.IEmployeeInformationDal>();

            //    var dto = dal.Create();

            //    using (BypassPropertyChecks)
            //    {
            //        Id = dto.Id;
            //        FirstName = dto.FirstName;
            //        LastName = dto.LastName;
            //    }
            //}

            //BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(int id)
        {
            using (var ctx = DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<DAL.Interfaces.IEmployeeInformationDal>();

                var dto = dal.Fetch(id);

                using (BypassPropertyChecks)
                {
                    Id = dto.Id;
                    FirstName = dto.FirstName;
                    LastName = dto.LastName;
                    Title = dto.Title;
                    Address = dto.Address;
                    City = dto.City;
                    State = dto.State;
                    Zip = dto.Zip;
                    ProfilePicture = dto.ProfilePicture;
                }
            }
        }

        protected override void DataPortal_Insert()
        {
            using (var ctx = DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<DAL.Interfaces.IEmployeeInformationDal>();

                using (BypassPropertyChecks)
                {
                    var dto = new EmployeeInformationDto
                    {
                        Id = this.Id,
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        Title = this.Title,
                        Address = this.Address,
                        City = this.City,
                        State = this.State,
                        Zip = this.Zip,
                        ProfilePicture = this.ProfilePicture
                    };

                    dal.Insert(dto);
                }

            }
        }


        protected override void DataPortal_Update()
        {
            using (var ctx = DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<DAL.Interfaces.IEmployeeInformationDal>();

                using (BypassPropertyChecks)
                {
                    var dto = new EmployeeInformationDto
                    {
                        Id = this.Id,
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        Title = this.Title,
                        Address = this.Address,
                        City = this.City,
                        State = this.State,
                        Zip = this.Zip,
                        ProfilePicture = this.ProfilePicture
                    };

                    dal.Update(dto);
                }
            }
        }

        private void DataPortal_Delete(int id)
        {
            using (var ctx = DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<DAL.Interfaces.IEmployeeInformationDal>();

                using (BypassPropertyChecks)
                {
                    dal.Delete(id);
                }
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Id);
        }
    }
}
