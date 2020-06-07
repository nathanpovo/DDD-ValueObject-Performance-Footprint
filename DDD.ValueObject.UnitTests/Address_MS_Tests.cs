namespace DDD.ValueObject.UnitTests
{
    public class Address_MS_Tests : ValueObjectBaseTests<Address_MS>
    {
        public override Address_MS Instance1
        {
            get { return new Address_MS("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_MS InstanceWithSamePropertiesAsInstance1
        {
            get { return new Address_MS("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_MS InstanceWithDifferentPropertiesAsInstance1
        {
            get { return new Address_MS("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150"); }
        }
    }
}
