using System;

namespace Garage1
{
    public class MenuItem
    {
        public string option;
        public Action RelatedAction { get; set; }
        public string Description;

        public void ExecEntry()
        {
            RelatedAction.Invoke();
        }
    }
}