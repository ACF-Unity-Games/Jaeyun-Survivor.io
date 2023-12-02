using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    ROAM = 0, CHASE
} 

public class EnemyMovementHandler : MonoBehaviour
{

    [Header("Enemy Properties")]
    [SerializeField] private EnemyInfo _enemyInfo;

    private GameObject _playerObject;
    private EnemyState _currState;

    private void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(_playerObject != null, "Tagged player object not found!", this);
    }

    private void Update()
    {
        UpdateEnemyState();
        MoveBasedOnState();
    }

    /// <summary>
    /// Switches the enemy's current state to the specified one.
    /// </summary>
    /// <param name="newState">The enemy's state to set to</param>
    private void SwitchState(EnemyState newState)
    {
        _currState = newState;
    }

    /// <summary>
    /// Updates the state of the enemy based on the player's
    /// current properties.
    /// </summary>
    private void UpdateEnemyState()
    {
        float dist = Vector2.Distance(transform.position, _playerObject.transform.position);
        switch (_currState)
        {
            case EnemyState.ROAM:
                if (dist < _enemyInfo.FollowRange)
                {
                    SwitchState(EnemyState.CHASE);
                }
                break;
            case EnemyState.CHASE:
                if (dist >= _enemyInfo.FollowRange)
                {
                    SwitchState(EnemyState.CHASE);
                }
                break;
        }
    }

    /// <summary>
    /// Renders one frame of movement based on the enemy's
    /// current state.
    /// </summary>
    private void MoveBasedOnState()
    {
        switch (_currState)
        {
            case EnemyState.ROAM:
                // Roam!
                break;
            case EnemyState.CHASE:
                // Chase player!
                break;
        }
    }

    /// <summary>
    /// Draw wire circle around enemy based on FollowRange.
    /// </summary>
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _enemyInfo.FollowRange);
    }

}
