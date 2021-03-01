using System;

namespace SeleniumSpecflow.Model.Data
{
    internal class ProfileData : IEquatable<ProfileData>
    {
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Gender { get; set; } = null;
        public string Age { get; set; } = null;
        public string Address{ get; set; } = null;
        public string Phone { get; set; } = null;
        public string Hobby { get; set; } = null;

        public bool Equals(ProfileData other)
        {
            if (other == null)
                return false;

            return
            (
                object.ReferenceEquals(this.FirstName, other.FirstName) ||
                this.FirstName != null &&
                this.FirstName.Equals(other.FirstName)
            ) &&
            (
                object.ReferenceEquals(this.LastName, other.LastName) ||
                this.LastName != null &&
                this.LastName.Equals(other.LastName)
            ) &&
            (
                object.ReferenceEquals(this.Gender, other.Gender) ||
                this.Gender != null &&
                this.Gender.Equals(other.Gender)
            ) &&
            (
                object.ReferenceEquals(this.Age, other.Age) ||
                this.Age != null &&
                this.Age.Equals(other.Age)
            ) &&
            (
                object.ReferenceEquals(this.Address, other.Address) ||
                this.Address != null &&
                this.Address.Equals(other.Address)
            ) &&
            (
                object.ReferenceEquals(this.Phone, other.Phone) ||
                this.Phone != null &&
                this.Phone.Equals(other.Phone)
            ) &&
            (
                object.ReferenceEquals(this.Hobby, other.Hobby) ||
                this.Hobby != null &&
                this.Hobby.Equals(other.Hobby)
            );
        }
    
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ProfileData WithFirstName(string firstname)
        {
            this.FirstName = firstname;
            return this;
        }
        public ProfileData WithLastName(string lastname)
        {
            this.LastName = lastname;
            return this;
        }
        public ProfileData WithGender(string gender)
        {
            this.Gender = gender;
            return this;
        }
        public ProfileData WithAge(string age)
        {
            this.Age = age;
            return this;
        }
        public ProfileData WithAddress(string address)
        {
            this.Address = address;
            return this;
        }
        public ProfileData WithPhone(string phone)
        {
            this.Phone = phone;
            return this;
        }
        public ProfileData WithHobby(string hobby)
        {
            this.Hobby = hobby;
            return this;
        }
    }
}
