using UnityEngine;
using TMPro;

public class ending : MonoBehaviour
{
    public Tracker tracker;
    public TextMeshProUGUI tries; 
    public TextMeshProUGUI score; 

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tracker = FindObjectOfType<Tracker>();
        score.text = "Total Score: " + tracker.TrackScore.ToString(); 
        tries.text = "Total Tries: " + tracker.tries.ToString(); 


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
