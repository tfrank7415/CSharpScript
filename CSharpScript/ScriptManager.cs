using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace CSharpScript
{
    public class ScriptManager
    {
        readonly IJSRuntime _jsRuntime;
        readonly string _scopeName;

        internal ScriptManager(string scopeName, IJSRuntime jsRuntime)
        {
            _scopeName = scopeName;
            _jsRuntime = jsRuntime;
        }
    }
}
