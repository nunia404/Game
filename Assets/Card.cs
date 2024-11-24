using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public CardManager cardManager;
    public int code = 1;
    public Hashtable cardList = new Hashtable();

    // Update is called once per frame
    void Start()
    {
        cardList.Add("BlackChest", 1);
        cardList.Add("RedChest", 2);
    }

    void OnMouseDown()
    {
        //Debug.Log("This object clicked: " + gameObject.name);
        //cardManager.GetCard(this);
    }
}
