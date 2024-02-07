using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
        // Add scriptures to the library
        InitializeLibrary();
    }

    private void InitializeLibrary()
    {
    
        _scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        _scriptures.Add(new Scripture(new Reference("2 Nephi", 9, 28, 29),  "O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish. But to be learned is good if they hearken unto the counsels of God."));
        _scriptures.Add(new Scripture(new Reference("Moses", 1, 39), "Adam fell that men might be; and men are, that they might have joy"));

        _scriptures.Add(new Scripture(new Reference("Alma", 32, 21),  "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."));
    }

    public Scripture GetRandomScripture()
    {
       
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
