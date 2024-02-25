using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battle Action", menuName = "New Battle Action")]
public class BattleAction : ScriptableObject
{

    public enum ActionTypes
    {
        Attack,
        Heal
    }

    [SerializeField]
    string Name;

    [SerializeField]
    float value;

    [SerializeField]
    ActionTypes actionType;

    [SerializeField]
    Sprite sprite;

    public string getName()
    {
        return name;
    }

    public float getValue()
    {
        return value;
    }

    public ActionTypes getActionType()
    {
        return actionType;
    }

    public Sprite getSprite()
    {
        return sprite;
    }
}
