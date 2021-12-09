using BlogsLogic.BindingModels;
using BlogsLogic.HelperModels;
using BlogsLogic.Interfaces;
using BlogsLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BlogsLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IBlogStorage blogStorage;

        public ReportLogic(IBlogStorage blogStorage)
        {
            this.blogStorage = blogStorage;
        }

        private List<ReportBlogViewModel> GetBlogList(ReportBindingModel model)
        {
            // 1 первое 
            var blogs = blogStorage.GetFilteredList(new BlogBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });

            // 2 второе
            //var blogs = blogStorage.GetFilteredList(new BlogBindingModel
            //{
            //    DateFrom = model.DateFrom,
            //    DateTo = model.DateTo
            //}).Select(blog => blog.Comments.Select(comment => CM(blog, comment))).SelectMany(blogViewModel => blogViewModel).ToList();
            //return blogs;

            // 3 третье
            //var blogs = blogStorage.GetFilteredList(new BlogBindingModel
            //{
            //    DateFrom = model.DateFrom,
            //    DateTo = model.DateTo
            //}).Select(blog => blog.Comments.Select(comment => CM(blog, comment)).ToList()).Aggregate((a, b) => { a.AddRange(b); return a; });
            //return blogs;


            //  1 первое
            var list = new List<ReportBlogViewModel>();

            foreach (var blog in blogs)
            {
                foreach (var comment in blog.Comments)
                {
                    list.Add(new ReportBlogViewModel
                    {
                        BlogName = blog.BlogName,
                        BlogDateCreate = blog.DateCreate,
                        CommentTitle = comment.Title,
                        CommentAuthor = comment.CommentAuthor,
                        CommentDateCreate = comment.DateCreate
                    });
                }
            }

            return list;
        }

        //private ReportBlogViewModel CM(BlogViewModel blog, CommentViewModel comment)
        //{
        //    return new ReportBlogViewModel
        //    {
        //        BlogName = blog.BlogName,
        //        BlogDateCreate = blog.DateCreate,
        //        CommentTitle = comment.Title,
        //        CommentAuthor = comment.CommentAuthor,
        //        CommentDateCreate = comment.DateCreate
        //    };
        //}


        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список блогов",
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                Blogs = GetBlogList(model)
            });
        }
    }
}
