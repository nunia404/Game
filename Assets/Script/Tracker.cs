using UnityEngine;
public class Tracker : MonoBehaviour
{
    public int TrackScore = 0;
    public int tries = 0;
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void updateTries(int a)
    {
        tries += a;
    }
    public void updateTrackScore(int b)
    {
        TrackScore += b;
    }
   
}
