using IMS.Common;
using IMS.DTO;
using IMS.IService;
using IMS.Web.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IMS.Web.Controllers
{
    public class TaskController : Controller
    {
        private int pageSize = 10;
        private long userId = CookieHelper.GetLoginId();
        public ITaskService taskService { get; set; }
        public IForwardService forwardService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Get(int? within, int pageIndex=1)
        {
            if (within!=null)
            {
                var res = await taskService.GetModelListAsync(userId, 7, pageIndex, pageSize);
                return Json(new AjaxResult { Status = 1, Data = res });
            }
            else
            {
                var res = await taskService.GetModelListAsync(userId, null, pageIndex, pageSize);
                return Json(new AjaxResult { Status = 1, Data = res });
            }
        }

        public async Task<ActionResult> Detail(long id)
        {
            TaskDetailViewModel model = new TaskDetailViewModel();
            model.Task = await taskService.GetModelAsync(id, userId);
            model.ForwardStateName = await forwardService.GetStateNameAsync(userId, id);
            return View(model);
        }

        public async Task<ActionResult> Accept(long id)
        {
            long res = await forwardService.AcceptAsync(id, userId);
            if(res<=0)
            {
                return Json(new AjaxResult { Status = 0, Msg = "任务接受失败" });
            }
            return Json(new AjaxResult { Status = 1, Msg = "任务接受完成" });
        }

        public async Task<ActionResult> GiveUp(long id)
        {
            bool res = await forwardService.DelAsync(id,userId);
            if (!res)
            {
                return Json(new AjaxResult { Status = 0, Msg = "任务放弃失败" });
            }
            return Json(new AjaxResult { Status = 1, Msg = "任务放弃成功" });
        }
    }
}