using UnityEngine;
using UnityEngine.EventSystems;

public static class UiViewHelper {

	public static UiView Current { get; set; }

	public static bool IsCurrent(this UiView uiView) => (uiView != null && uiView == Current);

	public static void SetCurrent(this UiView uiView)
	{
		Current = uiView;
	}

	public static void UnsetCurrent(this UiView uiView)
	{
		Current = null;
	}

	public static Vector3 ScreenPosition(this PointerEventData pointerEventData)
	{
		return Camera.main.ScreenToWorldPoint(pointerEventData.position);
	}
}
