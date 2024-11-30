using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    int firstCode = 0; 
    int secondCode = 0; 
    int GetAmount = 0;
    string check = " ";
    string check2 = " ";
    public Vector2 desiredSize; 
    public List<Sprite> uniqueSprites; 
    public List<GameObject> cardObjects;
    private List<Sprite> cardDeck; 
    public int Score = 0;
    public Text ScoreText;
    public float delayTimer = 1;
    public Tracker tracker;
    List<Animations> getClickedCard = new List<Animations>();
  

    public void Start()
    {
       tracker = FindObjectOfType<Tracker>();
       ScoreText.text = "Score: " + Score.ToString(); 
       
        foreach (var s in uniqueSprites)
{
    //Debug.Log(s.name);
}
        CardImage[] cards = FindObjectsByType<CardImage>(FindObjectsSortMode.InstanceID);
        foreach (CardImage card in cards)
        {
            if(card == null) continue; 
            cardObjects.Add(card.gameObject);
        }
        InitializeDeck(); 
        ShuffleDeck(); 
        AssignSpritesToCards();

    }
    public void Update()
    {
        

    }
    void InitializeDeck()
    {
        cardDeck = new List<Sprite>(); 
        foreach (Sprite sprite in uniqueSprites)
        {
            cardDeck.Add(sprite);
            cardDeck.Add(sprite);
        }
    }

    void ShuffleDeck()
    {
        for(int i = cardDeck.Count-1; i > 0; i--)
    {
        int j = Random.Range(0, i+1);
        Sprite temp = cardDeck[i];
        cardDeck[i] = cardDeck[j];
        cardDeck[j] = temp;
    }
    }
    
     
    void AssignSpritesToCards()
    {
        if (cardObjects.Count != cardDeck.Count)
        {
            //Debug.LogError("The number of card objects must match the number of sprites in the deck.");
            return; 
        }
       for (int i = 0; i < cardObjects.Count; i++)
        {
            GameObject card = cardObjects[i];
            if (card != null)
            {
                Animations cardParent = card.GetComponentInParent<Animations>();
                SpriteRenderer cardSpriteRender = card.GetComponent<SpriteRenderer>();
                
                cardSpriteRender.sprite = cardParent.coverImage;
                cardParent.cardImage = cardDeck[i];
                SetSpriteSize(cardParent.spriteRenderer, desiredSize);
            }
        }
    }
    public void SetSpriteSize(SpriteRenderer s, Vector2 size)
    {
        if (s.sprite == null) return; 
        Vector2 spriteSize = s.sprite.bounds.size; 
        Vector2 scale = new Vector2(size.x / spriteSize.x, size.y / spriteSize.y);
        s.transform.localScale = scale; 
    }
    
    public void GetCard(Animations c)
    {
        
        //Debug.Log("recieve card info: " + c.cardList[c.cardImage.name]);

        if (GetAmount == 0)
        {
            firstCode = System.Convert.ToInt32(c.cardList[c.cardImage.name]);
            GetAmount++;
            check = c.gameObject.name; 
            getClickedCard.Add(c);
        }
        else if (GetAmount == 1)
        {
            secondCode = System.Convert.ToInt32(c.cardList[c.cardImage.name]);
            GetAmount++;
            check2 = c.gameObject.name; 
            getClickedCard.Add(c);

        }
        if (GetAmount == 2)
        {
            tracker.updateTries(1);
            if (check != check2)
            {
                if (firstCode == secondCode)
                {
                    Debug.Log("Match!");
                    foreach(Animations item in getClickedCard)
                    {
                        item.isMatched = true; 
                    }
                    Score +=1;
                    tracker.updateTrackScore(1);
                    //Debug.Log(Score);
                    ScoreText.text = "Score: " + Score.ToString(); 
                    
                    getClickedCard.Clear();
                    
                }
                else
                {
                    Debug.Log("This is NOT a match.");
                    StartCoroutine(DelayTEST());
                    getClickedCard.Clear();
                }
            }
            else
            {
                //Debug.Log("Cannot click the same card twice.");     
                StartCoroutine(DelayTEST());
                getClickedCard.Clear();    
            }
            if(Score == uniqueSprites.Count)
            {
                Debug.Log("You WIN!");
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); 
                return;
             }
             else{

             }
            firstCode = 0; 
            secondCode = 0; 
            GetAmount = 0;
        }

    }
    void ResetClickableForAllCards(bool canClick)
    {
        foreach (GameObject item in cardObjects)
        {
            Animations c = item.GetComponentInParent<Animations>();
            c.isClickAble = canClick;
        }
    }
    void ResetAllCards()
    {
        foreach (GameObject item in cardObjects)
        {
            Animations card = item.GetComponentInParent<Animations>();
            if (card != null) 
            {
                card.resetState();
            }
        }
        ResetClickableForAllCards(true);
    }
    private IEnumerator DelayTEST()
    {
        ResetClickableForAllCards(false);
        yield return new WaitForSeconds(delayTimer);
        ResetAllCards();
        getClickedCard.Clear();
        Debug.Log("The delay is gone.");
        
    }

    }

