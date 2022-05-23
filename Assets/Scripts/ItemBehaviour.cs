using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemBehaviour : MonoBehaviour//, IDragHandler, IPointerDownHandler
{
    public string itemName;
    public ItemType itemType;
    public int bountyOnItem;
    //public SpriteRenderer itemSpriteRenderer;
    public Image itemImage;
    public enum ItemType
    {
        Fruit,
        Accessory,
        Trekking
    }

    //protected  void IDragHandler()

  
    int end;
    // Start is called before the first frame update
    void Start()
    {
        bountyOnItem = 5;

        itemName = gameObject.name;

        GetComponent<BoxCollider2D>();
    }    
}
