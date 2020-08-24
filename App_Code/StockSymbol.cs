using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for StockSymbol
/// </summary>
[DataContract]
public class StockSymbol
{
    private string description;
    private string displaySymbol;
    private string symbol;
    
    [DataMember]
    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    [DataMember]
    public string DisplaySymbol
    {
        get
        {
            return displaySymbol;
        }

        set
        {
            displaySymbol = value;
        }
    }
    
    [DataMember]
    public string Symbol
    {
        get
        {
            return symbol;
        }

        set
        {
            symbol = value;
        }
    }
}