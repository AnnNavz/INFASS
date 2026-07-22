using System.Diagnostics;
using System.Reflection;

namespace INFASS.Services
{
	public class ModelOutputLogger : IModelOutputLogger
	{
		private readonly ILogger<ModelOutputLogger> _logger;

		public ModelOutputLogger(ILogger<ModelOutputLogger> logger)
		{
			_logger = logger;
		}

		public string FormatModel(object model, string header)
		{
			if (model == null)
			{
				return "No model data received.";
			}

			var outputLines = new List<string>
			{
				BuildSeparator(header)
			};

			PropertyInfo[] properties = model.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
			{
				object? value = property.GetValue(model);
				outputLines.Add($"{property.Name}:  {value ?? "(null)"}");
			}

			outputLines.Add(new string('=', 48));

			return string.Join(Environment.NewLine, outputLines);
		}

		public void WriteToOutput(object model, string header)
		{
			string output = FormatModel(model, header);

			Debug.WriteLine(output);
			_logger.LogInformation("{ModelOutput}", output);
		}

		public void WriteModelsToOutput(object[] models, string[] headers)
		{
			for (int i = 0; i < models.Length; i++)
			{
				string header = i < headers.Length
					? headers[i]
					: models[i]?.GetType().Name ?? "MODEL";

				WriteToOutput(models[i], header);
			}
		}

		private static string BuildSeparator(string header) =>
			$"================ {header} ================";
	}
}
