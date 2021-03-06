﻿using UnityEngine;

/// <summary>
/// Create an AI that flies by the player
/// </summary>
public class DriveByPlayerAI : AI {

    private const AIType typeOfAI = AIType.DriveByAI;

    public override AIType TypeOfAI {
        get {
            return typeOfAI;
        }
    }

    private Transform playerTransform;

    private bool passedPlayer;

    public DriveByPlayerAI(Enemy enemyToControl) : base(enemyToControl) {
        playerTransform = Player.Instance.transform;

        // True if the enemy passed by the player.
        passedPlayer = false;
    }

    public override void SwitchState(AI newAIState) {}

    public override void UpdateAI(float time) {
        HandleShooting(time);
        HandleMovement(time);
    }

    private void HandleMovement(float time) {
        // If the enemy has yet to pass by the player.
        if (!passedPlayer) {
            // Get direction to player
            Vector2 direction = (playerTransform.position - ControllingEnemy.transform.position).normalized;

            float rotateAmt = Vector3.Cross(direction, ControllingEnemy.transform.up).z;

            Vector2 finalDirection = (direction * (rotateAmt * ControllingEnemy.Speed)).normalized;

            // Move this enemy towards the player.
            ControllingEnemy.SetMoveDirection((playerTransform.position - ControllingEnemy.transform.position).normalized);

            // check if the enemy has passed by the player.
            if (ControllingEnemy.transform.position.y <= playerTransform.position.y) {
                passedPlayer = true;
            }
        }
    }
}
