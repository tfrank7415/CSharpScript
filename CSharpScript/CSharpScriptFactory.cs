using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpScript
{
    public class CSharpScriptFactory : ICSharpScriptFactory
    {
        readonly IJSRuntime _jsRuntime;
        readonly IServiceProvider _serviceProvider;
        readonly IDictionary<string, ScriptManager> _managers = new Dictionary<string, ScriptManager>();
        public CSharpScriptFactory(IJSRuntime jsRuntime, IServiceProvider serviceProvider)
        {
            _jsRuntime = jsRuntime;
            _serviceProvider = serviceProvider;
        }

        public async Task<ScriptManager?> GetScriptManager(string scopeName)
        {
            if (!_managers.Any())
            {
                await BuildFromServices();
            }
            if (_managers.ContainsKey(scopeName))
            {
                return _managers[scopeName];
            }
            return null;
        }

        Task BuildFromServices()
        {
            var scriptManager = _serviceProvider.GetServices<ScriptScopes>().First();

            if (scriptManager != null && scriptManager.ScriptScopesNames != null)
            {
                foreach (string scopeName in scriptManager.ScriptScopesNames)
                {
                    Console.WriteLine($"{scopeName}");
                    var scripManager = new ScriptManager(scopeName, _jsRuntime);
                    _managers.Add(scopeName, scripManager);
                }
            }

            return Task.CompletedTask;
        }
    }
}
