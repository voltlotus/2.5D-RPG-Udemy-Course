using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyInfo[] allEnemies;
    [SerializeField] private List<Enemy> currentEnemies;

    private const float LEVEL_MODIFIER = 0.5f;

    [SerializeField] private EnemyInfo defaultEnemy;

    private void Awake()
    {
        GenerateEnemyByName("Slime", 1);
    }

    private void GenerateEnemyByName(string enemyName, int level)
    {
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if (enemyName == allEnemies[i].EnemyName)
            {
                Enemy newEnemy = new Enemy();

                newEnemy.EnemyName = allEnemies[i].EnemyName;
                newEnemy.Level = level;
                float levelModifier = (LEVEL_MODIFIER * newEnemy.Level);

                newEnemy.MaxHealth = Mathf.RoundToInt(allEnemies[i].BaseHealth + (allEnemies[i].BaseHealth * levelModifier));
                newEnemy.CurrHealth = newEnemy.MaxHealth;
                newEnemy.Strength = Mathf.RoundToInt(allEnemies[i].BaseStrength + (allEnemies[i].BaseStrength * levelModifier));
                newEnemy.Speed = Mathf.RoundToInt(allEnemies[i].BaseSpeed + (allEnemies[i].BaseSpeed * levelModifier));
                newEnemy.EnemyVisualPrefab = allEnemies[i].EnemyVisualPrefab;

                currentEnemies.Add(newEnemy);
            }
        }
    }
}

[System.Serializable]
public class Enemy
{
    public string EnemyName;
    public int Level;
    public int CurrHealth;
    public int MaxHealth;
    public int Strength;
    public int Speed;
    public GameObject EnemyVisualPrefab;
}
