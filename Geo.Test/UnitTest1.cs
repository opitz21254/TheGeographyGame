using Geo.Logic;

namespace Geo.Test;

//X Modify tests to how I want them
//Write Correct logic code, going through each test
//Refactor Tests
//Update Logic code
//Write Blazor


public class GameTests
{
    private GameRunner _game;
    private List<VanillaLocation> _p1Hand;
    private List<VanillaLocation> _p2Hand;
    private List<VanillaLocation> _p3Hand;

    [SetUp]
    public void Setup()
    {
        p1Deck = new List<VanillaLocation>
        {
            new VanillaLocation("Mathew 1:1", 1, 1, 2),
            new VanillaLocation("Mathew 2:1", 1, 1, 2),
            new VanillaLocation("Mathew 3:1", 1, 1, 2),
            new VanillaLocation("Mathew 4:1", 1, 1, 2),
            new VanillaLocation("Mathew 5:1", 1, 1, 2),
        };

        p2Deck = new List<VanillaLocation>
        {
            new VanillaLocation("Mark 1:1", 1, 1, 2),
            new VanillaLocation("Mark 2:1", 1, 1, 2),
            new VanillaLocation("Mark 3:1", 1, 1, 2),
            new VanillaLocation("Mark 4:1", 1, 1, 2),
            new VanillaLocation("Mark 5:1", 1, 1, 2),
        };

        p3Deck = new List<VanillaLocation>
        {
            new VanillaLocation("Luke 1:1", 1, 1, 2),
            new VanillaLocation("Luke 2:1", 10, 10, 10), // I intentionally made a  high-value card
            new VanillaLocation("Luke 3:1", 1, 1, 2),
            new VanillaLocation("Luke 4:1", 1, 1, 2),
            new VanillaLocation("Luke 5:1", 1, 1, 2),
        };

        _game = new GameRunner(new List<List<VanillaLocation>> { p1Deck, p2Deck, p3Deck });

        _game.CreatePlayer("Albert");
        _game.CreatePlayer("Bob");
        _game.CreatePlayer("Sarah");

        _game.Start();
    }


    private List<VanillaLocation> CreateDeck(string prefix, int count)
    {
        return Enumerable.Range(1, count)
            .Select(i => new VanillaLocation(
                $"{prefix} {i}:1",
                population: i % 10, // Example varied stats
                area: (i + 3) % 10,
                neighbors: (i + 5) % 10
            ))
            .ToList();
    }

    private List<VanillaLocation> CreateHand(string prefix, int count)
    {
        return Enumerable.Range(1, count)
            .Select(i => new VanillaLocation($"{prefix} {i}:1", 1, 1, 2))
            .ToList();
    }

    [Test]
    public void CreatePlayers_WithValidHands_ReturnsTrue()
    {
        Assert.IsTrue(_game.CreatePlayer("Albert", _p1Hand));
        Assert.IsTrue(_game.CreatePlayer("Bob", _p2Hand));
        Assert.IsTrue(_game.CreatePlayer("Sarah", _p3Hand));
    }

    [Test]
    public void StartGame_WithThreePlayers_InitializesGameState()
    {
        _game.CreatePlayer("Albert", _p1Hand);
        _game.CreatePlayer("Bob", _p2Hand);
        _game.CreatePlayer("Sarah", _p3Hand);

        var result = _game.Start(_game.Players.ToArray());

        Assert.IsTrue(result);
        Assert.AreEqual(1, _game.Players[0].Hand.Count);
        Assert.AreEqual(1, _game.Players[1].Hand.Count);
        Assert.AreEqual(1, _game.Players[2].Hand.Count);
    }

    [Test]
    public void DrawCard_RespectsTurnLimits()
    {
        _game.CreatePlayer("Albert", _p1Hand);
        _game.Start(_game.Players.ToArray());

        Assert.AreEqual(0, _game.CurrentPlayer);
        Assert.IsTrue(_game.DrawCard(0));
        Assert.AreEqual(2, _game.Players[0].Hand.Count);

        Assert.IsFalse(_game.DrawCard(0));
        Assert.AreEqual(2, _game.Players[0].Hand.Count);

        Assert.IsFalse(_game.DrawCard(1));
        Assert.AreEqual(1, _game.Players[1].Hand.Count);
    }

    [Test]
    public void PlayTrump_WithWinningCard_RedistributesCards()
    {
        // Arrange
        _p3Hand[1] = new VanillaLocation("Luke 2:1", 2, 2, 3); // Winning card
        _game.CreatePlayer("Albert", _p1Hand);
        _game.CreatePlayer("Bob", _p2Hand);
        _game.CreatePlayer("Sarah", _p3Hand);
        _game.Start(_game.Players.ToArray());

        // Act
        _game.Players[0].Onboard();
        _game.Players[1].Onboard();
        _game.Players[2].Onboard();

        var winner = _game.PlayTrump();
        _game.Redistribute(winner);

        // Assert
        Assert.AreEqual(_game.Players[2], winner);
        Assert.AreEqual(7, winner.Hand.Count);
    }

    [Test]
    public void Challenge_WithCorrectAnswer_TransfersCards()
    {
        // Arrange
        _game.CreatePlayer("Albert", _p1Hand);
        _game.CreatePlayer("Bob", _p2Hand);
        _game.Start(_game.Players.ToArray());

        // Act - Challenge setup
        _game.Players[0].Onboard("Everything");
        _game.Players[1].Onboard("Country");

        var answer = _game.PlayChallenge(_game.Players[1], _game.Players[0], "Country");
        var challengeWinner = _game.PlayerChallengedResponse("Israel");

        // Assert
        Assert.AreEqual("Israel", answer);
        Assert.AreEqual(_game.Players[1], challengeWinner);
        Assert.AreEqual(3, _game.Players[0].Hand.Count);
        Assert.AreEqual(5, _game.Players[1].Hand.Count);
    }

    [Test]
    public void GameEnd_WhenPlayerEmptyHand_DeclaresWinner()
    {
        // Arrange
        _game.CreatePlayer("Albert", _p1Hand);
        _game.CreatePlayer("Bob", _p2Hand);
        _game.CreatePlayer("Sarah", _p3Hand);
        _game.Start(_game.Players.ToArray());

        // Act - Simulate game ending scenario
        for (int i = 0; i < 3; i++)
        {
            _game.Players[0].Onboard();
            _game.Players[1].Onboard();
            _game.Players[2].Onboard();

            var winner = _game.PlayTrump();
            _game.Redistribute(winner);
            _game.EndTurn();
        }

        // Assert
        Assert.IsFalse(_game.Running);
        Assert.AreEqual(14, _game.Players[2].Hand.Count);
        Assert.AreEqual(0, _game.Players[0].Hand.Count);
    }
}