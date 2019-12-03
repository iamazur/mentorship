using System;
using System.Collections.Generic;
using System.Text;

namespace IDisposable_TEST
{
    public sealed class ErrorList : IDisposable
    {
        private string category;
        private List<string> errors;

        public ErrorList(string category)
        {
            this.category = category;
            this.errors = new List<string>();
        }

        // No need
        public void Dispose()
        {
            if (this.errors != null)
            {
                this.errors.Clear();
                this.errors = null;
            }
        }

        ~ErrorList()
        {
            // DON'T DO THIS
            // Could lead to an exceprion in finalizer thread
            this.Dispose();
        }
    }
}
