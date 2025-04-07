namespace Geo.Logic;

public class GameRunner
{
    public List<VanillaLocation> StartingHandOne { get; }
    public List<VanillaLocation> StartingHandTwo { get; }
    public List<VanillaLocation> StartingHandThree { get; }
    public static int StartingLife { get; private set; }

    public static List<Player> Players { get; } = new List<Player>();
    public bool Running { get; private set; } = true;

    //To Keep track of rounds
    public int CurrentRoundNumber { get; private set; }
    public int CurrentPlayer { get; private set; }

    public GameRunner(
        int startingLife,
        List<VanillaLocation> startingHandOne,
        List<VanillaLocation> startingHandTwo,
        List<VanillaLocation> startingHandThree
    )
    {
        StartingLife = startingLife;
        StartingHandOne = startingHandOne;
        StartingHandTwo = startingHandTwo;
        StartingHandThree = startingHandThree;
        CurrentRoundNumber = 0;
    }

    // public bool Start(List<ICard> deck1, List<ICard> deck2)
    // {
    //     if (Players.Count < 2)
    //         return false;
    //     Players[0].AssignDeck(deck1);
    //     Players[1].AssignDeck(deck2);

    //     //Initialize each player's hand with 5 cards based on StartingHand
    //     for (int i = 0; i < Players.Count(); i++)
    //     {
    //         Players[i].PlayerNumber = i;

    //         //Create a new list for each player's hand
    //         for (int j = 0; j < 5; j++)
    //         {
    //             if (Players[i].Deck.Count > j) // Make sure players have cards in their deck
    //             {
    //                 string cardName = StartingHand[j];
    //                 ICard cardInDeck = Players[i].Deck.FirstOrDefault(c => c.Name == cardName);

    //                 if (cardInDeck != null)
    //                 {
    //                     Players[i].Hand.Add(cardInDeck);
    //                     //### In the week 1 assignment it says in the text to include the following code, however, the nunit tests disagree.
    //                     // Players[i].Deck.Remove(cardInDeck);
    //                 }
    //                 else
    //                 {
    //                     DrawCard(i);
    //                 }
    //             }
    //         }
    //     }
    //     return true;
    // }

    // public bool ShuffleCards()
    // {
    //     foreach (var p in Players)
    //     {
    //         var random = new Random();
    //         var mixed = new List<ICard>();
    //         while (p.Deck.Count > 0)
    //         {
    //             int index = random.Next(p.Deck.Count);
    //             var item = p.Deck[index];
    //             p.Deck.Remove(item);
    //             mixed.Add(item);
    //         }
    //         Players[0].AssignDeck(mixed);
    //     }
    //     return true;
    // }

    // public bool DrawCard(int playerIndex)
    // {
    //     if (playerIndex != CurrentPlayer)
    //     {
    //         return false;
    //     }

    //     var player = Players[playerIndex];

    //     if (player.HasDrawnCardThisTurn)
    //     {
    //         return false;
    //     }

    //     if (player.Deck.Count == 0)
    //     {
    //         return false;
    //     }

    //     ICard drawnCard = player.Deck.First();
    //     player.Deck.RemoveAt(0);
    //     player.Hand.Add(drawnCard);
    //     player.HasDrawnCardThisTurn = true;

    //     return true; //No cards left to draw
    // }

    public bool CreatePlayer(string playerName, List<VanillaLocation> startingHand)
    {
        Players.Add(new Player(playerName, List<VanillaLocation> startingHand));
        return true;
    }

    // public bool PlayCard(ICard card, Player target = null)
    // {
    //     var player = Players[CurrentPlayer];

    //     if (!player.Hand.Contains(card))
    //     {
    //         return false;
    //     }

    //     if (card is ICreature creature)
    //     {
    //         player.Hand.Remove(card);
    //         player.Board.Add(creature);
    //         creature.HasAttackedThisTurn = false;
    //         return true;
    //     }
    //     //Creature attacks player directly
    //     else if (card is DamageSpell spell && target != null)
    //     {
    //         player.Hand.Remove(card);
    //         target.Life -= spell.Attack;
    //         if (target.Life <= 0)
    //         {
    //             Running = false;
    //         }
    //         return true;
    //     }

    //     return false;
    // }

    /*
    //Play Card Tops Trump Style
    public bool TopsTrump(ICreature attacker, Player target)
    {
        
    }

    //Play Card as a Challenge
     public bool Challenge(ICreature attacker, Player target)
    {
        
    }
    */

    // private void RemoveCardlessPlayers()
    // {
    //     foreach (var player in Players)
    //     {
    //         player.Board.RemoveAll(creature => creature.Health <= 0);
    //     }
    // }

    // public bool EndTurn()
    // {
    //     Players[CurrentPlayer].HasDrawnCardThisTurn = false;
    //     CurrentPlayer = (CurrentPlayer + 1) % Players.Count;

    //     if (CurrentPlayer == Players.Count - 1)
    //     {
    //         CurrentRoundNumber++;
    //     }

    //     return true;
    // }
}

public class VanillaLocation
{
    public string Location { get; }
    public int DistFromJerusalem { get; }
    public int Elevation { get; }
    public int XMapCoordinate { get; }

    public VanillaLocation(string location, int dist, int elev, int x)
    {
        Location = location;
        DistFromJerusalem = dist;
        Elevation = elev;
        XMapCoordinate = x;
    }
}

public class Player
{
    public string Name { get; }
    public List<VanillaLocation> StartingHand { get; }

    public Player(string name, List<VanillaLocation> startingHand)
    {
        {
            Name = name;
            StartingHand = startingHand;
        }
    }
}
