namespace BattleShip.Tests;
using BattleShip;

public class BoardTests
{
    private readonly Board testBoard;

    public BoardTests()
    {
        testBoard = new Board(new List<int> { 1, 2, 3, 4 });
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    [InlineData(7, false)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    public void IsThereAShip_Tests(int slot, bool status)
    {
        Assert.Equal(testBoard.IsThereAShip(slot), status);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    [InlineData(7, false)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    public void Shoot_Tests(int slot, bool status)
    {
        var numberOfShipsBefore = testBoard.allSlots.Where(x => x.Value == "ship").Count();
        Assert.Equal(testBoard.Shoot(slot), status);
        var numberOfShipsAfter = testBoard.allSlots.Where(x => x.Value == "ship").Count();
        if (status == true)
        {
            Assert.Equal(numberOfShipsBefore - 1, numberOfShipsAfter);
        }
        else
        {
            Assert.Equal(numberOfShipsBefore, numberOfShipsAfter);
        }
    }

    [Theory]
    [InlineData(0, 4)]
    [InlineData(1, 3)]
    [InlineData(2, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    [InlineData(5, 4)]
    [InlineData(6, 4)]
    [InlineData(7, 4)]
    [InlineData(8, 4)]
    [InlineData(9, 4)]
    public void NumberOfShipsLeft_Tests(int slot, int left)
    {
        testBoard.allSlots["slot" + slot] = "ship sink";
        Assert.Equal(testBoard.NumberOfShipsLeft(), left);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, false)]
    [InlineData(new int[] { 1, 2, 3, 4 }, true)]
    [InlineData(new int[] { 8, 9 }, false)]
    public void IsGameFInished_Tests(int[] slots, bool result)
    {
        foreach (var num in slots)
        {
            testBoard.allSlots["slot" + num] = "sink";
        }
        Assert.Equal(testBoard.IsGameFInished(), result);
    }
}