using System;
using System.CodeDom;
using System.Linq;
using UnityEngine;

public class UiViewHandler : MonoBehaviour {

    #region Class

    [Serializable]
    public struct PrefabReference {

        public string Identity;
        public GameObject Prefab;
    }

    #endregion

    private static UiViewHandler _uiViewHandler;
    public static UiViewHandler Handler => _uiViewHandler;

    public Canvas Canvas;
    public PrefabReference[] Prefabs;

    private void Awake()
    {
        if (_uiViewHandler != null && _uiViewHandler != this)
        {
            Destroy(this.gameObject);
        } else {
            _uiViewHandler = this;
        }
    }

    public T InstantiateUiView<T>(string prefabIdentity) where T : UiView
    {
        var defaultOriginPosition = Vector2.zero;
        var defaultUiViewLayer = UiViewLayer.Midground;
        return InstantiateUiView<T>(prefabIdentity, defaultOriginPosition, defaultUiViewLayer);
    }

    public T InstantiateUiView<T>(
        string prefabIdentity,
        Vector2? position,
        UiViewLayer uiViewLayer) where T : UiView
    {
        var prefabToCreate = Prefabs.FirstOrDefault(reference => reference.Identity == prefabIdentity).Prefab;
        if (prefabToCreate == null) throw new PrefabNotFoundException(prefabIdentity);

        var prefab = Instantiate(prefabToCreate, Vector3.zero, Quaternion.identity, Canvas.transform);
        prefab.transform.localPosition = position ?? prefabToCreate.transform.localPosition;

        prefab.name = prefabIdentity;

        var prefabComponent = prefab.GetComponent<T>();
        if (prefabComponent == null) throw new PrefabDoesntHaveSpecifiedComponent(prefabIdentity);

        prefabComponent.SetUiViewLayer(uiViewLayer);

        return prefabComponent;
    }

    public T InstantiateEntityView<T, TE>(
        string prefabIdentity,
        TE entityReference,
        Vector2? position,
        UiViewLayer uiViewLayer)
        where T : EntityView<TE>
        where TE : Entity
    {
        var prefabComponent = InstantiateUiView<T>(prefabIdentity, position, uiViewLayer);
        
        var entityView = (EntityView<TE>) prefabComponent;
        entityView.SetEntityReference(entityReference);
        
        var prefab = prefabComponent.gameObject;
        prefab.name = entityView.EntityReference.ToIdentity(IdentityType.Basic);

        return prefabComponent;
    }
}

