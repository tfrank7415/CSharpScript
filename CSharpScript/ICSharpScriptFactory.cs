using System.Threading.Tasks;

namespace CSharpScript
{
    public interface ICSharpScriptFactory
    {
        Task<ScriptManager?> GetScriptManager(string scopeName);
    }
}
