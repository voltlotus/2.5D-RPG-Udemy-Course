using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyName;
    public int BaseHealth;
    public int BaseStrength;
    public int BaseSpeed;
    public GameObject EnemyVisualPrefab; //used in battle scene
}