using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Data.XmlHelper;
using SocialNetwork.DataProcessor.ExportDTOs;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var users = dbContext.Users
                .OrderBy(u => u.Username)
                .Select(u => new UserDto()
                {
                    Username = u.Username,
                    Count = dbContext.Friendships.Count(x => x.UserTwoId == u.Id) 
                    + dbContext.Friendships.Count(x => x.UserOneId == u.Id),
                    Posts = u.Posts
                    .OrderBy(p => p.Id)
                    .Select(p => new PostDto()
                    {
                        Content = p.Content,
                        CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                    })
                    .ToArray()
                    
                })
                .ToArray();

            return xmlHelper.Serialize(users, "Users");
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            var conversations = dbContext.Conversations
                .OrderBy(c => c.StartedAt)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    Messages = c.Messages
                        .OrderBy(m => m.SentAt)
                        .Select(m => new
                        {
                            m.Content,
                            SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                            Status = m.MessageStatus,
                            SenderUsername = m.Sender.Username
                        })
                        .ToArray()
                })
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(conversations, Formatting.Indented);
        }
    }
}