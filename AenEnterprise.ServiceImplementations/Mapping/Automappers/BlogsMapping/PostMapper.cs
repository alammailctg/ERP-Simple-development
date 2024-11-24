using AenEnterprise.DomainModel.BlogsDomain;
using AenEnterprise.ServiceImplementations.ViewModel.BlogVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.BlogsMapping
{
    public static class PostMapper
    {
        public static PostView ConvertToPostView(this Post post, IMapper mapper)
        {
            return mapper.Map<Post, PostView>(post);
        }

        public static IEnumerable<PostView> ConvertToPostViews(this IEnumerable<Post> posts, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Post>, IEnumerable<PostView>>(posts);
        }
    }

}
