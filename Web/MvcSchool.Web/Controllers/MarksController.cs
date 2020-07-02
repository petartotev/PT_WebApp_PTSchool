using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Services;
using MvcSchool.Services.Models.Mark;
using MvcSchool.Web.Models.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class MarksController : Controller
    {
        private readonly IMarkService markService;

        public MarksController(IMarkService markService)
        {
            this.markService = markService;
        }


        public IActionResult AllMarks(int id, int page = 1)
        {
            var marksAll = this.markService.GetAllMarksProfilesFullByStudentId(id, page);
            var pageSizeCount = this.markService.GetPageCountSizing();
            var totalCount = this.markService.GetTotalMarksByStudentId(id);
            var isAllMarksSigned = this.markService.IsAllMarksSignedByParent(id);

            var model = new AllMarkProfilesFullViewModel
            {
                MarkProfilesFull = marksAll,
                PageSize = pageSizeCount,
                CurrentPage = page,
                TotalCount = totalCount,
                IsAllMarksSignedByParent = isAllMarksSigned,
            };

            return this.View(model);
        }

        public IActionResult AddMark(int id)
        {
            var model = new MarkProfileFullToAddViewModel
            {
                StudentId = id
            };
            return this.View(model);
        }

        [HttpPost]
        [RequestSizeLimit(50 * 1024 * 1024)] //PT: By default is 30MB
        public IActionResult AddMark(MarkProfileFullToAddViewModel markProfileToAdd, int id)
        {
            var markProfileServiceModelToAdd = new MarkProfileFullServiceModel
            {
                StudentId = id,
                SubjectId = (int)markProfileToAdd.Subject,
                Title = markProfileToAdd.Title,
                Comment = markProfileToAdd.Comment,
                DateReceived = markProfileToAdd.DateReceived,
                TeacherId = 25,
                ValueMark = (int)markProfileToAdd.ValueMark,
            };

            this.markService.AddNewMarkProfileToStudentByStudentId(markProfileServiceModelToAdd);

            //PT: TEMP-DATA
            //PT: It is a KEY-VALUE pair that can be passes until it is used. Then it is automatically deleted!
            this.TempData["InfoMessage"] = "This message is coming from MarksController -> [Http Post] AddMark() Action -> MarkApproved() Action -> this.View(). It confirms that YOUR MARK WAS SUBMITTED SUCCESSFULLY!";

            return this.RedirectToAction("MarkApproved", new { id = id });
        }

        public IActionResult MarkApproved(int id)
        {
            int idToGiveToView = id;
            return this.View(idToGiveToView);
        }

        [Route("/Marks/SignMark/{studentId}/{markId}")]
        public IActionResult SignMark(int studentId, int markId)
        {
            this.markService.SignMark(studentId, markId);

            //return this.RedirectToAction("AllMarks", new { id = studentId });

            return this.Json(new { message = "This mark was signed successfully!" });
        }
    }
}
