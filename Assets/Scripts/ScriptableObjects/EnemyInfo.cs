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
    [Header("Enemy Properties")]
    public float FollowRange;

}
