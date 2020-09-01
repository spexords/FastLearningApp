using System;

namespace FastLearningApp.Base
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
