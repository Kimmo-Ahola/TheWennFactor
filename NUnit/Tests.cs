using TheWennFactor;

namespace NUnitTests;

public class Tests
{
    private TicketManager manager;

    [SetUp]
    public void Setup()
    {
        // Körs före varje test
        manager = new TicketManager();
    }

    [Test]
    public void CreateTicket_ShouldAssignIncrementalId()
    {
        // Act
        var t1 = manager.CreateTicket("Inloggningsfel");
        var t2 = manager.CreateTicket("Fel vid rapportgenerering");

        // Assert
        Assert.That(t1.TicketId, Is.EqualTo(1));
        Assert.That(t2.TicketId, Is.EqualTo(2));
        Assert.That(t1.Status, Is.EqualTo("Open"));
    }

    [Test]
    public void GetTicket_ShouldReturnCorrectTicket()
    {
        // Arrange
        var t1 = manager.CreateTicket("Första ärendet");
        var t2 = manager.CreateTicket("Andra ärendet");

        // Act
        var result = manager.GetTicket(t2.Id);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Title, Is.EqualTo("Andra ärendet"));
        Assert.That(result.TicketId, Is.EqualTo(2));
    }

    [Test]
    public void CloseTicket_ShouldChangeStatusToClosed()
    {
        // Arrange
        var t = manager.CreateTicket("Testärende");

        // Act
        manager.CloseTicket(t.TicketId);
        var closed = manager.GetTicket(t.TicketId);

        // Assert
        Assert.That(closed, Is.Not.Null);
        Assert.That(closed!.Status, Is.EqualTo("Closed"));
    }
}