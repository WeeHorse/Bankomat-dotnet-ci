using Xunit;
using banko;
namespace Bankomat_tests
{
	public class BankomatTest
	{
		Bankomat bankomat;
		Card card;

		// setup code for each test in the constructor
		public BankomatTest()
		{
            Account account = new Account();
            card = new Card(account);
            bankomat = new Bankomat();
        }

		[Fact]
        public void insertNewCard()
		{
			bankomat.insertCard(card);

            Assert.Equal("Card inserted", bankomat.getMessage());
            Assert.True(bankomat.isCardInserted());

			Assert.Equal("Create new pin code", bankomat.getMessage());
			
		}

        [Fact]
        public void createNewPin()
        {
            bankomat.insertCard(card);
            bankomat.getMessage(); // Card inserted
            bankomat.getMessage(); // Create new pin code

            bool result = bankomat.createPin("0123");
            Assert.Equal("Pin created. You can start using your card.", bankomat.getMessage());
            Assert.True(result);
        }

        [Fact]
        public void insertOldCard()
        {
            card.createPin("0123"); // mocking old card
            bankomat.insertCard(card);

            Assert.Equal("Card inserted", bankomat.getMessage());
            Assert.True(bankomat.isCardInserted());

            Assert.Equal("Enter your pin code", bankomat.getMessage());

        }


        [Theory]
		[InlineData("1234", "Incorrect pin")]
        [InlineData("0123", "Correct pin")]
		public void enterPin(string pin, string expectedMessage)
		{
            bankomat.insertCard(card);
			bankomat.getMessage(); // card inserted
            bankomat.getMessage(); // create new pin
            bankomat.createPin("0123");
            bankomat.getMessage(); // you can start using your card..

            bankomat.enterPin(pin);
			Assert.Equal(expectedMessage, bankomat.getMessage());
		}

    }
}

