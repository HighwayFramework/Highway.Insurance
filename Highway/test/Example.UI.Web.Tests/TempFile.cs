using System;
using System.IO;

namespace Example.UI.Web.Tests
{
    /// <summary>
    ///     Wrapper for a temporary file
    /// </summary>
    public class TempFile : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TempFile" /> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        public TempFile(string contents)
        {
            FilePath = Path.GetTempFileName();

            File.WriteAllText(FilePath, contents);
        }

        /// <summary>
        ///     Gets the file path.
        /// </summary>
        /// <value>
        ///     The file path.
        /// </value>
        public string FilePath { get; private set; }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            File.Delete(FilePath);
        }
    }
}