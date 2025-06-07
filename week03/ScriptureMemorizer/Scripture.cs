using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ')
                        .Select(word => new Word(word))
                        .ToList();
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            int wordsHidden = 0;
            
            while (wordsHidden < numberToHide)
            {
                int index = random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    wordsHidden++;
                }
            }
        }

        public string GetDisplayText()
        {
            string displayText = _reference.GetDisplayText() + " ";
            displayText += string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return displayText;
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }
    }
} 