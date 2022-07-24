using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace AynaCoffee.Areas.Admin.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

        public AppRepository(DataContext context, ITempDataDictionaryFactory tempDataDictionaryFactory, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            SaveAll();
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
            SaveAll();
        }


        public void IziToast(string message, string header, string type = "success")
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(httpContext);
            tempData["Message"] = message;
            tempData["Header"] = header;
            tempData["Type"] = type;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public List<Content> GetContents()
        {
            var contents = _context.Contents.Include(c => c.Photo).ToList();
            return contents;
        }

        public Content GetContentById(int id)
        {
            var content = _context.Contents.Include(c => c.Photo).FirstOrDefault(c => c.Id == id);
            return content;
        }

        public List<Expert> GetExperts()
        {
            var experts = _context.Experts.Include(e => e.Content).ToList();
            foreach (var expert in experts)
            {
                var photos = GetPhotosByContentId(expert.ContentId);
                expert.Content.Photo = photos.FirstOrDefault();
            }
            return experts;
        }

        public Expert GetExpertById(int id)
        {
            var expert = _context.Experts.Include(e => e.Content).ThenInclude(c => c.Photo)
                .FirstOrDefault(e => e.ContentId == id);
            return expert;
        }

        public List<Photo> GetPhotosByContentId(int id)
        {
            var photos = _context.Photos.Where(p => p.ContentId == id).ToList();
            return photos;
        }

        public Photo GetPhotoByContentId(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.ContentId == id);
            return photo;
        }

        public List<Gallery> GetGalleries()
        {
            var galleries = _context.Galleries.ToList();
            return galleries;
        }

        public Gallery GetGalleryById(int id)
        {
            var gallery = _context.Galleries.FirstOrDefault(g => g.Id == id);
            return gallery;
        }

        public List<Slide> GetSlides()
        {
            var slides = _context.Slides.Include(s => s.Content).ThenInclude(c => c.Photo).ToList();
            return slides;
        }

        public Slide GetSlideByContentId(int id)
        {
            var slide = _context.Slides.Include(s => s.Content).ThenInclude(c => c.Photo).FirstOrDefault(s => s.ContentId == id);
            return slide;
        }

        public List<Message> GetMessages()
        {
            var messages = _context.Messages.ToList();
            return messages;
        }

        public Message GetMessageById(int id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);
            return message;
        }

        public List<ApplicationUser> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public ApplicationUser GetUserById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }
    }
}
