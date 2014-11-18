namespace Quoteversation.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Quoteversation.Data;
    using Quoteversation.Models;
    using Quoteversation.Web.Areas.Administration.Controllers;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using Model = Quoteversation.Models.PostContentQuote;
    using ViewModel = Quoteversation.Web.Areas.Administration.ViewModels.PostQuoteViewModel;

    public class QuotesAdminController : KendoGridAdministrationController
    {
         public QuotesAdminController(IQuoteversationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .PostContentQuotes
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(int id)
        {
            return this.Data.PostContentQuotes.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var quote = this.Data.PostContentQuotes.GetById(model.Id);

                this.Data.PostContentQuotes.Delete(quote);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}