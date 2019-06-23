using API.Wiki.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Webi.Core.SDK.BaseClass;

namespace API.Wiki.Controllers
{
    [Area("wiki")]
    public class apisController : MvcControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IHostingEnvironment _env;
        public apisController(IHostingEnvironment env, IMemoryCache cache)
        {
            _env = env;
            _cache = cache;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="timeout">过期时间：分钟</param>
        /// <param name="getData">返回数据的方法</param>
        /// <returns></returns>
        public T TryGetCache<T>(string key, int timeout, Func<T> getData) where T : class
        {
            T cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = getData() as T;
                _cache.Set(key, cacheEntry, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(timeout)));
            }
            return _cache.Get<T>(key);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value"></param>
        /// <param name="timeout">过期时间：分钟</param>
        /// <returns></returns>
        public T TrySetCache<T>(string key, T value, int timeout) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _cache.Set<T>(key, value, new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(timeout)));
            return value;
        }

        // GET: wiki/controller
        public IActionResult index()
        {
            var model = GetControllers();
            return View(model);
        }

        public IActionResult controller(string id)
        {
            var model = GetControllers();
            var controller = model.FirstOrDefault(w => w.Name == id);
            if (controller != null)
            {
                return View(controller);
            }
            return RedirectToAction("index");
        }

        public IActionResult action(string id)
        {
            var actions = id.Split('-');
            var model = GetControllers();
            var controller = model.FirstOrDefault(w => w.Name == actions[0]);
            if (controller != null)
            {
                var action = controller.Actions.FirstOrDefault(w => w.Name == actions[1]);
                if (action != null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var instance = assembly.CreateInstance(action.ParameterTypes[0].Type.FullName);
                    ViewBag.ParameterJson = ApplicationContext.Json.ObjectToJson(instance);
                    return View(action);
                }
            }
            return RedirectToAction("index");
        }

        /// <summary>
        /// 读取配置文件内容
        /// </summary>
        /// <param name="Path">文件地址</param>
        private WikiConfigJsonEntity ReadJsonConfig()
        {
            var config_path = $"{_env.ContentRootPath}/Areas/wiki/Config/wiki_config.json";
            var key = "JSON_CONFIG";
            var cache = _cache.Get(key);
            if (cache == null)
            {
                var sr = new StreamReader(config_path, Encoding.UTF8);
                var json = sr.ReadToEnd();
                sr.Close();
                var config = JsonConvert.DeserializeObject<WikiConfigJsonEntity>(json);
                _cache.Set(key, config, new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(30)));
                cache = config;
            }
            return cache as WikiConfigJsonEntity;
        }

        /// <summary>
        /// 获取控制器集合
        /// </summary>
        /// <returns></returns>
        private List<WikiControllerView> GetControllers()
        {
            var key = "WIKI_CONTROLLER";
            var cache = _cache.Get(key);
            if (cache == null)
            {
                var config = ReadJsonConfig();
                //获取当前程序集
                var asm = Assembly.GetExecutingAssembly();
                var list = new List<WikiControllerView>();
                foreach (var controller in asm.GetTypes())
                {
                    //包含自定义属性
                    var controllerAttribute = controller.GetCustomAttribute(typeof(WikiControllerAttribute));
                    if (controllerAttribute != null)
                    {
                        //控制器
                        var ns = controller.FullName;
                        //替换命名空间
                        ns = ns.Replace($"{controller.Namespace}.", "");
                        //配置替换
                        foreach (var item in config.settings.@namespace)
                        {
                            ns = ns.Replace(item, "");
                        }
                        ns = ns.Replace("Controller", "");
                        //控制器属性
                        var controllerItem = new WikiControllerView
                        {
                            Namespace = "/api/" + ns,
                            Name = controller.Name.Replace("Controller", ""),
                            Annotation = ((WikiControllerAttribute)controllerAttribute).Name,
                            ClassType = controller
                        };
                        list.Add(controllerItem);
                    }
                }
                _cache.Set(key, list, new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(30)));
                cache = list;
            }
            return cache as List<WikiControllerView>;
        }
    }
}