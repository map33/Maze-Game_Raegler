using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Movement values
    private float xMove;
    private float yMove;

    // Speed of the player
    public float speed = 5;

    // What moves the player
    public CharacterController charCh;

    // Health values
    public int health = 5;
    public Image[] hearts = new Image[5];

    // UI elements to manipulate
    public Text endText;
    public Button endButton;

    // To make sure you can't die if the game is over
    private bool gamePlaying;

    private void Start()
    {
        gamePlaying = true;
        UpdateHearts();
        endText.gameObject.SetActive(false);
        endButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // Move the player
        if (gamePlaying) {
            charCh.SimpleMove(new Vector3(xMove, 0, yMove) * speed);
        }
    }


    // When an input key is pressed
    void OnMove(InputValue inputDirection)
    {
        // Gather the x and y values, allowing the player to move in all directions
        xMove = inputDirection.Get<Vector2>().x;
        yMove = inputDirection.Get<Vector2>().y;
    }

    // When the player collides with something
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collided object is a wall
        if (collision.gameObject.tag == "Wall")
        {
            // Reduce health
            health--;

            // Update our hearts to match new health
            UpdateHearts();
            Debug.Log(health.ToString());
            // If our health reaches 0, trigger the game over screen
            if (health < 1)
            {
                // End the game with a game over
                GameOver();
            }
        }
        // IF the player touches the goal,
        if (collision.gameObject.tag == "Goal")
        {
            // End the game.
            EndGame();
        }
    }

    // Used to update the heart count
    void UpdateHearts()
    {
        // For each heart,
        for (int i = 0; i < hearts.Length; i++)
        {
            // Check if our health value matches the heart number
            if (i + 1 <= health)
            {
                // Show it by coloring it red
                hearts[i].color = Color.red;
            }
            else
            {
                // Otherwise, hide it by coloring it black
                hearts[i].color = Color.black;
            }
        }
    }

    void EndGame()
    {
        // Stop the player from moving
        gamePlaying = false;

        // Display your time and the retry button
        endText.gameObject.SetActive(true);
        endText.text = "You Win!\nTime to Complete: " + Time.timeSinceLevelLoadAsDouble.ToString();
        endButton.gameObject.SetActive(true);
    }

    void GameOver()
    {
        // Stop the player from moving
        gamePlaying = false;

        // Display the game over text and the retry button
        endText.gameObject.SetActive(true);
        endText.text = "Game Over!!";
        endButton.gameObject.SetActive(true);
    }
}
