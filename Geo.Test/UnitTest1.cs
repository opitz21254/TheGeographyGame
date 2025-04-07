using Geo.Logic;

namespace Geo.Test;

//X Modify tests to how I want them
//Write Correct code, going through each test
//Write Blazor

public class Tests
{
    [Test]
    public void RunGame()
    {
        // This is necessary to make the tests reliable
        //###Change From List string to List ICard
        List<VanillaLocation> p1SHand = new List<VanillaLocation>
        {
            new VanillaLocation("Mathew 1:1", 1, 1, 2),
            new VanillaLocation("Mathew 2:1", 1, 1, 2),
            new VanillaLocation("Mathew 1:1", 1, 1, 2),
            new VanillaLocation("Mathew 1:1", 1, 1, 2),
            new VanillaLocation("Mathew 1:1", 1, 1, 2),
        };

        List<VanillaLocation> p2SHand = new List<VanillaLocation>
        {
            new VanillaLocation("Mark 1:1", 1, 1, 2),
            new VanillaLocation("Mark 2:1", 1, 1, 2),
            new VanillaLocation("Mark 1:1", 1, 1, 2),
            new VanillaLocation("Mark 1:1", 1, 1, 2),
            new VanillaLocation("Mark 1:1", 1, 1, 2),
        };

        List<VanillaLocation> p3SHand = new List<VanillaLocation>
        {
            new VanillaLocation("Luke 1:1", 1, 1, 2),
            new VanillaLocation("Luke 2:1", 2, 2, 3),
            new VanillaLocation("Luke 3:1", 1, 1, 2),
            new VanillaLocation("Luke 4:1", 1, 1, 2),
            new VanillaLocation("Luke 5:1", 1, 1, 2),
        };
        GameRunner game = new GameRunner(10, p1SHand, p2SHand, p3SHand);

        //Assign starting hands as properties of the Player's
        // List<Player> Players = new List<Player>;
        // Have Each player draw a card
        bool createPlayer = game.CreatePlayer("Albert", p1SHand);
        Assert.True(createPlayer);

        /*
        createPlayer = game.CreatePlayer("Bob", p2SHand)
        Assert.True(createPlayer);

        createPlayer = game.CreatePlayer("Sarah", p3SHand)
        Assert.True(createPlayer)

        bool gamestart = game.Start(params List<Player>);

        Assert.True(gamestart);
        Assert.Equal(1, game.Players[0].Hand.Count);
        Assert.Equal(1, game.Players[1].Hand.Count);
        Assert.Equal(1, game.Players[2].Hand.Count);

        Assert.Equal()
        Assert.Equal(4, game.Players[0].Deck.Count);
        Assert.Equal(4, game.Players[1].Deck.Count);
        Assert.Equal(4, game.Players[2].Deck.Count);

        int p = 0;

        //Player 0
        p = 0;
        Assert.Equal(0, game.CurrentPlayer);
        bool drawcard = game.DrawCard(p);
        Assert.True(drawcard);
        Assert.Equal(2, game.Players[p].Hand.Count);

        //Check that the player can not draw two cards in a turn
        drawcard = game.DrawCard(p);
        Assert.False(drawcard);
        Assert.Equal(2, game.Players[p].Hand.Count);

        //Check that only the active player can draw a card
        drawcard = game.DrawCard(0);
        Assert.False(drawcard);
        Assert.Equal(1, game.Players[1].Hand.Count);

        //Play tops trump style
        var loosingCard = game.Players[0].Hand.FirstOrDefault(c => c.Name == "Mathew 1:1");
        Assert.NotNull(loosingCard);
        var otherLoosingCard = game.Players[1].Hand.FirstOrDefault(c => c.Name == "Mark 1:1");
        Assert.NotNull(otherLoosingCard);
        var winningCard = game.Players[2].Hand.FirstOrDefault(c => c.Name == "Luke 2:1");
        Assert.NotNull(winningCard);

        //Onboard method makes the cards visible to all players, unless an optional parameter
        //is given for one field of the card to hide. Only onboarded cards can be redistributed to other players
        bool moveToBoard = game.Players[0].Onboard();
        Assert.True(moveToBoard);
        moveToBoard = game.Players[1].Onboard();
        Assert.True(moveToBoard);
        moveToBoard = game.Players[2].Onboard();
        Assert.True(moveToBoard);

        player trumpWinner = game.PlayTrump();
        Assert.Equal(game.Players[2], trumpWinner);

        cardRedistribution = game.Redistribute(TrumpWinner);//Gives winning player cards and puts all cards in bottom of deck
        Assert.Equal(7, game.Players[2].Hand.Count)
        game.EndTurn();

        //Play challenge style
        var mathewCard = game.Players[0].Hand.FirstOrDefault(c => c.Name == "Mathew 2:1");
        Assert.NotNull(mathewCard);
        var markCard = game.Players[1].Hand.FirstOrDefault(c => c.Name == "Mark 2:1");
        Assert.NotNull(markCard);

        challengeCorrectAnswer = game.PlayChallenge(game.Players[1], game.Players[0], "Country") //Player whose turn, Player Being Challenged, Fact
        Assert.Equal("Israel", challengeCorrectAnswer);

        bool moveToBoard = game.Players[0].Onboard("Everything"); //Optional Parameter of what to hide
        Assert.True(moveToBoard);
        moveToBoard = game.Players[1].Onboard("Country"); //Optional Parameter of what to hide
        Assert.True(moveToBoard);

        player ChallengeWinner = game.PlayerChallengedResponse("Palestine")
        Assert.Equal(game.Player[1], ChallengeWinner)

        cardRedistribution = game.Redistribute(ChallengeWinner);//Gives winning player cards and puts all cards in bottom of deck
        Assert.Equal(3, game.Players[0].HandCount)
        Assert.Equal(5, game.Players[1].Hand.Count)
        game.EndTurn();

        for(int i = 0; i < 2; i++)
        {
        //Play tops trump style
        var loosingCard = game.Players[0].Hand.FirstOrDefault(c => c.Name == "Mathew 1:1");
        Assert.NotNull(loosingCard);
        var otherLoosingCard = game.Players[1].Hand.FirstOrDefault(c => c.Name == "Mark 1:1");
        Assert.NotNull(otherLoosingCard);
        var winningCard = game.Players[2].Hand.FirstOrDefault(c => c.Name == "Luke 2:1");
        Assert.NotNull(winningCard);

        bool moveToBoard = game.Players[0].Onboard();
        Assert.True(moveToBoard);
        moveToBoard = game.Players[1].Onboard();
        Assert.True(moveToBoard);
        moveToBoard = game.Players[2].Onboard();
        Assert.True(moveToBoard);

        player trumpWinner = game.PlayTrump();
        Assert.Equal(game.Players[2], trumpWinner);

        cardRedistribution = game.Redistribute(TrumpWinner);
        Assert.Equal(7 + 1 + i, game.Players[2].Hand.Count)
        game.EndTurn();
        }
        

        //Simulate and end of game scenario
        //Play tops trump style
        var loosingCard = game.Players[0].Hand.FirstOrDefault(c => c.Name == "Mathew 1:1");
        Assert.NotNull(loosingCard);
        var otherLoosingCard = game.Players[1].Hand.FirstOrDefault(c => c.Name == "Mark 1:1");
        Assert.NotNull(otherLoosingCard);
        var winningCard = game.Players[2].Hand.FirstOrDefault(c => c.Name == "Luke 2:1");
        Assert.NotNull(winningCard);

        bool moveToBoard = game.Players[0].Onboard();
        Assert.True(moveToBoard);
        moveToBoard = game.Players[1].Onboard();
        Assert.True(moveToBoard);
        moveToBoard = game.Players[2].Onboard();
        Assert.True(moveToBoard);

        player trumpWinner = game.PlayTrump();
        Assert.Equal(game.Players[2], trumpWinner);

        cardRedistribution = game.Redistribute(TrumpWinner);
        Assert.Equal(0, game.Players[0].Hand.Count)
        Assert.Equal(1, game.Players[1].Hand.Count)
        Assert.Equal(14, game.Players[2].Hand.Count)

        Assert.False(game.Running);
        */
    }
}
