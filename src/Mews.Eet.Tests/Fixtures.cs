using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Mews.Eet.Tests
{
    public class Fixtures
    {
        public static TaxPayerFixture First = new TaxPayerFixture
        {
            TaxId = "CZ1212121218",
            PremisesId = 1,
            CertificatePassword = "eet",
            CertificatePath = GetPath("Data/Certificates/Playground/EET_CA1_Playground-CZ1212121218.p12")
        };

        public static TaxPayerFixture Second = new TaxPayerFixture
        {
            TaxId = "CZ00000019",
            PremisesId = 1,
            CertificatePassword = "eet",
            CertificatePath = GetPath("Data/Certificates/Playground/EET_CA1_Playground-CZ00000019.p12")
        };

        public static TaxPayerFixture Third = new TaxPayerFixture
        {
            TaxId = "CZ683555118",
            PremisesId = 1,
            CertificatePassword = "eet",
            CertificatePath = GetPath("Data/Certificates/Playground/EET_CA1_Playground-CZ683555118.p12")
        };

        public static TaxPayerFixtureForCertificateStore Fourth = new TaxPayerFixtureForCertificateStore
        {
            TaxId = "CZ00000019",
            PremisesId = 1,
            StoreLocation = StoreLocation.CurrentUser,
            StoreName = StoreName.My,
            FindType = X509FindType.FindBySubjectName,
            FindValue = "CZ00000019"
        };

        private static string GetPath(string relativePath)
        {
            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);
            return Path.Combine(dirPath, relativePath);
        }
    }

    public class TaxPayerFixture
    {
        public string TaxId { get; set; }
        public int PremisesId { get; set; }
        public string CertificatePassword { get; set; }
        public string CertificatePath { get; set; }
    }


    public class TaxPayerFixtureForCertificateStore
    {
        public string TaxId { get; set; }
        public int PremisesId { get; set; }
        public StoreLocation StoreLocation { get; set; }
        public StoreName StoreName { get; set; }
        public X509FindType FindType { get; set; }
        public object FindValue { get; set; }
    }
}
