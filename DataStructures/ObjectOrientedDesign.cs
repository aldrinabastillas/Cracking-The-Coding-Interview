using System;
using System.Collections.Generic;

namespace DataStructures
{
	/// <summary>
	/// Chapter 7 in CTCI, 6th edition
	/// </summary>
	public class ObjectOrientedDesign
	{
		#region Cards
		/// <summary>
		/// Question 7.1: Design a generic deck of cards
		/// </summary>
		public class Deck
		{
			//collection of card objects
			protected LinkedList<Card> deck { get; set;}
			public int Count { get { return deck.Count; } }

			//initialize deck collection
			public Deck(GameType type, int count)
			{
				var suits = Enum.GetValues(typeof(Suit));
				foreach (var suit in suits)
				{
					//iterate from 1 to 13 for standard deck of 52
					for (int i = 1; i <= count / suits.Length; i++)
					{
						deck.AddLast(Card.CreateGameCard(type, i, (Suit)suit));
					}
				}
			}

			//remove from top of deck
			public Card[] Deal(int toDeal)
			{
				var dealt = new Card[toDeal];
				for (int i = 0; i < toDeal; i++)
				{
					if (deck.Count == 0)
					{
						return dealt;
					}
					dealt[i] = deck.First.Value;
					deck.RemoveFirst();
				}
				return dealt;
			}

			public void Shuffle()
			{
			}

			public void PutBackOnTop(Card card)
			{
				deck.AddFirst(card);
			}

			public void PutBackOnBottom(Card card)
			{
				deck.AddLast(card);
			}
		}

		public enum Suit { Clover, Spade, Heart, Diamond };

		public enum Color { Black, Red };

		public class Card
		{
			public int FaceValue { get; private set;}

			public Suit Suit { get; private set;}
			public Color Color { get; private set; }

			public virtual int Value
			{
				get
				{
					return FaceValue; 
				} 
			}

			protected Card(int value, Suit suit)
			{
				FaceValue = value;
				Suit = suit;
				if (Suit == Suit.Heart || Suit == Suit.Diamond)
				{
					Color = Color.Red;
				}
				else {
					Color = Color.Black;
				}
			}

			public static Card CreateGameCard(GameType type, int faceValue, Suit suit)
			{
				if (type == GameType.Blackjack)
				{
					return new BlackjackCard(faceValue, suit);
				}
				else {
					return new Card(faceValue, suit);
				}
			}
		}

		public sealed class BlackjackCard : Card
		{
			public BlackjackCard(int ValueType, Suit suit) : base(ValueType, suit)
			{
				
			}
			public override int Value
			{
				get
				{
					//face cards are worth 10
					if (FaceValue > 10)
					{
						return 10;
					}
					return FaceValue;
				}
			}
		}

		public enum GameType { Blackjack, Solitare, Poker };

		public abstract class Game
		{
			public Hand[] Players { get; internal set;}
			public Deck Deck { get; internal set;}
			internal Game(int players)
			{
				this.Players = new Hand[players];
			}
			public static Game CreateGame(GameType type, int players)
			{
				switch (type)
				{
					case GameType.Blackjack:
					{
						return new BlackJack(players);
					}
					case GameType.Solitare:
					{
						return new Solitare();
					}
					default:
					{
						return null;
					}
				}		
			}
		}

		public class BlackJack : Game {
			public Hand Dealer { get; private set;}

			public BlackJack(int players) : base(players)
			{
				Dealer = new Hand();
				Deck = new Deck(GameType.Blackjack, 52);
			}

		}

		public class Solitare : Game
		{
			//always one player
			public Solitare() : base(1)
			{
			}
		}

		public class Hand
		{
			public List<Card> Cards { get; private set; }
			public int NumCards { get { return Cards.Count; } }
			public int TotalValue { get; private set;}

			public Hand()
			{
				Cards = new List<Card>();
			}

			public Hand(params Card[] cards)
			{
				Cards.AddRange(cards);
			}

			public void Add(Card card)
			{
				Cards.Add(card);
			}
		}
		#endregion

		#region Call Center
		/// <summary>
		/// Question 7.2 Design a call center and a dispatchCall() method
		/// that escalates through the ranks
		/// </summary>
		public class CallCenter
		{
			public Dictionary<int, Respondent> Respondents { get; set; }
			public Dictionary<int, Manager> Managers { get; set; }
			public Dictionary<int, Director> Directors { get; set; }
			public Queue<int> freeRespondents;
			public Queue<int> busyRespondents;

			public CallCenter(int r, int m, int d)
			{
				//create r respondents
			}

			public Employee dispatchCall(Call newCall)
			{
				//save space, iterate through all employees
				//save time, keep Queues of free people
				if (freeRespondents.Count > 0)
				{
					var handlerId = freeRespondents.Dequeue();
					busyRespondents.Enqueue(handlerId);
					return Respondents[handlerId];
				}
				else {
					foreach (var manager in Managers.Values)
					{
						if (!manager.Busy) { return manager; }	
					}
					foreach (var director in Directors.Values)
					{
						if (!director.Busy) { return director; }
					}
				}
				return null;
			}

		}

		public class Call
		{
			public Person caller { get; set;}
			public Employee handler { get; set; }
		}

		public abstract class Person {
			public string FirstName { get; set;}
			public string LastName { get; set; }
			//address, phone number, sex, etc.
			protected Person(string firstName, string lastName)
			{
				FirstName = firstName;
				LastName = lastName;
			}
		}

		public class Caller : Person
		{
			public Caller(string firstName, string lastName) : base(firstName, lastName)
			{
			}
		}

		public abstract class Employee : Person
		{
			public int ID { get; set; }
			public bool Busy { get; set; }
			protected Employee(int id) : this(id, "", "") { }

			protected Employee(int id, string firstName, string lastName) : base(firstName, lastName)
			{
				ID = id;
			}

		}

		public class Respondent : Employee
		{
			public Respondent(int id) : base(id) { }
		}

		public class Manager : Employee
		{
			public Manager(int id) : base(id) { }
		}

		public class Director : Employee
		{
			public Director(int id) : base(id) { }
		}
		#endregion

		#region Jukebox
		public class Song 
		{
			public string Name { get; set; }
			public string Artist { get; set; }
		}

		public abstract class Album
		{
			public Song[] songs { get; set; }
			public string Name { get; set; }
			public string Artist { get; set; }
		}

		public class Vinyl : Album
		{
			public int RPM { get; set; }
		}

		public class Digital : Album
		{
			public string Format { get; set;}
		}

		public class Jukebox
		{
			public Dictionary<string, List<string>> Artists; //key is artist name, value is a list of album names
			public Dictionary<string, Album> Albums;
			public Dictionary<string, Song> Songs;

			public Jukebox()
			{
				Albums.Add("Abbey Road", new Vinyl());
				Albums.Add("Hot Fuss", new Digital());
			}
		}
		#endregion
	}
}
