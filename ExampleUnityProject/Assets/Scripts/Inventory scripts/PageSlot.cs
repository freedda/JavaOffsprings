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
    private Item item;
    private int count = 0;
        
    public void AddPage(Item newItem)
    {
        count += 1;
        /*if (!(icon.enabled))
        {
           icon.enabled = true; 
        }*/
        item = newItem;
        //icon.sprite = item.icon;
        countText.text = count.ToString();
        
      //  countText.gameObject.SetActive(true);
    }

   
}

