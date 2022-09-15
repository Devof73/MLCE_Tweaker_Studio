using System;


namespace Expoint.ITC
{
    internal class LegacyResourceException : Exception
    {
        private string errMsg_;
        private string dcrpt_;
        private int AtIndex;
        private string path;
        public LegacyResourceException(string errMsg, string dcrpt, string targetpath = "", int ocurredAtIndex = 0)
        {
            errMsg_ = errMsg;
            dcrpt_ = dcrpt;
            AtIndex = ocurredAtIndex;
            path = targetpath;
            
        }
        public string TargetPath
        {
            get { return path; }
        }
        override public string Message
        {
            get { return errMsg_; }
        } 
        internal string Description
        {
            get { return dcrpt_; }
        }
        internal int OcurredAtIndex
        {
            get { return AtIndex; }
        }

    }
}
