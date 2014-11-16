namespace Quoteversation.Web.Controllers
{
    using Quoteversation.Data;
    using Quoteversation.Models;
    using Quoteversation.Web.InputModels.Images;
    using Quoteversation.Web.ViewModels.Images;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;

    public class ImagesController : BaseController
    {
        public ImagesController(IQuoteversationData data)
            : base(data)
        {
        }

        public ActionResult Details(int? id)
        {
            var imageModel = this.Data.PostContentPics.All().Where(i => i.Id == id)
                .Project().To<ImageDetailsViewModel>().FirstOrDefault();

            if (imageModel == null)
            {
                return this.HttpNotFound("No such quote.");
            }

            return View(imageModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var model = new ImageInputModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ImageInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var inputTags = inputModel.Tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<Tag> tags = new List<Tag>();

                var tagsFromDb = this.Data.Tags.All();

                foreach (var inputTagName in inputTags)
                {
                    Tag currentTag = tagsFromDb.FirstOrDefault(t => t.Name == inputTagName);

                    if (currentTag == null)
                    {
                        currentTag = new Tag
                        {
                            Name = inputTagName
                        };
                    }

                    tags.Add(currentTag);
                }

                var newPic = new PostContentPic();
                newPic.Tags = tags;
                newPic.UploaderId = userId;
 
                if (inputModel.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        inputModel.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        newPic.PictureContent = content;
                        newPic.FileExtension = inputModel.UploadedImage.FileName.Split(new[] { '.' }).Last();
                    }
                }

                this.Data.PostContentPics.Add(newPic);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = newPic.Id });
            }

            return this.View(inputModel);
        }

        public ActionResult GetImage(int id)
        {
            var image = this.Data.PostContentPics.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.PictureContent, "image/" + image.FileExtension);
        }
    }
}