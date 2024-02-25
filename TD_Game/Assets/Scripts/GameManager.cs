
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    AudioManager audioManager;

    private void Start()
    {
        audioManager.PlayMusic("Theme");
    }

}
