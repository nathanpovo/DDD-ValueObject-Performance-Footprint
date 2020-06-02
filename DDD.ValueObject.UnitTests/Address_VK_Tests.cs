namespace DDD.ValueObject.UnitTests
{
    public class Address_VK_Tests : ValueObjectBaseTests<Address_VK>
    {
        public override Address_VK Instance1
        {
            get { return new Address_VK("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK InstanceWithSamePropertiesAsInstance1
        {
            get { return new Address_VK("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK InstanceWithDifferentPropertiesAsInstance1
        {
            get { return new Address_VK("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150"); }
        }
    }
}
