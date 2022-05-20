using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MOVE THIS LATER
public enum Element
{
    Fire, 
    Water, 
    Earth, 
    Air, 
    Light, 
    Dark, 
    Story,
    Lightning,
    NULL
}

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class BaseCharacter : ScriptableObject
{
    public string FirstName;
    public string LastName;
    public string NickName;

    public int id;

    public float MaxHealth;
    public float CurrentHealth;

    public Element Primary;
    public Element Secondary;
    public Element Tertiary;

    public float friendship;
    public float love;
}
