using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ClientCert;


// Load the client certificate
var cert = new X509Certificate2("/Users/ltony1024/test-cert.pfx", "123");

// Create a WebRequestHandler and add the client certificate
var handler = new HttpClientHandler();
handler.ClientCertificates.Add(cert);

var handler1 = new SocketsHttpHandler
{
    SslOptions =
    {
#pragma warning disable CA1416
        CipherSuitesPolicy = new CipherSuitesPolicy(
            new[]
            {
                TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384,
                TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384
            }),
#pragma warning restore CA1416
    },
};

using var client = new HttpClient(handler);
client.BaseAddress = new Uri("https://your_url.com");

var resp = await new CryptoClient(client).GetAsync("");

// Print the response
Console.WriteLine(resp);