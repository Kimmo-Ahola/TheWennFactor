using TheWennFactor;

namespace xUnitTests;

public class Tests
{
    [Fact]
    public void CreateTicket_ShouldAssignIncrementalId()
    {
        // Arrange
        var manager = new TicketManager();

        // Act
        var t1 = manager.CreateTicket("Inloggningsfel");
        var t2 = manager.CreateTicket("Fel vid rapportgenerering");

        // Assert
        Assert.Equal(1, t1.TicketId);
        Assert.Equal(2, t2.TicketId);
        Assert.Equal("Open", t1.Status);
    }

    [Fact]
    public void GetTicket_ShouldReturnCorrectTicket()
    {
        // Arrange
        var manager = new TicketManager();
        var t1 = manager.CreateTicket("Första ärendet");
        var t2 = manager.CreateTicket("Andra ärendet");

        // Act
        var result = manager.GetTicket(t2.TicketId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Andra ärendet", result!.Title);
        Assert.Equal(2, result.TicketId);
    }

    [Fact]
    public void CloseTicket_ShouldChangeStatusToClosed()
    {
        // Arrange
        var manager = new TicketManager();
        var t = manager.CreateTicket("Testärende");

        // Act
        manager.CloseTicket(t.Id);
        var closed = manager.GetTicket(t.TicketId);

        // Assert
        Assert.NotNull(closed);
        Assert.Equal("Closed", closed!.Status);
    }
}