using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    /// <summary>
    /// this is the CRUD operations for the database of inventory
    /// </summary>
    public class PostService : IPostManagement
    {
        public Task<Post> CreatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemovePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
