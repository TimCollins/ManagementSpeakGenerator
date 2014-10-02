namespace MSG.DomainLogic
{
    public class CommandLineArgs
    {
        public bool ShowHelp { get; set; }
        public string OutputFile { get; set; }
        public OutputType OutputType { get; set; }
        public int SentenceCount { get; set; }

        public CommandLineArgs()
        {
            
        }

        public CommandLineArgs(OutputType type, int count)
        {
            OutputType = type;
            SentenceCount = count;
        }
    }
}
