using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisDemo.Func;


namespace RedisDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// https://localhost:44324/api/values/get?id=1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            string result = RedisHelper.Get(id.ToString());

            if (string.IsNullOrEmpty(result))
            {
                return "没有缓存数据";
            }
            return string.Format("id:{0}的缓存是：{1}", id, result);
        }

        /// <summary>
        /// https://localhost:44324/api/values/set?id=1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Set(int id)
        {
            if (id == 0) { return "没有参数"; }

            string key = id.ToString();
            string value = string.Format("id:{0}:{1}", id, id.GetValues());

            bool bol = RedisHelper.Set(key, value);
            return "设置缓存" + (bol ? "成功。" : "失败。");
        }

        [HttpGet]
        public void Delete(int id)
        {
        }

    }
}

namespace System
{
    public static class a
    {
        /// <summary>
        /// 获取当前数据的值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string GetValues(this int v)
        {
            string value = "";
            for (int i = 0; i < 10; i++)
            {
                value = value + v + "-";
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:hh");
            return value.TrimEnd('-') + " " + time;
        }

    }
}
