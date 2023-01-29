using banko;
using Xunit;

namespace Bankomat_tests
{
	public class AccountTest
	{
		public AccountTest()
		{
		}

		[Fact]
		public void withdraw()
		{
			Account account = new Account();
			int collected = account.withdraw(5000);
						// expected, actual
			Assert.Equal(5000, collected);
		}

		[Theory]
		// actual, expected
        [InlineData(0, 0, 5000)]
        [InlineData(1, 1, 4999)]
        [InlineData(4999, 4999, 1)]
        [InlineData(5000, 5000, 0)]
        [InlineData(5001, 0, 5000)]
        [InlineData(6000, 0, 5000)]
        [InlineData(-5000, 0, 5000)]
        public void withdrawAmounts(int actual, int expected, int remainder)
		{
			Account account = new Account();

			// perform withdrawal
			int collected = account.withdraw(actual);
						// expected, actual
            Assert.Equal(expected, collected);

			// check remaining balance
			int balance = account.getBalance();
			Assert.Equal(remainder, balance);
		}

	}
}

