using GDIC;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestSignelton
    {
        ServiceCollection services;
        public TestSignelton()
        {
            services = new ServiceCollection();
        }

        [Fact]
        public void TestEq()
        {
            services.AddSingelton(1);
            var p = services.GetService<int>();

            Assert.Equal(1, p);
        }

        [Fact]
        public void TestEqS()
        {
            services.AddSingelton("a");
            var p = services.GetService<string>();

            Assert.Equal("a", p);
        }

        [Fact]
        public void TestEqT()
        {

            services.AddSingelton(new TestDate());
            var p = services.GetService<TestDate>();

            Assert.Equal(typeof(TestDate), p.GetType());
        }
        [Fact]
        public void TestEqCR()
        {
            var ss = new TestDate() { s = "a", a = 1, b = 2.1 };
            services.AddSingelton(ss);
            var p = services.GetService<TestDate>();

            Assert.Equal(ss,p);
        }
        [Fact]
        public void TestEqCV()
        {
            var ss = new TestDate() { s = "a", a = 1, b = 2.1 };
            services.AddSingelton(ss);
            var p = services.GetService<TestDate>();

            Assert.True(ss.Eq(p));
        }
        class TestDate
        {
            public string s { get; set; }
            public int a { get; set; }
            public double b { get; set; }
            public bool Eq(TestDate test)
            {
                return s == test.s && a == test.a && b == test.b;
            }
        }
    }
}
