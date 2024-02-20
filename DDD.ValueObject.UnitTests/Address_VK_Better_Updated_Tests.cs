namespace DDD.ValueObject.UnitTests
{
    public class Address_VK_Better_Updated_Tests : ValueObjectBaseTests<Address_VK_Better_Updated>
    {
        public override Address_VK_Better_Updated Instance1
        {
            get { return new Address_VK_Better_Updated("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK_Better_Updated InstanceWithSamePropertiesAsInstance1
        {
            get { return new Address_VK_Better_Updated("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK_Better_Updated InstanceWithDifferentPropertiesAsInstance1
        {
            get { return new Address_VK_Better_Updated("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150"); }
        }
    }
}
