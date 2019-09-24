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

    public T Instantiate<T>(string prefabIdentity, Vector3? position = null) where T : UiView
    {
        var prefabToCreate = Prefabs.FirstOrDefault(reference => reference.Identity == prefabIdentity).Prefab;
        if (prefabToCreate == null) throw new PrefabNotFoundException(prefabIdentity);

        var prefab = Instantiate(prefabToCreate, position ?? Vector3.zero, Quaternion.identity, Canvas.transform);
        prefab.transform.localPosition = Vector3.zero;
        
        var prefabComponent = prefab.GetComponent<T>();
        if (prefabComponent == null) throw new PrefabDoesntHaveSpecifiedComponent(prefabIdentity);

        prefab.name = prefabIdentity;

        return prefabComponent;
    }

    public T Instantiate<T, TE>(string prefabIdentity, TE entityReference, Vector3? position = null) 
        where T : EntityView<TE>
        where TE : Entity
    {
        var prefabComponent = Instantiate<T>(prefabIdentity, position);
        
        var entityView = (EntityView<TE>) prefabComponent;
        entityView.SetEntityReference(entityReference);
        
        var prefab = prefabComponent.gameObject;
        prefab.name = entityView.EntityReference.ToIdentity(IdentityType.Basic);

        return prefabComponent;
    }
}

