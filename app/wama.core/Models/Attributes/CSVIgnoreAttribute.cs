using System;

namespace WAMA.Core.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class CSVIgnoreAttribute : Attribute
    {
    }
}