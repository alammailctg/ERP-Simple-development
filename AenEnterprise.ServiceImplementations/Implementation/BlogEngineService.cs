using AenEnterprise.DataAccess.RepositoryInterface.Blogs;
using AenEnterprise.DomainModel.BlogsDomain;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.BlogsMapping;
using AenEnterprise.ServiceImplementations.Messaging.BloogMessaging;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public class BlogEngineService:IBlogEngineService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogCategoryRepository _categoryRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
         
        public BlogEngineService(IPostRepository postRepository, IBlogCategoryRepository categoryRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostResponse> CreatePoset(CreatePostRequest request)
        {
            CreatePostResponse response = new CreatePostResponse();
            Post post = new Post()
            {
                Title = request.Title,
                Content = request.Content,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                CategoryId = request.CategoryId,
            };
           

            response.Post = post.ConvertToPostView(_mapper);
           
            await _postRepository.AddAsync(post);
            return response;
        }
    }

    
}
