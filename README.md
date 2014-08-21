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
Build and run MSG.ConsoleApp to generate output.txt in the same directory as the executable. By default the file will contain 500 example sentences.

To Do
--
- Complete the porting of the source.


Useful Links
--
- [Online Markdown Editor](http://dillinger.io/)
- [Mock successive calls to the same method](http://haacked.com/archive/2010/11/24/moq-sequences-revisited.aspx/)