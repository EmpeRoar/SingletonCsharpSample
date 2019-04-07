using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonErrorManager.ErrorManager
{
    public sealed class ErrorSingleton
    {
        public List<string> Errors { get; set; }

        private static volatile ErrorSingleton _instance;
        private static readonly object _syncLock = new object();
        private ErrorSingleton()
        {
            Errors = new List<string>();
        }

        public static ErrorSingleton Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ErrorSingleton();
                    }
                }
                return _instance;
            }
        }


        public async Task<List<string>> GetSomething(string keyword)
        {
            if(keyword != null)
            {
                return Errors.Where(x => x.Contains(keyword))?.ToList();
            }
            else
            {
                return Errors;
            }
            
        }

        public async Task AddSomething(string error)
        {
            Errors.Add(error);
        }
    }
}
