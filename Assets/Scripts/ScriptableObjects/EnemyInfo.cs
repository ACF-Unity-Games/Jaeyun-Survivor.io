using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 1)]
public class EnemyInfo : ScriptableObject
{

    [Header("Enemy Meta Info")]
    public string EnemyName;
    [TextArea(2, 6)]
    public string EnemyDescription;
    public Sprite EnemySprite;
    public Vector2 EnemyScale = new(1, 1);
    [Header("Enemy Properties")]
    public int MaxHealth = 10;
    public int EnemyDamage = 1;
    public float FollowRange = 3;
    public float EnemyMoveSpeed = 30;

}
