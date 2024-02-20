namespace DDD.ValueObject.UnitTests
{
    public class Address_VK_Better_Simpler_Tests : ValueObjectBaseTests<Address_VK_Better_Simpler>
    {
        public override Address_VK_Better_Simpler Instance1
        {
            get { return new Address_VK_Better_Simpler("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK_Better_Simpler InstanceWithSamePropertiesAsInstance1
        {
            get { return new Address_VK_Better_Simpler("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080"); }
        }

        public override Address_VK_Better_Simpler InstanceWithDifferentPropertiesAsInstance1
        {
            get { return new Address_VK_Better_Simpler("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150"); }
        }
    }
}
