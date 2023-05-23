using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaNacionChallenge.Models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DefaultValue("")]
        public string Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        public string ProfileImage { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        [StringLength(10)]
        public string WorkPhoneNumber { get; set; }

        [StringLength(10)]
        public string PersonalPhoneNumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
    }
}
