using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.RealNameSystem;
using JNKJ.Dto.Results;
using JNKJ.Services.RealNameSystem;
using System.Net.Http;
using System.Web.Http;

using System.Linq;
using JNKJ.Dto.Enums;
using System;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class UserController : BaseController
    {
        #region Fields

        private readonly IUser _userService;

        #endregion

        #region Ctor

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        #endregion


        [HttpPost]
        [ActionName("user_login")]
        public HttpResponseMessage UserLogin(UserRequest userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.userName))
            {
                return toJson(null, OperatingState.CheckDataFail, "用户名不能为空");
            }
            if (string.IsNullOrWhiteSpace(userRequest.passWord))
            {
                return toJson(null, OperatingState.CheckDataFail, "登录密码不能为空");
            }
            var user = _userService.GetUserByName(userRequest.userName);
            if (user == null)
            {
                return toJson(null, OperatingState.CheckDataFail, "该用户不存在");
            }
            return user.Password != userRequest.passWord ? toJson(null, OperatingState.CheckDataFail, "登录密码不匹配") : toJson(user, OperatingState.Success, "登录成功");
        }
    }
}
