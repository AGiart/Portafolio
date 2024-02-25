using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleController : MonoBehaviour
{
    [SerializeField]
    CharacterBattleController opponentCharacter;

    [SerializeField]
    bool isPlayer;

    [SerializeField]
    SpriteRenderer characterImage;

    [SerializeField]
    BattleAction[] actions;
    public void Heal(float value)
    {

    }


    public void TakeDamage(float value)
    {
        BattleAction action = Array.Find(actions, s => s.getName() == "Hit");
        characterImage.sprite = action.getSprite();

    }

    public void Attack()
    {
        BattleAction action = Array.Find(actions, s => s.getName() == "Attack");
        StartCoroutine(AttackOpponent(action));

        action = Array.Find(actions, s => s.getName() == "Idle");
        characterImage.sprite = action.getSprite();
    }

    IEnumerator AttackOpponent(BattleAction action)
    {
        opponentCharacter.TakeDamage(action.getValue());
        yield return new WaitForSeconds(0.75F);
    }
}
