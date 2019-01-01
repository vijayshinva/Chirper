namespace Chirper.Utilities.Logging
{
    internal interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
    }
}
