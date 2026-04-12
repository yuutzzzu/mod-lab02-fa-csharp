namespace fa.Tests
{
    using fans;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void FA1_Test1() => Assert.True(new FA1().Run("10"));
        [Fact]
        public void FA1_Test2() => Assert.True(new FA1().Run("01"));
        [Fact]
        public void FA1_Test3() => Assert.False(new FA1().Run("0"));
        [Fact]
        public void FA1_Test4() => Assert.False(new FA1().Run("1"));
        [Fact]
        public void FA1_Test5() => Assert.False(new FA1().Run("1000"));
        [Fact]
        public void FA1_Test6() => Assert.True(new FA1().Run("11110"));

        [Fact]
        public void FA2_Test1() => Assert.True(new FA2().Run("01"));
        [Fact]
        public void FA2_Test2() => Assert.True(new FA2().Run("10"));
        [Fact]
        public void FA2_Test3() => Assert.False(new FA2().Run("11"));
        [Fact]
        public void FA2_Test4() => Assert.False(new FA2().Run("00"));
        [Fact]
        public void FA2_Test5() => Assert.False(new FA2().Run("010"));
        [Fact]
        public void FA2_Test6() => Assert.False(new FA2().Run("101"));
        [Fact]
        public void FA2_Test7() => Assert.False(new FA2().Run(""));
        [Fact]
        public void FA3_Test7() => Assert.False(new FA3().Run(""));


        [Fact]
        public void FA3_Test1() => Assert.True(new FA3().Run("11"));
        [Fact]
        public void FA3_Test2() => Assert.True(new FA3().Run("0110"));
        [Fact]
        public void FA3_Test3() => Assert.False(new FA3().Run("1010"));
        [Fact]
        public void FA3_Test4() => Assert.False(new FA3().Run("000"));
        [Fact]
        public void FA3_Test5() => Assert.True(new FA3().Run("111"));
        [Fact]
        public void FA3_Test6() => Assert.True(new FA3().Run("0011"));
    }

}
