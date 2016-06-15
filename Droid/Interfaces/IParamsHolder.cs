using System;

namespace TechTalk.Droid.Interfaces
{
    public interface IParamsHolder
    {
        T GetParameter<T>(string key, bool remove = true);

        void SetParameter<T>(string key, T parameter);
    }
}