using System.Runtime.Serialization;

namespace Sat.Recruitment.Api.Contract.Request
{
    [DataContract]
    public class UserRequest
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string UserType { get; set; }

        [DataMember]
        public string Money { get; set; }
    }
}
