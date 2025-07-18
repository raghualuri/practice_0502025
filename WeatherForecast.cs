namespace practice_0502025
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

//        String MessageSignature = String.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\n{12}{13}",
//    method.ToString().ToUpperInvariant(), // {0} - HTTP Verb, must be uppercase
//    GetHeader(httpRequestMessage, "Content-Encoding"),     // {1}
//    GetHeader(httpRequestMessage, "Content-Language"),     // {2}
//    (method == HttpMethod.Get || method == HttpMethod.Head) ? String.Empty : GetHeader(httpRequestMessage, "Content-Length"), // {3}
//    GetHeader(httpRequestMessage, "Content-MD5"),          // {4}
//    GetHeader(httpRequestMessage, "Content-Type"),         // {5}
//    GetHeader(httpRequestMessage, "Date"),                 // {6} (This is usually empty as x-ms-date is used)
//    GetHeader(httpRequestMessage, "If-Modified-Since"),    // {7}
//    GetHeader(httpRequestMessage, "If-Match", ifMatch),    // {8}
//    GetHeader(httpRequestMessage, "If-None-Match"),        // {9}
//    GetHeader(httpRequestMessage, "If-Unmodified-Since"),  // {10}
//    GetHeader(httpRequestMessage, "Range"),                // {11}
//    GetCanonicalizedHeaders(httpRequestMessage),           // {12} - x-ms- headers (like x-ms-date, x-ms-version)
//    GetCanonicalizedResource(httpRequestMessage.RequestUri, storageAccountName) // {13} - Account path and query
//);

    }
}
