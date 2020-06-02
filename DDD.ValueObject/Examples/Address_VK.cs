namespace DDD.ValueObject
{
    public class Address_VK : ValueObject_VK<Address_VK>
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }

        public Address_VK(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override bool EqualsCore(Address_VK other)
        {
            return Street == other.Street
                && City == other.City
                && State == other.State
                && Country == other.Country
                && ZipCode == other.ZipCode;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Street.GetHashCode();
                hashCode = (hashCode * 397) ^ City.GetHashCode();
                hashCode = (hashCode * 397) ^ State.GetHashCode();
                hashCode = (hashCode * 397) ^ Country.GetHashCode();
                hashCode = (hashCode * 397) ^ ZipCode.GetHashCode();
                return hashCode;
            }
        }
    }
}
