using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour
{
public Vector2 targetExpand;      
 public Vector2 targetCollapse;    
 public float scaleSpeed = 5.0f;   
 public Sprite cardImage;
 public Sprite coverImage;
 public SpriteRenderer spriteRenderer;
 private bool isShowingCardImage = true;
 public CardManager cardManager;

 //private bool isCollasped = false; 
 private bool isClicked = false;   
 private bool isExpanding = false;
 public Vector2 desiredSize;
 public Hashtable cardList = new Hashtable();
 public bool isMatched = false;
 public bool isClickAble = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
private void Start()
{
    cardList.Add("Screenshot 2567-11-05 at 21.41.18_0", 1);
    cardList.Add("Screenshot 2567-11-05 at 21.41.14_0", 2);
    cardList.Add("Screenshot 2567-11-05 at 21.41.09_0", 3);
    cardList.Add("Screenshot 2567-11-05 at 21.41.05_0", 4);
    cardList.Add("Screenshot 2567-11-05 at 21.40.59_0", 5);
    cardList.Add("blue_0", 7);
    cardList.Add("pink_0", 8);
    cardList.Add("Orange_0", 9);
    cardList.Add("silver_0", 10);
    cardList.Add("green_0", 11);

    
    
    cardManager = FindFirstObjectByType<CardManager>();
    transform.localScale = targetExpand; 
    spriteRenderer.sprite = coverImage; 
    cardManager.SetSpriteSize(spriteRenderer, desiredSize);
    //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
}
private void OnMouseDown()
{
    if(isMatched == false && isClickAble == true)
    {
        if (!isClicked)
        {
            isClicked = true;
            isExpanding = false;
        }
        changeImage();
        cardManager.GetCard(this);
    }
}

void Update()
{
    CollapseAndExpandCard();
    
}    
void CollapseAndExpandCard()
{
    if (isClicked)
    {
        if (!isExpanding)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, targetCollapse, scaleSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.localScale.x - targetCollapse.x) < 0.01f)
            {
                transform.localScale = targetCollapse; 
                isExpanding = true;                  
            }
        }
        else
        {
   
            transform.localScale = Vector2.Lerp(transform.localScale, targetExpand, scaleSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.localScale.x - targetExpand.x) < 0.01f)
            {
                transform.localScale = targetExpand; 
                isClicked = false;                   
                //isCollasped = false;                 
            }
        }
    }
}
void changeImage()
{
    if(isShowingCardImage)
    {
        spriteRenderer.sprite = cardImage; 
    }
    else
    {
        spriteRenderer.sprite = coverImage;
    }
    isShowingCardImage = !isShowingCardImage;
    cardManager.SetSpriteSize(spriteRenderer, desiredSize);
}
public void resetState()
{
    if(isMatched)
    {
        return;
    }
    isClicked = true;
    isExpanding = false;
    isShowingCardImage = false;
    spriteRenderer.sprite = coverImage;
    changeImage();
    transform.localScale = targetExpand;
    cardManager.SetSpriteSize(spriteRenderer, desiredSize);

}
}