namespace AdventOfCode.Year2023;

public class Day7 : ISolver<long>
{
    public enum Scores
    {
        FiveOfKind,
        FourOfKind,
        Full,
        ThreeOfKind,
        TwoPairs,
        Pair,
        Single
    }

    public long PartOne(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var games = lines
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(x => new Game(x[0], x[1]))
            .ToList();

        games.Sort();
        games.Reverse();

        return games.Select((x, i) => x.Bid * (i + 1)).Sum();
    }

    public long PartTwo(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var games = lines
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(x => new Game2(x[0], x[1]))
            .ToList();

        games.Sort();
        games.Reverse();

        return games.Select((x, i) => x.Bid * (i + 1)).Sum();
    }

    public class Game : IComparable<Game>
    {
        private static readonly List<char> CardStrength = new()
            { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

        private readonly string _bid;
        private readonly char[] _cards;
        private readonly char[] _distinctCards;

        public Game(string cards, string bid)
        {
            _bid = bid;
            _cards = cards.Select(x => x).ToArray();
            _distinctCards = _cards.Distinct().ToArray();
        }

        public Lazy<bool> IsFiveOfKind
        {
            get { return new Lazy<bool>(() => _distinctCards.Select(x => _cards.Count(xx => xx == x)).Max() == 5); }
        }

        public Lazy<bool> IsFourOfKind
        {
            get { return new Lazy<bool>(() => _distinctCards.Select(x => _cards.Count(xx => xx == x)).Max() == 4); }
        }

        public Lazy<bool> IsFull
        {
            get
            {
                return new Lazy<bool>(() =>
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 3) == 1 &&
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 2) == 1);
            }
        }

        public Lazy<bool> IsThreeOfKind
        {
            get
            {
                return new Lazy<bool>(() =>
                    !IsFull.Value && _distinctCards.Select(x => _cards.Count(xx => xx == x)).Max() == 3);
            }
        }

        public Lazy<bool> IsTwoPairs
        {
            get
            {
                return new Lazy<bool>(() =>
                    !IsThreeOfKind.Value &&
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 2) == 2);
            }
        }

        public Lazy<bool> IsPair
        {
            get
            {
                return new Lazy<bool>(() =>
                    !IsFull.Value &&
                    !IsTwoPairs.Value &&
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 2) == 1);
            }
        }

        public Scores Score
        {
            get
            {
                if (IsFiveOfKind.Value) return Scores.FiveOfKind;
                if (IsFourOfKind.Value) return Scores.FourOfKind;
                if (IsFull.Value) return Scores.Full;
                if (IsThreeOfKind.Value) return Scores.ThreeOfKind;
                if (IsTwoPairs.Value) return Scores.TwoPairs;
                if (IsPair.Value) return Scores.Pair;
                return Scores.Single;
            }
        }

        public int Bid => int.Parse(_bid);

        public int CompareTo(Game? other)
        {
            if (other == null) return 1;
            if (Score > other.Score) return 1;
            if (Score < other.Score) return -1;

            var index = 0;
            while (_cards[index] == other._cards[index]) index++;


            return CardStrength.IndexOf(_cards[index]).CompareTo(CardStrength.IndexOf(other._cards[index]));
        }
    }


    public class Game2 : IComparable<Game2>
    {
        private static readonly List<char> CardStrength = new()
            { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };

        private readonly string _bid;
        private readonly char[] _cards;
        private readonly char[] _distinctCards;

        public Game2(string cards, string bid)
        {
            _bid = bid;
            _cards = cards.Select(x => x).ToArray();
            _distinctCards = _cards.Distinct().ToArray();
        }

        public Lazy<bool> IsFiveOfKind
        {
            get { return new Lazy<bool>(() => _distinctCards.Select(x => _cards.Count(xx => xx == x)).Max() == 5); }
        }

        public Lazy<bool> IsFourOfKind
        {
            get { return new Lazy<bool>(() => _distinctCards.Select(x => _cards.Count(xx => xx == x)).Max() == 4); }
        }

        public Lazy<bool> IsFull
        {
            get
            {
                return new Lazy<bool>(() =>
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 3) == 1 &&
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 2) == 1);
            }
        }

        public Lazy<bool> IsThreeOfKind
        {
            get
            {
                return new Lazy<bool>(() =>
                    !IsFull.Value && _distinctCards.Select(x => _cards.Count(xx => xx == x)).Max() == 3);
            }
        }

        public Lazy<bool> IsTwoPairs
        {
            get
            {
                return new Lazy<bool>(() =>
                    !IsThreeOfKind.Value &&
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 2) == 2);
            }
        }

        public Lazy<bool> IsPair
        {
            get
            {
                return new Lazy<bool>(() =>
                    !IsFull.Value &&
                    !IsTwoPairs.Value &&
                    _distinctCards.Select(x => _cards.Count(xx => xx == x)).Count(x => x == 2) == 1);
            }
        }

        public Scores Score
        {
            get
            {
                var score = new Game(string.Join("", _cards), _bid).Score;
                if (_cards.Contains('J'))
                    foreach (var c in CardStrength)
                    {
                        var cards = _cards.Select(cc => cc == 'J' ? c : cc);
                        var newScore = new Game(string.Join("", cards), _bid).Score;
                        score = (Scores)Math.Min((int)score, (int)newScore);
                    }

                return (Scores)(int)score;
            }
        }

        public int Bid => int.Parse(_bid);

        public int CompareTo(Game2? other)
        {
            if (other == null) return 1;
            if (Score > other.Score) return 1;
            if (Score < other.Score) return -1;

            var index = 0;
            while (_cards[index] == other._cards[index]) index++;


            return CardStrength.IndexOf(_cards[index]).CompareTo(CardStrength.IndexOf(other._cards[index]));
        }
    }
}