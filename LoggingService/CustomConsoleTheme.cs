using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService
{
    public class CustomConsoleTheme : ConsoleTheme
    {
        private readonly IReadOnlyDictionary<ConsoleThemeStyle, string> _styles;
        public CustomConsoleTheme(IReadOnlyDictionary<ConsoleThemeStyle, string> styles)
        {
            if (styles == null)
            {
                throw new ArgumentNullException(nameof(styles));
            }
            this._styles = styles.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
        public static CustomConsoleTheme VisualStudioMacLight { get; } = CustomConsoleTheme.VisualStudioMacLight;

        public override bool CanBuffer
        {
            get
            {
                return true;
            }
        }

        protected override int ResetCharCount { get; } = "\x0018[0m".Length;
        public override int Set(TextWriter output, ConsoleThemeStyle style)
        {
            string str;
            if(!this._styles.TryGetValue(style, out str))
            {
                return 0;
            }
            output.Write(str);
            return str.Length;
        }
        public override void Reset(TextWriter output)
        {
            output.Write("\x0018[0m");
        }
    }
}
