using System;
using UnityEditor;
using UnityEngine;

    /***The item.cs script has 3 class
    The ScriptableObjectId create UNIQUE ids using a drawer.
    The Item class extend ScriptableObject and create a new item
    with name, text, and ID***/
public class ScriptableObjectId : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ScriptableObjectId))]
public class ScriptableObjectIdDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        GUI.enabled = false;
        if (string.IsNullOrEmpty(property.stringValue)) {
            property.stringValue = Guid.NewGuid().ToString();
        }
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endif



[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [ScriptableObjectId] public string Id;
    new public string name = "New item";
    public Sprite icon = null;
    public bool isDeafaultItem = false;
    
    public static Item instance;
    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this;
    }

    public virtual void Use(string Ids)
    {
        Id = Ids;
        // Use item...
        Debug.Log("Using " + Id);

    }

    public void RemoveFromInventory(string Ids)
    {
        Id = Ids;
        Inventory.instance.RemoveItem(Id);
    }
    
    
}
