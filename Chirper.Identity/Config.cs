using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace Chirper.Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
                {
                    new ApiResource("api/postmessage", "Post Message"),
                    new ApiResource("api/subscribe", "Subscribe To Chirp User")
                };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                {
                    new Client
                    {
                        ClientId = "chirper.web",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "api/postmessage", "api/subscribe" }
                    }
                };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "alice",
                        Password = "Super_Strong_Password"
                    },
                    new TestUser
                    {
                        SubjectId = "2",
                        Username = "bob",
                        Password = "Super_Strong_Password"
                    }
                };
        }
    }
}
