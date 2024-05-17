public class Scripture
{
    // For the purpose of this exercise, I will NOT be using auto implemented properties as to make the measures
    // of encapsulation more explicit.

    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split the text into words
    }

    /// <summary>
    /// Select random words from the text and change their state to hidden.
    /// </summary>
    /// <param name="count">The number of words to hide.</param>
    /// <returns>
    /// The words that were hidden.
    /// </returns>
    public void HideRandomWords(int count)
    {
        Random rand = new();
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(_words.Count);
            _words[index].Hide();
        }
    }
    
    //GetDisplayText
    
    //IsCompletelyHidden
}