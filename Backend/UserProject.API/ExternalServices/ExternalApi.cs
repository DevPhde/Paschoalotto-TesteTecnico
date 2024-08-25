using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using UserProject.API.Entities;
using UserProject.API.Interfaces.ExternalServices;

namespace ExternalServices
{
    public class ExternalApi : IExternalApi
    {
        private readonly string _urlApi;
        public ExternalApi(IConfiguration configuration)
        {
            _urlApi = configuration["ExternalServices:UserApi"];
        }

        public async Task<List<User>> GetUsers(int numberOfUsers)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_urlApi + numberOfUsers);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();


                        JObject parsedData = JObject.Parse(jsonData);

                        List<User> users = new List<User>();

                        for (int i = 0; i < numberOfUsers; i++)
                        {
                            Guid? uuid = null;
                            if (Guid.TryParse(parsedData["results"][i]["login"]["uuid"]?.ToString(), out Guid parsedUuid))
                            {
                                uuid = parsedUuid;
                            }

                            Login login = new(
                                uuid: uuid,
                                username: parsedData["results"][i]["login"]["username"]?.ToString(),
                                password: parsedData["results"][i]["login"]["password"]?.ToString(),
                                salt: parsedData["results"][i]["login"]["salt"]?.ToString(),
                                md5: parsedData["results"][i]["login"]["md5"]?.ToString(),
                                sha1: parsedData["results"][i]["login"]["sha1"]?.ToString(),
                                sha256: parsedData["results"][i]["login"]["sha256"]?.ToString()
                            );

                            int? streetNumber = null;
                            if (int.TryParse(parsedData["results"][i]["location"]["street"]["number"]?.ToString(), out int parsedStreetNumber))
                            {
                                streetNumber = parsedStreetNumber;
                            }

                            int? postCode = null;
                            if (int.TryParse(parsedData["results"][i]["location"]["postcode"]?.ToString(), out int parsedPostCode))
                            {
                                postCode = parsedPostCode;
                            }

                            float? longitude = null;
                            if (float.TryParse(parsedData["results"][i]["location"]["coordinates"]["longitude"]?.ToString(), out float parsedLongitude))
                            {
                                longitude = parsedLongitude;
                            }

                            float? latitude = null;
                            if (float.TryParse(parsedData["results"][i]["location"]["coordinates"]["latitude"]?.ToString(), out float parsedLatitude))
                            {
                                latitude = parsedLatitude;
                            }

                            Location location = new(
                                streetName: parsedData["results"][i]["location"]["street"]["name"]?.ToString(),
                                streetNumber: streetNumber,
                                city: parsedData["results"][i]["location"]["city"]?.ToString(),
                                state: parsedData["results"][i]["location"]["state"]?.ToString(),
                                country: parsedData["results"][i]["location"]["country"]?.ToString(),
                                postCode: postCode,
                                longitude: longitude,
                                latitude: latitude,
                                timezoneOffset: parsedData["results"][i]["location"]["timezone"]["offset"]?.ToString(),
                                timezoneDescription: parsedData["results"][i]["location"]["timezone"]["description"]?.ToString()
                            );

                            Picture picture = new(
                                thumbnail: parsedData["results"][i]["picture"]["thumbnail"]?.ToString(),
                                medium: parsedData["results"][i]["picture"]["medium"]?.ToString(),
                                large: parsedData["results"][i]["picture"]["large"]?.ToString()
                            );

                            DateTime? dateOfBirthday = null;
                            if (DateTime.TryParse(parsedData["results"][i]["dob"]["date"]?.ToString(), out DateTime parsedDob))
                            {
                                dateOfBirthday = parsedDob;
                            }

                            DateTime? registeredDate = null;
                            if (DateTime.TryParse(parsedData["results"][i]["registered"]["date"]?.ToString(), out DateTime parsedRegisteredDate))
                            {
                                registeredDate = parsedRegisteredDate;
                            }

                            int? age = null;
                            if (int.TryParse(parsedData["results"][i]["dob"]["age"]?.ToString(), out int parsedAge))
                            {
                                age = parsedAge;
                            }

                            int? ageRegistration = null;
                            if (int.TryParse(parsedData["results"][i]["registered"]["age"]?.ToString(), out int parsedAgeRegistration))
                            {
                                ageRegistration = parsedAgeRegistration;
                            }

                            User user = new(
                                idName: parsedData["results"][i]["id"]["name"]?.ToString(),
                                idValue: parsedData["results"][i]["id"]["value"]?.ToString(),
                                gender: parsedData["results"][i]["gender"]?.ToString(),
                                title: parsedData["results"][i]["name"]["title"]?.ToString(),
                                fullName: $"{parsedData["results"][i]["name"]["first"]?.ToString()} {parsedData["results"][i]["name"]["last"]?.ToString()}",
                                email: parsedData["results"][i]["email"]?.ToString(),
                                dateOfBirthday: dateOfBirthday,
                                age: age,
                                registeredDate: registeredDate,
                                ageRegistration: ageRegistration,
                                phone: parsedData["results"][i]["phone"]?.ToString(),
                                cell: parsedData["results"][i]["cell"]?.ToString(),
                                nat: parsedData["results"][i]["nat"]?.ToString(),
                                login: login,
                                picture: picture,
                                location: location
                            );

                            users.Add(user);
                        }

                        return users;
                    } else
                    {
                        throw new Exception("Erro ao buscar usuário.");
                    }
                } catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}