using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpScript
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCSharpScript(this IServiceCollection services, Action<ScriptScopes> options)
        {
            var scriptScopes = new ScriptScopes();
            options(scriptScopes);

            services.AddTransient<ScriptScopes>((_) => scriptScopes);
            services.TryAddSingleton<ICSharpScriptFactory, CSharpScriptFactory>();

            return services;
        }
    }
}
