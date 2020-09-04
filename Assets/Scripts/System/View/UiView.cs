using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiView : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler {

    private float MovementSpeed { get; set; }
	private Vector2 TargetPosition { get; set; }
    private float RotationSpeed { get; set; }
    private float? TargetRotation { get; set; }
    private float ScalingSpeed { get; set; }
    private float? TargetScaling { get; set; }
    private Vector3 OriginalTransformScale { get; set; }
    public UiViewLayer UiViewLayer = UiViewLayer.Midground;
    public UiViewLayerOrder UiViewLayerOrder = UiViewLayerOrder.Middle;
    private SpriteRenderer SpriteRenderer;

    // Magic
    private const int InstantSpeedValue = 0;

	public void Awake()
    {
        GetComponents();
        MovementSpeed = InstantSpeedValue;
        OriginalTransformScale = transform.localScale;
        OnAwake();
    }

    public virtual void OnAwake() {}

    private void GetComponents()
    {
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
	{
        OnEveryFrame();
        UpdatePosition();
        UpdateRotation();
        UpdateScale();
    }

    public virtual void OnEveryFrame() {}

    public virtual void UpdateView() {}

    private void UpdatePosition()
    {
        if (TargetPosition == null) return;

        float zLock = this.UiViewLayer.GetUiViewLayerZPosition();
        var zLockedTargetPosition = new Vector3(TargetPosition.x, TargetPosition.y, zLock);

        if (MovementSpeed == InstantSpeedValue)
        {
            transform.position = zLockedTargetPosition;
        }
        else
        {
            var deltaTimedMoveSpeed = UiViewHelper.GetDeltaTimedSpeed(MovementSpeed);
            transform.position = Vector3.MoveTowards(transform.position, zLockedTargetPosition, deltaTimedMoveSpeed);
        }
    }

    private void UpdateRotation()
    {
        if (TargetRotation == null) return;

        Quaternion targetRotation = Quaternion.Euler(0, 0, TargetRotation.Value);

        if (RotationSpeed == InstantSpeedValue)
        {
            transform.rotation = targetRotation;
        }
        else
        {
            var deltaTimedRotationSpeed = UiViewHelper.GetDeltaTimedSpeed(RotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, deltaTimedRotationSpeed);
        }
    }

    private void UpdateScale()
    {
        if (TargetScaling == null) return;

        var targetTransformScale = OriginalTransformScale * TargetScaling.Value;

        if (ScalingSpeed == InstantSpeedValue)
        {
            transform.localScale = targetTransformScale;
        }
        else
        {
            var animationSpeed = UiViewHelper.GetDeltaTimedSpeed(ScalingSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, targetTransformScale, ScalingSpeed);
        }
    }

    /// <summary>
    /// Sets the target position to move towards, as well as the speed that a UiView will interpolate towards its target position.<para />
    /// Speed value should be a value between 1-20~.
    /// </summary>
    /// <param name="targetPosition">The position in world space that you would like to move the card to/towards.</param>
    /// <param name="movementSpeed">Speed value should be between 1-20. Omit this value for instant movement.</param>
    public void SetTargetPosition(Vector2 targetPosition, float movementSpeed = InstantSpeedValue)
    {
        this.TargetPosition = targetPosition;

        const float movementSpeedMultiplier = 10;
        var newMovementSpeed = (movementSpeed == InstantSpeedValue)
            ? InstantSpeedValue
            : movementSpeed * movementSpeedMultiplier;

        this.MovementSpeed = newMovementSpeed;
    }

    /// <summary>
    /// Sets the target rotation to rotate towards, as well as the speed that a UiView will interpolate towards its target rotation.<para />
    /// Speed value should be ...
    /// </summary>
    /// <param name="targetRotation">The new Z rotation you would like to rotate towards.</param>
    /// <param name="rotationSpeed">Speed value should be between 1-20. Omit this value for instant rotation.</param>
    public void SetTargetRotation(float targetRotation, float rotationSpeed = InstantSpeedValue)
    {
        this.TargetRotation = targetRotation;

        const float rotationSpeedMultiplier = 10;
        var newRotationSpeed = (rotationSpeed == InstantSpeedValue)
            ? InstantSpeedValue
            : rotationSpeed * rotationSpeedMultiplier;

        this.RotationSpeed = newRotationSpeed;
    }

    /// <summary>
    /// Sets the target scaling to scale towards, as well as the speed that a UiView will interpolate towards its target Scale.<para />
    /// Speed value should be...
    /// </summary>
    /// <param name="targetScale"></param>
    /// <param name="scalingSpeed"></param>
    public void SetTargetScale(float targetScale, float scalingSpeed = InstantSpeedValue)
    {
        this.TargetScaling = targetScale;

        const float scalingSpeedMultiplier = 0.1f;
        var newScalingSpeed = (scalingSpeed == InstantSpeedValue)
            ? InstantSpeedValue
            : scalingSpeed * scalingSpeedMultiplier;

        this.ScalingSpeed = newScalingSpeed;
    }

    public void ResetScale()
    {
        const int originalScalingFactor = 1;
        this.TargetScaling = originalScalingFactor;
    }

    public void SetOrderLayer(UiViewLayerOrder uiViewLayerOrder)
    {
        SpriteRenderer.sortingOrder = UiViewLayerHelper.GetOrderInUi(UiViewLayer, uiViewLayerOrder);
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
        if (!eventData.IsLeftClick()) return;
        PointerUp();
    }

    public virtual void PointerUp() { }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!eventData.IsLeftClick()) return;
        PointerDown();
    }

    public virtual void PointerDown() { }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!eventData.IsLeftClick()) return;
        PointerClick();
    }

    public virtual void PointerClick() { }
}
