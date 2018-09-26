using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.NLog
{
	/// <summary>
	/// Provides a logger based on NLog.
	/// </summary>
	public class NLogLoggerProvider : ILoggerProvider
	{
		/// <summary>
		/// Returns a logger based on <see cref="global::NLog.LogManager.GetLogger(string)"/>.
		/// </summary>
		/// <param name="loggerName">The name of the logger.</param>
		/// <returns>Returns a <see cref="NLogLogger"/>.</returns>
		public ILogger CreateLogger(string loggerName)
		{
			var logger = global::NLog.LogManager.GetLogger(loggerName);

			return new NLogLogger(logger);
		}
	}
}
