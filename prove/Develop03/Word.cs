public class Word
{
    private string _word;
    private bool _isHidden;
    
    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
    
    public string Hidden()
    {
        char[] hidden = new char[_word.Length];
        for (int i = 0; i < _word.Length; i++) // How is it implied that `i` is an integer???
        {
            hidden[i] = '_';
        }
        return string.Join("", hidden);
    }

    public override string ToString()
    {
        if (_isHidden)
        {
            return Hidden();
        }
        else
        {
            return _word;
        }
    
    }

    public void Hide()
    {
        _isHidden = true;
    }
    
    public void Reveal()
    {
        _isHidden = false;
    }
}