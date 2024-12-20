using System.Text.Json.Serialization;

public class ISP
{
    [JsonPropertyName("asn")]
    public string Asn { get; set; }

    [JsonPropertyName("org")]
    public string Org { get; set; }

    [JsonPropertyName("isp")]
    public string Isp { get; set; }
}

public class Location
{
    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("zipcode")]
    public string Zipcode { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonPropertyName("localtime")]
    public string Localtime { get; set; }
}

public class Risk
{
    [JsonPropertyName("is_mobile")]
    public bool IsMobile { get; set; }

    [JsonPropertyName("is_vpn")]
    public bool IsVpn { get; set; }

    [JsonPropertyName("is_tor")]
    public bool IsTor { get; set; }

    [JsonPropertyName("is_proxy")]
    public bool IsProxy { get; set; }

    [JsonPropertyName("is_datacenter")]
    public bool IsDatacenter { get; set; }

    [JsonPropertyName("risk_score")]
    public int RiskScore { get; set; }
}

public class IpInfo
{
    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    [JsonPropertyName("isp")]
    public ISP Isp { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("risk")]
    public Risk Risk { get; set; }
}