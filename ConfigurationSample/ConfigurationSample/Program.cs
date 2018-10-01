using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            DefineConfiguration(args);

            ReadConfiguration();
            ReadConnectionString();
            ReadSecret();


        }

        private static void ReadSecret()
        {
            string secret = Configuration["MySecretKey"];
            Console.WriteLine(secret);
        }

        private static void ReadConnectionString()
        {
            string conn1 = Configuration.GetConnectionString("dbserver1");
            Console.WriteLine(conn1);
        }

        private static void ReadConfiguration()
        {
            string val1 = Configuration.GetSection("MySection")["Key1"];
            Console.WriteLine(val1);
        }

        private static void DefineConfiguration(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.production.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
#if DEBUG
                .AddUserSecrets("7E6644FB-DEEF-4B7B-BE2E-12D905294543")
#else
                .AddAzureKeyVault("vault-id")
#endif
                .Build();
            Configuration = config;
        }

        public static IConfigurationRoot Configuration { get; private set; }
    }
}
