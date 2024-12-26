namespace Allin.Common.Exceptions
{
    public abstract class AllinException : Exception
    {
        protected AllinException(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; set; }
        public abstract string ErrorMessage { get; }

    }
}
