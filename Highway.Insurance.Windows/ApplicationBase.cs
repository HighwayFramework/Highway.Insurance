using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Highway.Insurance.UI.Windows
{
    public abstract class ApplicationBase<T> : ICodedUIApplication where T : UITestControl
    {
        protected abstract string ApplicationExeLocation { get; }

        public T MainWindow { get; private set; }

        public ApplicationUnderTest Application { get; private set; }

        /// <exception cref="Exception">Any Error thrown during startup of the application</exception>
        public virtual void Start()
        {
            try
            {
                Trace.WriteLine(string.Format("Starting Application {0}", ApplicationExeLocation));

                Application = ApplicationUnderTest.Launch(ApplicationExeLocation);
                Application.TechnologyName = "MSAA";

                StartUpSteps();
                MainWindow = GetMainWindow();
                MainWindow.Find();
                MainWindow.WaitForControlReady();
            }
            catch (Exception)
            {
                Close();
                throw;
            }
        }

        public virtual void Close()
        {
            Trace.WriteLine("Closing Application");
            if (Application.Process.HasExited)
            {
                Trace.WriteLine("Application Process has already exited (crashed?)");
                Application.Process.Dispose();
                return;
            }
            Application.Process.CloseMainWindow();
            ExitProgramSteps();
            Application.Process.WaitForExit(5000);
            if (!Application.Process.HasExited)
            {
                Trace.WriteLine("Application Failed to exit (modal window open?), killing process");
                Application.Process.Kill();
            }
            Application.Process.Dispose();
            Application = null;
        }

        protected abstract void StartUpSteps();

        protected abstract T GetMainWindow();

        protected abstract void ExitProgramSteps();
    }
}