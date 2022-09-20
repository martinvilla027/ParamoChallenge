using System.Runtime.Serialization;

namespace Sat.Recruitment.Api.Contract.Response
{
    [DataContract]
    public class UserResponse
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
        public decimal Money { get; set; }
    }
}
