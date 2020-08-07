using System;
using System.Collections.Generic;
using System.Text;

namespace HTML_Note_Converter
{
    class Converter
    {
        private string Text;
        private string ConvertedNotes;
        private string[] ParsedStrings;

        private string StyleClass;
        private string StyleClassEnd;

        private int Count = 0;
        private readonly int CodeSize = 1;

        public Converter(string styleClass, string styleClassEnd)
        {
            this.StyleClass = styleClass;
            this.StyleClassEnd = styleClassEnd;
        }


        //Parses our notes. Creates an array of Codeblock strings with FindCode. InsertStyle inserts the formatting.
        //Finally, save our new converted notes to ConvertedNotes.txt
        public void StartParse()
        {
            for (int i = 0; i < Count; i++)
            {
                FindCode(i);
                InsertStyle(i);
            }

            System.IO.File.WriteAllText(@"C:\Users\Public\ConvertedNotes.txt", ConvertedNotes);
        }

        //Sets the text to the Notes.txt file that we want to convert.
        public void SetFile()
        {
            Text = System.IO.File.ReadAllText(@"C:\Users\Public\Notes.txt");
            DetermineLength();
        }

        //Determine the number of {codeblocks} in our file. 
        //After determining the count of codeblocks, set ParsedStrings to ParsedStrings[Count]
        private void DetermineLength()
        {
            int index = Text.IndexOf("}");
            string temp = Text;

            while (index >= 0)
            {
                Count++;
                temp = temp.Substring(index + 1, temp.Length - index - 1);
                index = temp.IndexOf("}");
            }
            Console.WriteLine("{0} Code Blocks found.", Count);
            ParsedStrings = new string[Count];
        }

        //Remove all empty characters, tab characters, and newline characters from the start of a string.
        //This allows the program to properly convert files with spaces and paragraph breaks. 
        private string DeleteEmpty(string s)
        {
            if (!s.StartsWith(' ') && !s.StartsWith('\n') && !s.StartsWith('\r') && !s.StartsWith('\t'))
                return s;
            return DeleteEmpty(s.Substring(1, s.Length - 1));
        }


        //Create an index to the start and end of the two code characters { }
        //Store the text between these identifiers in ParsedStrings, but only after deleting empty/newline/tab type characters.
        private void FindCode(int i)
        {
            //If we're on our first pass, delete all empty characters from the start of the file.
            if (i == 0)
                Text = DeleteEmpty(Text);

            int indexStart = Text.IndexOf("{");
            int indexEnd = Text.IndexOf("}");
            int textLength = Text.Length - indexEnd - CodeSize;

            if (indexEnd >= 0 && i < Count)
            {

                ParsedStrings[i] = DeleteEmpty(Text.Substring(indexStart + CodeSize, indexEnd - CodeSize));
                Text = DeleteEmpty(Text.Substring(indexEnd + CodeSize, textLength));
            }
        }

        //Add the parsed notes to our ConvertedNotes string, with the appropriate styles added.
        private void InsertStyle(int i)
        {
            ConvertedNotes += StyleClass + ParsedStrings[i] + StyleClassEnd + '\n';
        }

        //Display our parsed strings.
        public void DisplayNewString()
        {
            Console.WriteLine(ConvertedNotes);
        }
    }
}
