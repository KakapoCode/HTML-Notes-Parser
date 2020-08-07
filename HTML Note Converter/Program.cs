//Last updated 8/7/2020: Jonathan Simpson
//This program finds a Notes.txt file in C:\Users\Public\Notes.txt.
//After finding the file, it will parse it looking for chunks of text between brackets {Like this}
//It will then replace the brackets with a specified HTML tag. For instance, if <div> is specified, {Like this} will become <div>Like this</div>
//It should also support user input for indicating a CSS/HTML class.
//For instance, if a user inputs class="mydiv", the result should be: <div class="mydiv">Like this</div>
//The goal is to do this WITHOUT using String.Replace functionality. I must parse and replace the strings manually.

//TODO: Add a menu to allow the user to specify his or her HTML/CSS tags.

//TODO: Add a method to ensure our input file has an equal number of braces, and that a { is followed by a }. If orphan brackets are found, throw an error. 
//TODO: Test to make sure the notes.txt file exists. How??
//TODO: Try to learn more about unit testing, and add unit tests where applicable.
using System;

namespace HTML_Note_Converter
{

    class Program
    {
        static void Main(string[] args)
        {
            string tagStart = "<div>";
            string tagEnd = "</div>";
            var convert = new Converter(tagStart, tagEnd);
            convert.SetFile();
            convert.StartParse();
            convert.DisplayNewString();
            
        }
    }
}
