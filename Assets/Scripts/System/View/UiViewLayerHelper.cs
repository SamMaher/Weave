using System;

public static class UiViewLayerHelper
{
    public static int GetUiViewLayerZPosition(this UiViewLayer uiViewLayer)
    {
        switch (uiViewLayer)
        {
            case UiViewLayer.Glass: return -9;
            case UiViewLayer.Foreground: return -5;
            case UiViewLayer.Midground: return 0;
            case UiViewLayer.Background: return 5;
            default: throw new Exception("UiViewLayer not supported");
        }
    }

    public static int GetOrderInUi(UiViewLayer uiViewLayer, UiViewLayerOrder orderInUi)
    {
        return GetUiViewLayerZPosition(uiViewLayer) + (int)orderInUi;
    }
}