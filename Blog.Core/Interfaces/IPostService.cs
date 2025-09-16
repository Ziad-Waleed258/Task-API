using Blog.Core.DTos;
using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IPostService
    {
        // getAll , GetById, update,add,delete
        // get all
        Task<IEnumerable<Post>> GetAllAsync();
        // get by id
        Task<Post> GetByIdAsync(int id);
        // create
        Task<Post> CreateAsync(PostDTo post); //  change parmeter datatype
        // update
        Task<bool> UpdateAsync(int id, PostDTo post);
        Task<bool> UpdateAsync(PostDTo post);
        // delete
        Task<bool> DeleteAsync(int id);
    }
}
