using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisDemo.Func
{
    public class RedisHelper
    {
        private static ConnectionMultiplexer Redis { get; set; }
        private static IDatabase Db { get; set; }
        static RedisHelper()
        {
            Redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            Db = Redis.GetDatabase();
        }

        /// <summary>
        /// 增加/修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="value">默认1分钟</param>
        /// <returns></returns>
        public static bool Set(string key, string value, double minute = 1)
        {
            return Db.StringSet(key, value, TimeSpan.FromMinutes(minute));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return Db.StringGet(key);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Delete(string key)
        {
            return Db.KeyDelete(key);
        }
    }
}
