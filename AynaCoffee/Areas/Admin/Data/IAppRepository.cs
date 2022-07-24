using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AynaCoffee.Areas.Admin.Models;

namespace AynaCoffee.Areas.Admin.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity);
        void IziToast(string message, string header, string type = "success");
        bool SaveAll();

        List<Content> GetContents();
        Content GetContentById(int id);

        List<Expert> GetExperts();
        Expert GetExpertById(int id);

        List<Photo> GetPhotosByContentId(int id);
        Photo GetPhotoByContentId(int id);

        List<Gallery> GetGalleries();
        Gallery GetGalleryById(int id);

        List<Slide> GetSlides();
        Slide GetSlideByContentId(int id);

        List<Message> GetMessages();
        Message GetMessageById(int id);

        List<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(string id);
    }
}
