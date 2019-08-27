using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

/// <summary>
/// 	Helper methods for UI
/// </summary>
public static class UiHelper {

	public static string RenderText(this Card card)
	{
		var defaultText = card.Text;

		var attributes = card.Actions
			.OfType<IAttribute>()
			.Select(action => action.Attribute)
			.ToDictionary(
				attribute => attribute.Name, 
				attribute => attribute.CalculateValue().ToString());

		return defaultText.ReplaceKeywords(attributes);
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
