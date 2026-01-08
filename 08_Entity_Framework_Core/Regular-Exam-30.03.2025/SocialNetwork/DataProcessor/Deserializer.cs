using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.Data.XmlHelper;
using SocialNetwork.DataProcessor.ImportDTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            ICollection<Message> validMessages = new List<Message>();

            ImportMessageDto[] importMessageDtos = xmlHelper.Deserialize<ImportMessageDto[]>(xmlString, "Messages");

            if (importMessageDtos != null)
            {
                foreach (var messageDto in importMessageDtos)
                {

                    if (!IsValid(messageDto) || string.IsNullOrWhiteSpace(messageDto.Content)
                        || messageDto.Content.Length < 1 || messageDto.Content.Length > 200)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(messageDto.SentAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime sentAt))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!Enum.TryParse(messageDto.Status, out Status status))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    bool conversationExists = dbContext.Conversations.Any(c => c.Id == messageDto.ConversationId);
                    bool senderExists = dbContext.Users.Any(u => u.Id == messageDto.SenderId);

                    if (!conversationExists || !senderExists)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDuplicate = validMessages.Any(m =>
                        m.Content == messageDto.Content &&
                        m.SentAt == sentAt &&
                        m.MessageStatus == status &&
                        m.SenderId == messageDto.SenderId &&
                        m.ConversationId == messageDto.ConversationId);

                    if (isDuplicate)
                    {
                        sb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    var message = new Message
                    {
                        Content = messageDto.Content,
                        SentAt = sentAt,
                        MessageStatus = status,
                        ConversationId = messageDto.ConversationId,
                        SenderId = messageDto.SenderId
                    };

                    validMessages.Add(message);
                    sb.AppendLine(string.Format(SuccessfullyImportedMessageEntity, messageDto.SentAt, messageDto.Status));
                }

                if (validMessages.Any())
                {
                    dbContext.Messages.AddRange(validMessages);
                    dbContext.SaveChanges();
                }

            }

            return sb.ToString().TrimEnd();
        }




        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {

            StringBuilder sb = new StringBuilder();
            ICollection<Post> postsToImport = new List<Post>();

            ImportPostDto[] importPostDtos = JsonConvert.DeserializeObject<ImportPostDto[]>(jsonString);

            if (importPostDtos != null)
            {
                foreach (ImportPostDto postDto in importPostDtos)
                {
                    if (!IsValid(postDto) || string.IsNullOrWhiteSpace(postDto.Content)
                        || postDto.Content.Length < 5 || postDto.Content.Length > 300)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(postDto.CreatedAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdAt))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var creator = dbContext.Users.Find(postDto.CreatorId);
                    if (creator == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                  
                    bool isDuplicate = postsToImport.Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAt &&
                        p.CreatorId == postDto.CreatorId);

                    if (isDuplicate)
                    {
                        sb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    var post = new Post
                    {
                        Content = postDto.Content,
                        CreatedAt = createdAt,
                        CreatorId = postDto.CreatorId
                    };

                    postsToImport.Add(post);
                    sb.AppendLine(string.Format(SuccessfullyImportedPostEntity, creator.Username, postDto.CreatedAt));
                }

                if (postsToImport.Any())
                {
                    dbContext.Posts.AddRange(postsToImport);
                    dbContext.SaveChanges();
                }

            }
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
