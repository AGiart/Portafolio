using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallChallengeController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            BattleManager controller = GameObject.FindObjectOfType<BattleManager>();
            controller.gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }

}
