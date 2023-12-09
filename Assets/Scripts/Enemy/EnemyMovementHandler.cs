using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    ROAM = 0, CHASE
}

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovementHandler : MonoBehaviour
{

    private EnemyInfo _enemyInfo;
    private SpriteRenderer _spriteRenderer;
    private GameObject _playerObject;
    private EnemyState _currState;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(_playerObject != null, "Tagged player object not found!", this);
    }

    public void Initialize(EnemyInfo enemyInfo)
    {
        Debug.Log("initialized!");
        _enemyInfo = enemyInfo;
        _spriteRenderer.sprite = enemyInfo.EnemySprite;
        transform.localScale = enemyInfo.EnemyScale;
    }

    private void Update()
    {
        if (_enemyInfo == null) { return; }
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
                    SwitchState(EnemyState.ROAM);
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
                Vector2 playerPos = _playerObject.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, playerPos, _enemyInfo.EnemyMoveSpeed * Time.deltaTime);
                break;
        }
    }

    /// <summary>
    /// Draw wire circle around enemy based on FollowRange.
    /// </summary>
    private void OnDrawGizmos()
    {
        if (_enemyInfo == null) { return; }
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _enemyInfo.FollowRange);
    }

}
