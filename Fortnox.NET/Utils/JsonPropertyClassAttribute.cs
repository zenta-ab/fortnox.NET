using System;

namespace FortnoxNET.Utils
{
    [AttributeUsage(AttributeTargets.Class)]
    public class JsonPropertyClassAttribute : Attribute
    {

        public JsonPropertyClassAttribute(string jsonPropertyName)
        {
            JsonPropertyName = jsonPropertyName;
        }
        
        public string JsonPropertyName { get; }
    }
}