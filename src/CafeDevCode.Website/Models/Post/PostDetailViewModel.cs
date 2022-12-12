global using CafeDevCode.Database.Entities;
using CafeDevCode.Logic.Commands.Request;
using System.ComponentModel.DataAnnotations;

namespace CafeDevCode.Website.Models
{
    public class PostDetailViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int? PostTypeId { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UrlMeta { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime? PostDate { get; set; }
        public int? AuthorId { get; set; }
        public string Remark { get; set; } = string.Empty;

        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Post> Relates { get; set; } = new List<Post>();
        public Author? Author { get; set; }

        public CreatePost ToCreateCommand()
        {
            return new CreatePost()
            {
                Id = this.Id,
                PostTypeId = this.PostTypeId,
                Title = this.Title,
                Summary = this.Summary,
                Description = this.Description,
                UrlMeta = this.UrlMeta,
                Keywords = this.Keywords,
                Image = this.Image,
                Content = this.Content,
                PostDate = this.PostDate,
                AuthorId = this.AuthorId,
                Remark = this.Remark,
                Categories = this.Categories,
                Tags = this.Tags,
                Relates = this.Relates,
            };
        }
        public UpdatePost ToUpdateCommand()
        {
            return new UpdatePost()
            {
                Id = this.Id,
                PostTypeId = this.PostTypeId,
                Title = this.Title,
                Summary = this.Summary,
                Description = this.Description,
                UrlMeta = this.UrlMeta,
                Keywords = this.Keywords,
                Image = this.Image,
                Content = this.Content,
                PostDate = this.PostDate,
                AuthorId = this.AuthorId,
                Remark = this.Remark,
                Categories = this.Categories,
                Tags = this.Tags,
                Relates = this.Relates,
            };
        }
    }
}
