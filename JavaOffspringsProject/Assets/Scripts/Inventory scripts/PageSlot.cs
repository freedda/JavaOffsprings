using UnityEngine;
using UnityEngine.UI;


public class PageSlot : MonoBehaviour
{
    #region Singleton
    public static PageSlot instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PageSlot found");
            return;
        }
        instance = this;
    }
    #endregion
    
    public Text countText;
    private string item;
    private int count = 0;
        
    public void AddPage(string newItemId)
    {
        
        count += 1;
        item = newItemId;
        // Set the new amount of collected pages
        countText.text = count.ToString();
    }

   
}

