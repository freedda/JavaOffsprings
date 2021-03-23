using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite icon = null;
    public bool isDeafaultItem = false;

    public virtual void Use()
    {
        // Use item...
        Debug.Log("Using " + name);

    }
    
}
