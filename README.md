Management Speak Generator
==

This is a C# clone of http://sf.net/projects/cbsg/ which is written in [Ada](http://en.wikipedia.org/wiki/Ada_(programming_language)).

Compilation Requirements
--
The project is being developed using Visual Studio 2012 and .NET Framework 4.5. Earlier versions of Visual Studio may work but are untested. 
Binary versions of the following third-party libraries are linked (see the /lib folder):
- [NUnit](http://www.nunit.org/)
- [Moq](https://github.com/Moq/moq4)

Demo App
--
Build and run MSG.ConsoleApp. As its name suggests, it's a console application so runs on the command line. The following switches are supported:

| Switch        | Purpose              |
|:------------- |:---------------------|
| /?            | Show the help screen |
| /o:[x&#124;j&#124;h&#124;t]  | Specify output format of XML, JSON, HTML or Text. If not supplied then a default of text will be used.|
| /f:[file]     | Specify output filename. If not supplied then a file called "msg_output" on the user's desktop will be created. The output filename extension will be derived from the /o parameter so if no extension is specified by the user then a default of ".txt" will be used.|
| /n:[count]    | Specify the number of sentences to generate. If not supplied then a default of 

| Example       | Result               |
|:------------- |:---------------------|
| msg /o:h c:\tmp\output.html            | Create a file called output.html in the c:\tmp folder and output html-formatted sentences into it.|
| msg /o:j      | Create a file called output.json on the user's desktop and output JSON sentences into it.|
| msg /o:x /f:output | Create a file called output.xml in the same folder as the executable and output XML sentences into it.|

To Do
--
- Find bugs!

Useful Links
--
- [Online Markdown Editor](http://dillinger.io/)
- [Mock successive calls to the same method](http://haacked.com/archive/2010/11/24/moq-sequences-revisited.aspx/)