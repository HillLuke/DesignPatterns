using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural;

/// <summary>
/// Lets you provide a substitute or placeholder for another object. A proxy controls access to the
/// original object, allowing you to perform something before/after the request gets sent to the
/// original object.
/// </summary>
public class Proxy : IDesignPattern
{
    public void RunExample()
    {
        var dataApi = new DataApi();
        var dataCache = new DataApiCache(dataApi);

        dataCache.GetData();
        dataCache.GetData();
    }

    public interface IDataApi
    {
        public string GetData();
    }

    public class DataApi : IDataApi
    {
        public string GetData()
        {
            return "Hello World";
        }
    }

    public class DataApiCache : IDataApi
    {
        private IDataApi _dataApi;
        private string _cache;

        public DataApiCache(IDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        public string GetData()
        {
            if (_cache == null)
            {
                Console.WriteLine("Get from api");
                _cache = _dataApi.GetData();
            }
            else
            {
                Console.WriteLine("Get from cache");
            }

            return _cache;
        }
    }

}