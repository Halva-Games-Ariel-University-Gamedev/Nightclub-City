using UnityEngine;

public class DJButtonHandler : MonoBehaviour
{
    public void PlayPop()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayTrack(0); 
    }

    public void PlayTechno()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayTrack(1); 
    }
}
