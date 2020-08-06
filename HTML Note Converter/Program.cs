//Last updated 8/6/2020: Jonathan Simpson
//This program finds a Notes.txt file in C:\Users\Public\Notes.txt.
//After finding the file, it will parse it looking for chunks of text between brackets {Like this}
//It will then replace the brackets with a specified HTML tag. For instance, if <div> is specified, {Like this} will become <div>Like this</div>
//It should also support user input for indicating a CSS/HTML class.
//For instance, if a user inputs class="mydiv", the result should be: <div class="mydiv">Like this</div>
//The goal is to do this WITHOUT using String.Replace functionality. I must parse and replace the strings manually.


//TODO: Add the HTML tag and style/class information to the parsed strings.
//TODO: Remove the empty space (\0?) characters from between code blocks. For instance, {Hello}  {World} should result in {Hello}{World}
//TODO: Test to make sure the notes.txt file exists. How??
//TODO: Try to learn more about unit testing, and add unit tests where applicable.

//CURRENT ISSUES: The parser does NOT take into account empty characters. Empty characters in the notes are not, as of yet, supported.
using System;

namespace HTML_Note_Converter
{
    class Converter
    {
        private string Text;
        private string StyleClass;
        private string[] ParsedStrings;
        private int Count = 0;
        private readonly int CodeSize = 1;

        public Converter(string styleClass)
        {
            this.StyleClass = styleClass;
        }

        
        //Parses our notes file using the FindCode method.
        public void StartParse()
        {
            for (int i = 0; i < Count; i++)
            {
                FindCode(i);
            }
        }

        //Sets the text to the Notes.txt file that we want to convert.
        public void SetFile()
        {
            Text = System.IO.File.ReadAllText(@"C:\Users\Public\Notes.txt");
            DetermineLength();
        }

        //Determine the number of {codeblocks} in our file. As of now, only one codeblock type {} is supported.
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


        //Create an index to the start and end of the two code characters { }
        //Store the text between these identifiers in a substring.
        //We need a function to remove empty spaces, or non-text spaces.
        //Currently, the program only works if the text file has no spaces or paragraph breaks.
        public void FindCode(int i)
        {
            //int indexStart = Text.IndexOf("{");
            int indexStart = Text.IndexOf("{");
            int indexEnd = Text.IndexOf("}");

            if (indexEnd >= 0 && i < Count)
            {
                int textLength = Text.Length - indexEnd - CodeSize;
                ParsedStrings[i] = Text.Substring(indexStart + CodeSize, indexEnd - CodeSize);
                Text = Text.Substring(indexEnd + CodeSize, textLength);
            }

            if (indexEnd >= 0 && i == Count)
                ParsedStrings[i] = Text.Substring(1, Text.Length - 1);
        }

        //Display our parsed strings.
        public void DisplayNewString()
        {
            for (int i = 0; i < ParsedStrings.Length; i++)
                Console.WriteLine(ParsedStrings[i]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var convert = new Converter("<div>");
            convert.SetFile();
            convert.StartParse();
            convert.DisplayNewString();
        }
    }
}
