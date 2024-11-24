using AenEnterprise.ServiceImplementations.Messaging.BloogMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IBlogEngineService
    {
        Task<CreatePostResponse> CreatePoset(CreatePostRequest request);
    }
}
