using System;

namespace WpfTemplateApp.Service.Exceptions;

public class WpfExceptions : Exception
{
    public WpfExceptions(string massage) : base(massage)
    {
        
    }
    
}