# HTML-Notes-Parser
Last updated: 8/6/2020 by Jonathan
A simple program designed to parse a text file and convert designated characters between blocks ({ and }) into HTML/CSS tags and classes. 

This program finds a Notes.txt file in C:\Users\Public\Notes.txt.
After finding the file, it will parse it looking for chunks of text between brackets {Like this}
It will then replace the brackets with a specified HTML tag. For instance, if <div> is specified, {Like this} will become <div>Like this</div>
It should also support user input for indicating a CSS/HTML class.
For instance, if a user inputs class="mydiv", the result should be: <div class="mydiv">Like this</div>
The goal is to do this WITHOUT using String.Replace functionality. I must parse and replace the strings manually.

TODO: Add the HTML tag and style/class information to the parsed strings.
TODO: Remove the empty space (\0?) characters from between code blocks. For instance, {Hello}  {World} should result in {Hello}{World}
TODO: Test to make sure the notes.txt file exists. How??
TODO: Try to learn more about unit testing, and add unit tests where applicable.

CURRENT ISSUES: The parser does NOT take into account empty characters. Empty characters in the notes are not, as of yet, supported.
