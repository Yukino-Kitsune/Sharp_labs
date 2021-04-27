using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;

namespace lab4
{
    class card
    {
        private string suit;
        private string number;

        public string num_of_card
        {
            get { return number; } //В принципе не нужно
            set { number = value; }
        }
        
        public string suit_of_card
        {
            get { return suit; } //В принципе не нужно
            set { suit = value; }
        }
        
        public string printCard
        {
            get { return number + suit; }
        }
        public card()
        {
            //this.number = 0.ToString();
            //this.suit = 0.ToString();
        }
        public card(string num, string suit)
        {
            this.number = num;
            this.suit = suit;
        }
        
    }
    class deck_of_cards
    {
        private Dictionary<int, string> suits = new Dictionary<int, string>
        {
            {0, "♥"},
            {1, "♠"},
            {2, "♣"},
            {3, "♦"}
        };
        private int count = 0;
        private card[] deck = new card[0];
        
        public int howMuchCardsInDeck
        {
            get { return count; }
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return deck[index].num_of_card + deck[index].suit_of_card;
                }
                else return "Error";
            }
        }
        public deck_of_cards(int count)
        {
            this.count = count;
            if (count < 0 || count > 52)
            {
                Console.WriteLine("Error. Wrong count of cards");
                Environment.Exit(0);
            }
            Array.Resize(ref deck, deck.Length + count);
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = new card();
            }
            int current = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j <= 14; j++)
                {
                    switch (j)
                    {
                        case 11:
                            deck[current].suit_of_card = suits[i];
                            deck[current].num_of_card = "J";
                            current++;
                            continue;
                        case 12:
                            deck[current].suit_of_card = suits[i];
                            deck[current].num_of_card = "Q";
                            current++;
                            continue;
                        case 13:
                            deck[current].suit_of_card = suits[i];
                            deck[current].num_of_card = "K";
                            current++;
                            continue;
                        case 14:
                            deck[current].suit_of_card = suits[i];
                            deck[current].num_of_card = "A";
                            current++;
                            continue;
                        default:
                            deck[current].suit_of_card = suits[i];
                            deck[current].num_of_card = j.ToString();
                            current++;
                            continue;
                    }
                }
            }
        }
        public void printAllDeck()
        {
            if (count == 0)
            {
                Console.WriteLine("Cards are over");
                return;
            }
            for (int i = 0; i < 13; i++)
            {
                Console.Write(deck[i].printCard + "\t" + deck[i + 13].printCard + "\t" + deck[i + 26].printCard + "\t" +
                              deck[i + 39].printCard);
                Console.WriteLine();
            }
        }

        public void printCardbyNumber(int num)
        {
            if(num >=0 && num < count)
                Console.WriteLine(deck[num].printCard);
            else
                Console.WriteLine("Error. Card don't found!");
        }

        private void swap(int first, int second)
        {
            var temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
        }

        public void shuffle()
        {
            //алгоритм Ричарда Дурштенфельда (современный алгоритм Фишера-Йетса)
            var rand = new Random();
            for (int i = count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i);
                swap(i, j);
            }
        }

        private void takeCard(int num)
        {
            if (count == 0)
            {
                Console.WriteLine("Cards are over");
                return;
            }
            if (num >= 0 && num < count)
            {
                Console.WriteLine($"You take card number {num}. This is {deck[num].printCard}");
                var tmp = new List<card>(deck);
                tmp.RemoveAt(num);
                deck = tmp.ToArray();
                count--;
            }
            else
                Console.WriteLine("Error. Card don't found!");
        }

        public void takeRandonCard()
        {
            if(count == 0) return;
            var rand = new Random();
            takeCard(rand.Next(0, count));
        }
        public void takeSixRandonCard()
        {
            for (int i = 0; i < 6; i++)
                takeRandonCard();
        }

        public void takeAllbyOne()
        {
            for (int i = 0; i < count;)
            {
                Console.WriteLine("Take one");
                takeRandonCard();
            }
        }

        public void takeAllbySix()
        {
            for (int i = 0; i < count;)
            {
                Console.WriteLine($"Take six");
                takeSixRandonCard();
            }
        }

    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            int A;
            deck_of_cards deck = new deck_of_cards(52);
            do
            {
                Console.Write("1. Recreate deck\n" +
                              "2. Shuffle deck\n" +
                              "3. Print card by number\n" +
                              "4. Print all deck\n" +
                              "5. Take one card\n" +
                              "6. Take six cards\n" +
                              "7. Take all by one\n" +
                              "8. Take all by six\n" +
                              "9. How much cards in deck? " + deck.howMuchCardsInDeck.ToString() + "\n" +
                              "0. Exit\n" +
                              "Take option: ");
                A = Int32.Parse(Console.ReadLine());
                switch (A)
                {
                    case 1:
                        deck = new deck_of_cards(52);
                        continue;
                    case 2:
                        deck.shuffle();
                        continue;
                    case 3:
                        int num;
                        Console.Write("Enter number of card: ");
                        num = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(deck[num]);
                        //deck.printCardbyNumber(num);
                        continue;
                    case 4:
                        deck.printAllDeck();
                        continue;
                    case 5:
                        deck.takeRandonCard();
                        continue;
                    case 6:
                        deck.takeSixRandonCard();
                        continue;
                    case 7:
                        deck.takeAllbyOne();
                        continue;
                    case 8:
                        deck.takeAllbySix();
                        continue;
                }
            } while (A != 0);
        }
    }
}