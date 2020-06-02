namespace DDD.ValueObject.UnitTests
{
    public class Address_JB_Tests : ValueObjectBaseTests<Address_JB>
    {
        public override Address_JB Instance1
        {
            get { return new Address_JB("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_JB InstanceWithSamePropertiesAsInstance1
        {
            get { return new Address_JB("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_JB InstanceWithDifferentPropertiesAsInstance1
        {
            get { return new Address_JB("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150"); }
        }
    }
}
