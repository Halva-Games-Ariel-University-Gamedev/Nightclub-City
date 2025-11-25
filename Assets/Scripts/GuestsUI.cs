using UnityEngine;
using TMPro; 

public class GuestsUI : MonoBehaviour
{
    public TextMeshProUGUI guestsText; 

    void Update()
    {
        int npcCount = GameObject.FindGameObjectsWithTag("NPC").Length;
        guestsText.text = "Guests: " + npcCount;
    }
}
