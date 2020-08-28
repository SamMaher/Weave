using UnityEngine;
using UnityEngine.UI;

public class CardView : EntityView<Card> {
    
    //UI References
    public Text Name;
    public Text Text;
    public float CardMagnifyScale = 1.2f;
    public float MagnificationSpeed = 0.5f;
    private bool IsHeld { get; set; } = false;
    private bool IsHighlighted { get; set; }
    private Vector3 OriginalTransformScale { get; set; }
    private Vector2 GrabDifferenceOffset;
    private SpriteRenderer spriteRenderer;

    public override void Awake()
    {
        GetComponents();

        OriginalTransformScale = transform.localScale;
    }

    private void GetComponents()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public override void OnEveryFrame()
    {
        UpdateView(); // TODO : Only update the view after changes are made to the cards data

        var playerControlStateManager = MatchController.Controller.PlayerControlStateManager;
        var isPlayerActing = playerControlStateManager.IsPlayerActing;

        if (!isPlayerActing)
        {
            DoHighlighting();
        }

        DoHolding();

        spriteRenderer.sortingOrder = UiViewLayerHelper.GetOrderInUi(UiViewLayer, UiViewLayerOrder);
    }

    private void DoHighlighting()
    {
        var animationSpeed = UiViewHelper.GetDeltaTimedSpeed(MagnificationSpeed);

        if (IsHighlighted)
        {
            var targetTransformScale = OriginalTransformScale * CardMagnifyScale;
            transform.localScale = Vector3.Lerp(transform.localScale, targetTransformScale, animationSpeed);
            UiViewLayerOrder = UiViewLayerOrder.Forward;
        }
        else if (transform.localScale != OriginalTransformScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, OriginalTransformScale, animationSpeed);
            UiViewLayerOrder = UiViewLayerOrder.Middle;
        }
    }

    private void DoHolding()
    {
        if (IsHeld)
        {
            var mouseWorldPoint = UiViewHelper.GetMousePositionWorldPoint();
            var targetPosition = mouseWorldPoint + GrabDifferenceOffset;
            SetTargetPosition(targetPosition);
        }
    }

    public override void UpdateView()
    {
        Name.text = EntityReference.Name;
        Text.text = EntityReference.RenderText();
    }

    public override void PointerEnter()
    {
        IsHighlighted = true;
    }

    public override void PointerExit()
    {
        IsHighlighted = false;
    }

    public override void PointerBeginDrag()
    {
        BeginHoldingCard();
    }

    public override void PointerEndDrag()
    {
        StopHoldingCard();
    }

    public override void PointerClick()
    {
        if (IsHeld)
        {
            StopHoldingCard();
        }
        else
        {
            BeginHoldingCard();
        }
    }

    public void BeginHoldingCard()
    {
        var playerControlStateManager = MatchController.Controller.PlayerControlStateManager;
        var isPlayerIdle = playerControlStateManager.IsPlayerIdle;
        if (!isPlayerIdle) return;

        playerControlStateManager.SetPlayerActing();

        IsHeld = true;
        var mouseWorldPoint = UiViewHelper.GetMousePositionWorldPoint();
        var twoDimPosition = new Vector2(transform.position.x, transform.position.y);
        GrabDifferenceOffset = twoDimPosition - mouseWorldPoint;
    }

    public void StopHoldingCard()
    {
        if (!IsHeld) return;

        IsHeld = false;
        GrabDifferenceOffset = Vector2.zero;

        var playerControlStateManager = MatchController.Controller.PlayerControlStateManager;
        playerControlStateManager.SetPlayerIdle();
    }
}

