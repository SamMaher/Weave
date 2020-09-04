using UnityEngine;
using UnityEngine.UI;

public class CardView : EntityView<Card> {
    
    // View References
    private HandView HandView { get; set; }

    // UI References
    public Text Name;
    public Text Text;
    public float CardMagnifyScale = 1.2f;
    public float MagnificationSpeed = 0.2f;
    public bool IsHeld { get; private set; }
    public bool IsHighlighted { get; private set; }
    private Vector2 GrabDifferenceOffset;

    public override void OnEveryFrame()
    {
        UpdateView(); // TODO : Only update the view after changes are made to the cards data

        var playerControlStateManager = MatchController.Controller.PlayerControlStateManager;
        var isPlayerActing = playerControlStateManager.IsPlayerActing;

        if (IsHighlighted || IsHeld)
        {
            DoHighlighting();
        }
        else
        {
            StopHighlighting();
        }

        if (IsHeld)
        {
            DoHolding();
        }
    }

    private void DoHighlighting()
    {
        SetTargetScale(CardMagnifyScale, MagnificationSpeed);
        SetOrderLayer(UiViewLayerOrder.Forward);
    }

    private void StopHighlighting()
    {
        ResetScale();
        SetOrderLayer(UiViewLayerOrder.Middle);
    }

    private void DoHolding()
    {
        var mouseWorldPoint = UiViewHelper.GetMousePositionWorldPoint();
        var targetPosition = mouseWorldPoint + GrabDifferenceOffset;
        SetTargetPosition(targetPosition);
        SetTargetRotation(0, 2);
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

        MatchController.Controller.MatchViewManager.PositionCardsInHand();
    }
}

