using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler {
	
	public bool IsInteractive { get; set; } // TODO : Make these relevant
	public bool IsControllable { get; set; } // TODO : Make these relevant

	public float MoveSpeed;
	public Vector3 TargetPosition;
	public float RotationSpeed;
	public Vector3 TargetRotation;
	
	public virtual void Update()
	{
		var deltaTime = Time.deltaTime; // TODO : Animation timer helper?
		
		var deltaMoveSpeed = MoveSpeed * deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, TargetPosition, deltaMoveSpeed);

		// TODO : Add rotation
//		var deltaRotateSpeed = RotationSpeed * deltaTime;
//		transform.rotation = Vector3.RotateTowards(transform.forward, TargetRotation, deltaRotateSpeed, 0f);
	}

	public bool IsLeftClick(PointerEventData eventData) => (eventData.button == PointerEventData.InputButton.Left);
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (UiViewHelper.Current == null) this.SetCurrent();
		if (!this.IsCurrent()) return;
		PointerEnter();
	}

	public virtual void PointerEnter() {}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!this.IsCurrent()) return;
		this.UnsetCurrent();
		PointerExit();
	}
	
	public virtual void PointerExit() {}
	
	public void OnDrag(PointerEventData eventData)
	{
		if (!this.IsCurrent()) return;
		if (!IsLeftClick(eventData)) return;
		PointerDrag();
	}

	public virtual void PointerDrag() {}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!this.IsCurrent()) return;
		if (!IsLeftClick(eventData)) return;
		PointerBeginDrag();
	}

	public virtual void PointerBeginDrag() {}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!this.IsCurrent()) return;
		if (!IsLeftClick(eventData)) return;
		PointerEndDrag();
	}
	
	public virtual void PointerEndDrag() {}
}
