using System;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace FunctionApp1
{
    /// <summary>
    /// Client for accessing Azure Key Vault
    /// </summary>
    /// <see cref="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample4_EncryptDecrypt.md#encrypting-a-key"/>
    public static class AzureKeyVaultClient
    {
        private static KeyClient CreateKeyClient()
        {
            string keyVaultName = "demokeyvault";
            string kvUri = $"https://{keyVaultName}.vault.azure.net";
            return new KeyClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public static CryptographyClient CreateCryptographyClient()
        {
            KeyClient keyClient = CreateKeyClient();
            KeyVaultKey key = keyClient.GetKey("mykey").Value;

            return new CryptographyClient(key.Id, new DefaultAzureCredential());
        }
    }
}
