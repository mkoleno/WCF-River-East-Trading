using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for News
/// </summary>
[DataContract]
public class News
{
    private int id;
    private long datetime;
    private string headline;
    private string image;
    private string related;
    private string source;
    private string summary;
    private string url;

    [DataMember]
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    [DataMember]
    public long Datetime
    {
        get
        {
            return datetime;
        }

        set
        {
            datetime = value;
        }
    }

    [DataMember]
    public string Headline
    {
        get
        {
            return headline;
        }

        set
        {
            headline = value;
        }
    }

    [DataMember]
    public string Image
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }

    [DataMember]
    public string Related
    {
        get
        {
            return related;
        }

        set
        {
            related = value;
        }
    }

    [DataMember]

    public string Source
    {
        get
        {
            return source;
        }

        set
        {
            source = value;
        }
    }
    [DataMember]

    public string Summary
    {
        get
        {
            return summary;
        }

        set
        {
            summary = value;
        }
    }

    [DataMember]
    public string Url
    {
        get
        {
            return url;
        }

        set
        {
            url = value;
        }
    }
}