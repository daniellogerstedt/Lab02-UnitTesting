using System;
using Xunit;
using static BankATM.Program;

namespace BankATMTesting
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1000", true)]
        [InlineData("-1000", false)]
        [InlineData("NotValid", false)]
        public void TestDepositReturnsTrueForValidInputsAndFalseForInvalidInputs(string input, bool expected)
        {
            bool testValue = Deposit(input);
            Assert.Equal(expected, testValue);
        }

        [Theory]
        [InlineData("1000", true)]
        [InlineData("-1000", false)]
        [InlineData("NotValid", false)]
        [InlineData("1000000", false)]
        public void TestWithdrawlReturnsTrueForValidInputsAndFalseForInvalidInputs(string input, bool expected)
        {
            bool testValue = Withdrawl(input);
            Assert.Equal(expected, testValue);
        }
    }
}
