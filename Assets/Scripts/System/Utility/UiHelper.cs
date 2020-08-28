using System.Collections.Generic;
using System.Linq;

public static class UiHelper {

	public static string RenderText(this Card card)
	{
		var unrenderedText = card.Text;

		var attributesByName = card.Actions
			.OfType<IAttribute>()
			.Select(action => action.Attribute)
			.ToDictionary(
				attribute => attribute.Name, 
				attribute => attribute.GetValue().ToString());

		return unrenderedText.ReplaceKeywords(attributesByName);
	}

	private static string ReplaceKeywords(this string defaultText, Dictionary<string, string> keywordsByValue)
	{
		return keywordsByValue.Aggregate(
			defaultText, 
			(currentText, valueToMap) 
				=> currentText.Replace("{" + valueToMap.Key + "}", valueToMap.Value)
		);
	}
}
