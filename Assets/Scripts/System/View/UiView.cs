using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiView : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler {

    private float PositionMoveSpeed { get; set; }
	private Vector2 TargetPosition { get; set; }
    public UiViewLayer UiViewLayer = UiViewLayer.Midground;
    public UiViewLayerOrder UiViewLayerOrder = UiViewLayerOrder.Middle;
	
	// Magic
    private const int InstantMoveSpeedValue = 0;

	public virtual void Awake()
    {
        PositionMoveSpeed = InstantMoveSpeedValue;
    }
	
	public void Update()
	{
        OnEveryFrame();
        UpdatePosition();
    }

    public virtual void OnEveryFrame() {}

    public virtual void UpdateView() {}

    private void UpdatePosition()
    {
        if (TargetPosition == null) return;

        float zLock = this.UiViewLayer.GetUiViewLayerZPosition();
        var zLockedTargetPosition = new Vector3(TargetPosition.x, TargetPosition.y, zLock);

        if (PositionMoveSpeed == InstantMoveSpeedValue)
        {
            transform.position = zLockedTargetPosition;
        }
        else
        {
            var deltaTimedMoveSpeed = UiViewHelper.GetDeltaTimedSpeed(PositionMoveSpeed);
            transform.position = Vector3.MoveTowards(transform.localPosition, zLockedTargetPosition, deltaTimedMoveSpeed);
        }
    }

    public void SetTargetPosition(Vector2 targetPosition, float targetSpeed = InstantMoveSpeedValue)
    {
        this.TargetPosition = targetPosition;
        this.PositionMoveSpeed = targetSpeed;
    }

    public void SetUiViewLayer(UiViewLayer uiViewLayer)
    {
        this.UiViewLayer = uiViewLayer;
    }
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		PointerEnter();
	}

	public virtual void PointerEnter() {}

	public void OnPointerExit(PointerEventData eventData)
	{
		PointerExit();
	}
	
	public virtual void PointerExit() {}
	
	public void OnDrag(PointerEventData eventData)
	{
		if (!eventData.IsLeftClick()) return;
		PointerDrag();
	}

	public virtual void PointerDrag() {}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!eventData.IsLeftClick()) return;
		PointerBeginDrag();
	}

	public virtual void PointerBeginDrag() {}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!eventData.IsLeftClick()) return;
		PointerEndDrag();
	}
	
	public virtual void PointerEndDrag() {}

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerUp();
    }

    public virtual void PointerUp() { }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown();
    }

    public virtual void PointerDown() { }

    public void OnPointerClick(PointerEventData eventData)
    {
        PointerClick();
    }

    public virtual void PointerClick() { }
}
