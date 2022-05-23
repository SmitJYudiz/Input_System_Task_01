using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectsOnScreenBehaviour : MonoBehaviour
{
    

    public static InstantiateObjectsOnScreenBehaviour Instance;


    public List<ItemBehaviour> allItems;
    public Vector2 placeOfNewObject;
    // Start is called before the first frame update
    void Start()
    {
        placeOfNewObject = new Vector2(0, 0);

    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaceItemsOnScreen()
    {
        int index = 0;
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 3; col++)
            {
               ItemBehaviour currentItem =   Instantiate(allItems[index], placeOfNewObject, Quaternion.identity);
                currentItem.gameObject.SetActive(true);
                //currentItem.itemSpriteRenderer.sprite
                index++;
                Debug.Log("Object instantiated");
                placeOfNewObject.x += 15;
            }
            placeOfNewObject.y += 15;
            placeOfNewObject.x = 0;
        }
    }
}
