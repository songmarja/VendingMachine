namespace VendingMachine.Tests
{
    public class VendingShould
    {
        // Arrange
        Vending sut = new Vending();

       

        [Fact]
        public void HaveProductsInListWhenAppStarts()
        {
            
            //Assert
            Assert.NotNull(sut.products);
        }

        [Fact]
        public void HaveProductDescription()
        {
            
            //Assert
            Assert.Contains("50 g. Two pieces.", sut.products[1].Description);
        }

       

        [Fact]
        public void HaveAnArrayOfEightDenominations()
        {
            //Arrange
            int num = 8;
            //Act

            //Assert
            Assert.Equal(sut.moneys.Length, num);
        }
        [Fact]
        public void OnlyHaveValidDenominations()
        {
            //Arrange
            int[] validDenominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
            int[] moneyDenominations = new int[sut.moneys.Length];
            //Act
            for(int i = 0; i< sut.moneys.Length; i++)
            {
                moneyDenominations[i] = sut.moneys[i].Denomination;
            }
            //Assert
            Assert.Equal(moneyDenominations, validDenominations);
        }

        // Failes with ConsolePositioning. Works without!
        [Fact]
        public void EndTransactionWithZeroInBalance()
        {
            //Arrange
            int value = 153;
            //Act
            int totalLeft = sut.EndTransaction(value);
            //Assert
            Assert.True(totalLeft == 0);
        }

        [Fact]
        public void ShowProductInfoOnExamine()
        {
            //Arrange
            string expected = "Some more info: Chips - 150 g. Original taste.  Price: 40,00 kr";
            // Act
            string prodInfo = sut.products[0].Examine();

            //Assert
            Assert.Equal( expected, prodInfo);
        }

        [Fact]
        public void OnlyInsertValidDenominations()
        {
            // Arrange
            int initialDeposit = 53;
            int newDeposit = 10;
            int finalDeposit = 63;

            //Act
            int calculatedDeposit = sut.UpdateDeposit(newDeposit, initialDeposit);

            //Assert
            Assert.Equal(calculatedDeposit, finalDeposit);
        }
        //Does not work with ConsolePositioning...
        [Fact]
        public void NotInsertInvalidDenominations()
        {
            // Arrange
            int initialDeposit = 53;
            int newDeposit = 11;
            int finalDeposit = 53;

            //Act
            int calculatedDeposit = sut.UpdateDeposit(newDeposit, initialDeposit);

            //Assert
            Assert.Equal(calculatedDeposit, finalDeposit);
            //}
        }   
    }
}