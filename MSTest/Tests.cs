using TheWennFactor;

namespace MSTestTests;

[TestClass]
public class Tests
{
    private TicketManager manager;

    [TestInitialize]
    public void TestInit()
    {
        // Körs före varje test
        manager = new TicketManager();
    }

    [TestMethod]
    public void CreateTicket_ShouldAssignIncrementalId()
    {
        // Act
        var t1 = manager.CreateTicket("Inloggningsfel");
        var t2 = manager.CreateTicket("Fel vid rapportgenerering");

        // Assert
        Assert.AreEqual(1, t1.TicketId);
        Assert.AreEqual(2, t2.TicketId);
        Assert.AreEqual("Open", t1.Status);
    }

    [TestMethod]
    public void GetTicket_ShouldReturnCorrectTicket()
    {
        // Arrange
        var t1 = manager.CreateTicket("Första ärendet");
        var t2 = manager.CreateTicket("Andra ärendet");

        // Act
        var result = manager.GetTicket(t2.TicketId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Andra ärendet", result.Title);
        Assert.AreEqual(2, result.TicketId);
    }

    [TestMethod]
    public void CloseTicket_ShouldChangeStatusToClosed()
    {
        // Arrange
        var t = manager.CreateTicket("Testärende");

        // Act
        manager.CloseTicket(t.TicketId);
        var closed = manager.GetTicket(t.TicketId);

        // Assert
        Assert.IsNotNull(closed);
        Assert.AreEqual("Closed", closed.Status);
    }
}
