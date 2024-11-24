using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public bool isFlipped = false;               
    public int cardID;                         
    private Button cardButton;                  
    private Image cardImage;                     

    public Sprite frontSprite;                   
    public Sprite backSprite;                    

    public GameManager gameManager;            

    public void Start()
    {
        cardButton = GetComponent<Button>();
        cardImage = GetComponent<Image>();       
        cardButton.onClick.AddListener(OnCardClicked);

        cardImage.sprite = backSprite;
    }

    public void OnCardClicked()
    {
        if (!isFlipped && gameManager.CanFlip())
        {
            FlipCard();
            gameManager.CardFlipped(this);
        }
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;
        cardImage.sprite = isFlipped ? frontSprite : backSprite;
    }
}
