namespace DDD.ValueObject.UnitTests
{
    public class Address_VK_Better_Tests : ValueObjectBaseTests<Address_VK_Better>
    {
        public override Address_VK_Better Instance1
        {
            get { return new Address_VK_Better("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK_Better InstanceWithSamePropertiesAsInstance1
        {
            get { return new Address_VK_Better("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK_Better InstanceWithDifferentPropertiesAsInstance1
        {
            get { return new Address_VK_Better("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150"); }
        }
    }
}
