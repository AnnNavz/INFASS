namespace INFASS.Services
{
	public interface IModelOutputLogger
	{
		string FormatModel(object model, string header);
		void WriteToOutput(object model, string header);
		void WriteModelsToOutput(object[] models, string[] headers);
	}
}
