using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;
using WebAPi.ViewModel;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController<StatusRepository, Status>
    {
        private MyContext myContext;
        private StatusRepository statusRepository;
        public StatusController(StatusRepository statusRepository, MyContext myContext) : base(statusRepository)
        {
            this.myContext = myContext;
            this.statusRepository = statusRepository;
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut("Approve")]
        public ActionResult ApproveRequest(RequestItem requestItem)
        {
            try
            {
                var data = statusRepository.Approve(requestItem);
                if(data > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Approved",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Not Approve"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("Reject")]
        public ActionResult RejectRequest(RequestItem requestItem)
        {
            try
            {
                var data = statusRepository.Reject(requestItem);
                if (data > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Approved",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Not Approve"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("TakeAnItem")]
        public ActionResult TakeAnItem(RequestItem requestItem)
        {
            try
            {
                var data = statusRepository.TakeAnItem(requestItem);
                if (data > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Approved",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Not Approve"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("Return")]
        public ActionResult ReturnItem(RequestItem requestItem)
        {
            try
            {
                var data = statusRepository.Return(requestItem);
                if (data > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Approved",
                        Data = data
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Data Not Approve"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("ReqReject")]
        public ActionResult ReqReject()
        {
            var reqReject = from U in myContext.Users
                            join R in myContext.RequestItems on U.Id equals R.UserId
                            join S in myContext.Status on R.StatusId equals S.Id
                            where R.StatusId == 1
                            select new
                            {
                                Name = U.FullName,
                                Status = S.Name
                            };
            return Ok(reqReject);
        }

        [HttpGet("ReqReturn")]
        public ActionResult ReqReturn()
        {
            var reqReturn = from U in myContext.Users
                            join R in myContext.RequestItems on U.Id equals R.UserId
                            join S in myContext.Status on R.StatusId equals S.Id
                            where R.StatusId == 2
                            select new
                            {
                                Name = U.FullName,
                                Status = S.Name
                            };
            return Ok(reqReturn);
        }

        [HttpGet("ReqWaiting")]
        public ActionResult ReqWaiting()
        {
            var reqWaiting = from U in myContext.Users
                             join R in myContext.RequestItems on U.Id equals R.UserId
                             join S in myContext.Status on R.StatusId equals S.Id
                             where R.StatusId == 3
                             select new
                             {
                                 Name = U.FullName,
                                 Status = S.Name
                             };
            return Ok(reqWaiting);
        }

        [HttpGet("ReqApprove")]
        public ActionResult ReqApprove()
        {
            var reqApprove = from U in myContext.Users
                             join R in myContext.RequestItems on U.Id equals R.UserId
                             join S in myContext.Status on R.StatusId equals S.Id
                             where R.StatusId == 4
                             select new
                             {
                                 Name = U.FullName,
                                 Status = S.Name
                             };
            return Ok(reqApprove);
        }

        [HttpGet("ReqTakenItem")]
        public ActionResult ReqTakenItem()
        {
            var reqApprove = from U in myContext.Users
                             join R in myContext.RequestItems on U.Id equals R.UserId
                             join S in myContext.Status on R.StatusId equals S.Id
                             where R.StatusId == 5
                             select new
                             {
                                 Name = U.FullName,
                                 Status = S.Name
                             };
            return Ok(reqApprove);
        }
    }
}
