using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sat.Recruitment.Api.Contract.Response
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public List<string> Errors { get; set; }

        [DataMember]
        public UserResponse User { get; set; }
    }
}
