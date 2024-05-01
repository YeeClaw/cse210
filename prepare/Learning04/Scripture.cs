public class Scripture
{
    // For the purpose of this exercise, I will NOT be using auto implemented properties as to make the measures
    // of encapsulation more explicit.

    private readonly Reference _reference;
    private readonly List<Word> _textAsWords = [];
    private List<Word> _hiddenWords = [];
    private int _round;
    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _round = 0;
        
        foreach (string word in text.Split(' '))
        {
            _textAsWords.Add(new Word(word));
        }
    }

    public void Display()
    {
        string input;
        do
        {
            Console.Clear();
            Console.WriteLine($"{_reference.ToString()} {GetHiddenText()}\n");

            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
        } while (input != "quit" || _hiddenWords.Count < _textAsWords.Count);
    }

    private string GetHiddenText()
    {
        Random rand = new();
        var iterate = 0;
        List<string> finalOut = [];
        
        if (_round > 0)
        {
            do
            {
                var magicNumber = rand.Next(_textAsWords.Count);
                var word = _textAsWords[magicNumber];
                if (word.IsHidden() || _hiddenWords.Contains(word)) continue;
            
                word.Hide();
                _hiddenWords.Add(word);
                iterate++;
            } while (iterate < 3);
        }
        
        foreach (var word in _textAsWords)
        {
            finalOut.Add(word.ToString());
        }
        
        _round++;
        return string.Join(" ", finalOut);
    }

    public int GetRound()
    {
        return _round;
    }
}