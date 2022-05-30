using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketBehaviour : MonoBehaviour
{
    //make a pause button, so  timer should freeze...
    public string basketName;
    public int basketScore;
    public Text basketScoreText;

    public Text finalNumberOfItemsInBucketText;

    public BasketType basketType;

    public int numberOfItemsInBucket;

    //public BoxCollider2D collider;
    public enum BasketType
    {
        FruitBasket,
        AccessoryBasket,
        TrekkingBasket
    }

    // Start is called before the first frame update
    void Start()
    {
         GetComponent<BoxCollider2D>();
        numberOfItemsInBucket = 0;
    }

    // Update is called once per frame
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ItemBehaviour>() != null)
        {           
            if ((int)basketType == (int)collision.GetComponent<ItemBehaviour>().itemType)
            {
                basketScore += collision.GetComponent<ItemBehaviour>().bountyOnItem;
                basketScoreText.text = basketScore.ToString();
                MainScreenBehaviour.Instance.IncreaseTotalScore(collision.GetComponent<ItemBehaviour>().bountyOnItem);
                collision.gameObject.SetActive(false);
                Debug.Log(collision.name + " detected");
                numberOfItemsInBucket++;
                finalNumberOfItemsInBucketText.text = numberOfItemsInBucket.ToString();
                MainScreenBehaviour.Instance.PlayCorrectShotOneTime();
            }
            else
            {
                //here we will maybe, lerp the item object to the dustbin
                //and from there we will subtract the bounty on item from the total score
                MainScreenBehaviour.Instance.DecreaseTotalScore(collision.GetComponent<ItemBehaviour>().bountyOnItem);
                MainScreenBehaviour.Instance.IncDecDustbinCount();
                collision.gameObject.SetActive(false);
                MainScreenBehaviour.Instance.PlayWrongShotOneTime();
            }
        }
       
    }  
}
