using BenchmarkDotNet.Attributes;

namespace DDD.ValueObject.PerformanceTests
{
    /// <summary>
    /// This class contains tests (about Equals, GetHashCode, ...) related to the different implementations of DDD Value Object.
    /// </summary>
    public class ValueObjectTests
    {
        private Address_JB address1_JB, address2_JB, address3_JB;
        private Address_VK address1_VK, address2_VK, address3_VK;
        private Address_VK_Better address1_VKb, address2_VKb, address3_VKb;
        private Address_VK_Better_Updated address1_VKbu, address2_VKbu, address3_VKbu;
        private Address_MS address1_MS, address2_MS, address3_MS;

        [GlobalSetup]
        public void Setup()
        {
            address1_JB = new Address_JB("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address2_JB = new Address_JB("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address3_JB = new Address_JB("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150");

            address1_VK = new Address_VK("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address2_VK = new Address_VK("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address3_VK = new Address_VK("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150");

            address1_VKb = new Address_VK_Better("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address2_VKb = new Address_VK_Better("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address3_VKb = new Address_VK_Better("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150");

            address1_VKbu = new Address_VK_Better_Updated("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address2_VKbu = new Address_VK_Better_Updated("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address3_VKbu = new Address_VK_Better_Updated("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150");

            address1_MS = new Address_MS("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address2_MS = new Address_MS("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "1080");
            address3_MS = new Address_MS("Freedom avenue", "Molenbeek", "Brussels", "Belgium", "5150");
        }

        // Two_Value_Objects_With_Same_Properties_Are_Equal
        // ************************************************
        [Benchmark()]
        public bool Two_Value_Objects_With_Same_Properties_Are_Equal_JB()
        {
            return address1_JB.Equals(address2_JB);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Same_Properties_Are_Equal_VK()
        {
            return address1_VK.Equals(address2_VK);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Same_Properties_Are_Equal_VK_Better()
        {
            return address1_VKb.Equals(address2_VKb);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Same_Properties_Are_Equal_VK_Better_Updated()
        {
            return address1_VKbu.Equals(address2_VKbu);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Same_Properties_Are_Equal_MS()
        {
            return address1_MS.Equals(address2_MS);
        }

        // SameInstance
        // ************
        [Benchmark()]
        public bool A_Value_Object_Equals_Itself_JB()
        {
            return address1_JB.Equals(address1_JB);
        }

        [Benchmark()]
        public bool A_Value_Object_Equals_Itself_VK()
        {
            return address1_VK.Equals(address1_VK);
        }

        [Benchmark()]
        public bool A_Value_Object_Equals_Itself_VK_Better()
        {
            return address1_VKb.Equals(address1_VKb);
        }

        [Benchmark()]
        public bool A_Value_Object_Equals_Itself_VK_Better_Updated()
        {
            return address1_VKbu.Equals(address1_VKbu);
        }

        [Benchmark()]
        public bool A_Value_Object_Equals_Itself_MS()
        {
            return address1_MS.Equals(address1_MS);
        }

        // Two_Value_Objects_With_Different_Properties_Are_Not_Equal
        // *********************************************************
        [Benchmark()]
        public bool Two_Value_Objects_With_Different_Properties_Are_Not_Equal_JB()
        {
            return address1_JB.Equals(address3_JB);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Different_Properties_Are_Not_Equal_VK()
        {
            return address1_VK.Equals(address3_VK);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Different_Properties_Are_Not_Equal_VK_Better()
        {
            return address1_VKb.Equals(address3_VKb);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Different_Properties_Are_Not_Equal_VK_Better_Updated()
        {
            return address1_VKbu.Equals(address3_VKbu);
        }

        [Benchmark()]
        public bool Two_Value_Objects_With_Different_Properties_Are_Not_Equal_MS()
        {
            return address1_MS.Equals(address3_MS);
        }

        // GetHashCode
        // ***********
        [Benchmark()]
        public int GetHashCode_Of_Value_Object_JB()
        {
            return address1_JB.GetHashCode();
        }

        [Benchmark()]
        public int GetHashCode_Of_Value_Object_VK()
        {
            return address1_VK.GetHashCode();
        }

        [Benchmark()]
        public int GetHashCode_Of_Value_Object_VK_Better()
        {
            return address1_VKb.GetHashCode();
        }

        [Benchmark()]
        public int GetHashCode_Of_Value_Object_VK_Better_Updated()
        {
            return address1_VKbu.GetHashCode();
        }

        [Benchmark()]
        public int GetHashCode_Of_Value_Object_MS()
        {
            return address1_MS.GetHashCode();
        }
    }
}
