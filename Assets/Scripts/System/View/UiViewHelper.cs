using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UiViewHelper {

	public static Vector3 ScreenPosition(this PointerEventData pointerEventData)
	{
		return Camera.main.ScreenToWorldPoint(pointerEventData.position);
	}

    public static bool IsLeftClick(this PointerEventData pointerEventData)
    {
        return pointerEventData.button == PointerEventData.InputButton.Left;
    }

    public static Vector2 GetMousePositionWorldPoint()
    {
        Vector2 mousePosition = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public static float GetDeltaTimedSpeed(float baseSpeed)
    {
        var deltaTime = Time.deltaTime;
        return baseSpeed * deltaTime;
    }
}
