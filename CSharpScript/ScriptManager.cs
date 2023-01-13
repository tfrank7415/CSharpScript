using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public async Task Hide(string selector)
        {
            // TODO: FIGURE OUT HOW TO ALLOW THEM TO HIDE BASED ON TAG TYPE
            if (selector != null)
            {
                string selectorType = selector.Substring(0,1);
                string selectorValue = selector.Substring(1);
                switch (selectorType)
                {
                    case "#":
                        await _jsRuntime.InvokeVoidAsync("cSharpScript.hideById", selectorValue);
                        break;
                    case ".":
                        await _jsRuntime.InvokeVoidAsync("cSharpScript.hideByClass", selectorValue);
                        break;
                    default:
                        // TODO: Create methods that returns bool if selector value is a tag type
                        selectorValue = selector;
                        if (selectorIsATagName(selector))
                        {
                            await _jsRuntime.InvokeVoidAsync("cSharpScript.hideByTagName", selectorValue);
                        }
                        else 
                        {
                            await _jsRuntime.InvokeVoidAsync("cSharpScript.hideByName", selectorValue);
                        }
                        break;
                }
            }
        }

        public async Task Show(string selector)
        {
            // TODO: FIGURE OUT HOW TO ALLOW THEM TO HIDE BASED ON TAG TYPE
            if (selector != null)
            {
                string selectorType = selector.Substring(0, 1);
                string selectorValue = selector.Substring(1);
                switch (selectorType)
                {
                    case "#":
                        await _jsRuntime.InvokeVoidAsync("cSharpScript.showById", selectorValue);
                        break;
                    case ".":
                        await _jsRuntime.InvokeVoidAsync("cSharpScript.showByClass", selectorValue);
                        break;
                    default:
                        // TODO: Create methods that returns bool if selector value is a tag type
                        selectorValue = selector;
                        if (selectorIsATagName(selector))
                        {
                            await _jsRuntime.InvokeVoidAsync("cSharpScript.showByTagName", selectorValue);
                        }
                        else 
                        {
                            await _jsRuntime.InvokeVoidAsync("cSharpScript.showByName", selectorValue);
                        }
                        
                        break;
                }
            }
        }
        private protected bool selectorIsATagName(string selector)
        {
            string[] htmlTags = { "!--...--", "!DOCTYPE", "a", "abbr", "address", "area", "article", "aside", "audio", "b", "base",
                                  "bdi", "bdo", "blockquote", "body", "br", "button", "canvas", "caption", "cite", "code", "col",
                                  "colgroup", "data", "datalist", "dd", "del", "details", "dfn", "dialog", "div", "dl", "dt", "em",
                                  "embed", "fieldset", "figcaption", "figure", "footer", "form", "h1", "h2", "h3", "h4", "h5", "h6",
                                  "head", "header", "hr", "html", "i", "iframe", "img", "input", "ins", "kbd", "label", "legend",
                                  "li", "link", "main", "map", "mark", "meta", "meter", "nav", "noscript", "object", "ol", "optgroup",
                                  "option", "output", "p", "param", "picture", "pre", "progress", "q", "rp", "rt", "ruby", "s", "samp",
                                  "script", "section", "select", "small", "source", "span", "strong", "style", "sub", "summary", "sup",
                                  "svg", "table", "tbody", "td", "template", "textarea", "tfoot", "th", "thead", "time", "title", "tr",
                                  "track", "u", "ul", "var", "video", "wbr" };

            if (htmlTags.Contains(selector)) return true;
            else return false;
        }
    }
}
