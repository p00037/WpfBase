using System;

namespace WpfBase.Common
{
    public class SaveErrorMessageExcenption : Exception
    {
        public SaveErrorMessageExcenption(string message) : base(message)
        {
        }
    }
}
