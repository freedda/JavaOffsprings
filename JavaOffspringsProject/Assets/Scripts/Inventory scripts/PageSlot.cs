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
    
    //public Image icon;
    public Text countText;
    private string item;
    private int count = 0;
        
    public void AddPage(string newItemId)
    {
        count += 1;
        
        item = newItemId;
        //icon.sprite = item.icon;
        countText.text = count.ToString();
        
      //  countText.gameObject.SetActive(true);
    }

   
}

