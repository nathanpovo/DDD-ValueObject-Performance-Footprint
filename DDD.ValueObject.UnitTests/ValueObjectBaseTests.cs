using Xunit;

namespace DDD.ValueObject.UnitTests
{
    /// <summary>
    /// Contains template (GoF) test methods about Equals/GetHashCode, that any DDD value object should verify.
    /// </summary>
    public abstract class ValueObjectBaseTests<T>
    {
        // 1. Arrange
        public abstract T Instance1 { get; }
        public abstract T InstanceWithSamePropertiesAsInstance1 { get; }
        public abstract T InstanceWithDifferentPropertiesAsInstance1 { get; }

        [Fact]
        public void Two_Value_Objects_With_Same_Properties_Should_Be_Equal()
        {
            // 2. Act
            var areEqual = Instance1.Equals(InstanceWithSamePropertiesAsInstance1);

            // 3. Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void A_Value_Object_Should_Equal_Itself()
        {
            // 2. Act
            var areEqual = Instance1.Equals(Instance1);

            // 3. Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Two_Value_Objects_With_Different_Properties_Should_Not_Be_Equal()
        {
            // 2. Act
            var areEqual = Instance1.Equals(InstanceWithDifferentPropertiesAsInstance1);

            // 3. Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void Two_Value_Objects_With_Same_Properties_Should_Have_Same_HashCode()
        {
            // 2. Act
            var hash1 = Instance1.GetHashCode();
            var hash2 = InstanceWithSamePropertiesAsInstance1.GetHashCode();

            // 3. Assert
            Assert.True(hash1 == hash2);
        }

        [Fact]
        public void Two_Value_Objects_With_Different_Properties_Should_Have_Different_HashCode()
        {
            // 2. Act
            var hash1 = Instance1.GetHashCode();
            var hash2 = InstanceWithDifferentPropertiesAsInstance1.GetHashCode();

            // 3. Assert
            Assert.True(hash1 != hash2);
        }
    }
}
