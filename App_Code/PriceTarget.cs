using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for PriceTarget
/// </summary>
[DataContract]
public class PriceTarget
{
    private string symbol;
    private decimal targetHigh;
    private decimal targetLow;
    private decimal targetMean;
    private decimal targetMedian;
    private DateTime lastUpdated;

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

    [DataMember]
    public decimal TargetHigh
    {
        get
        {
            return targetHigh;
        }

        set
        {
            targetHigh = value;
        }
    }

    [DataMember]
    public decimal TargetLow
    {
        get
        {
            return targetLow;
        }

        set
        {
            targetLow = value;
        }
    }

    [DataMember]
    public decimal TargetMean
    {
        get
        {
            return targetMean;
        }

        set
        {
            targetMean = value;
        }
    }

    [DataMember]
    public decimal TargetMedian
    {
        get
        {
            return targetMedian;
        }

        set
        {
            targetMedian = value;
        }
    }

    [DataMember]
    public DateTime LastUpdated
    {
        get
        {
            return lastUpdated;
        }

        set
        {
            lastUpdated = value;
        }
    }
}