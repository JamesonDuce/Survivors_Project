using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

/* TODO:
 * 1. Integrate Weapons to the character object. 
 * 2. Leveling up mechanics (Adjusting health, exp, upgrade weapon option?)
*/


// Idea : Hippo can reflect projectiles towards enemies and damage them through it? 

public class Character : MonoBehaviour
{
    private UserInterface UI;
    public int characterID = 0;

    public float healthCap = 100; // Max amount the player can have
    private float health; // Current amount the player has

    public float GetHealth()
    {
        return health;
    }
    public float delayreset = 3.5f;
    public float delay = 1000000;
    public float staminaCap = 100;
    public float staminaRegenRate = 0.5f;
    private float stamina;

    public float GetStamina()
    {
        return stamina;
    }

    public float speed = 5;
    public float defense = 100; // Will have to discuss the intended use of defense.

    public int gold = 0;
    public int level = 0;
    private int exp = 0;
    public int GetExp()
    {
        return exp;
    }

    private int[] lvlUpAmountRequired = { 20, 50, 100, 200, 450, 750 }; // Will have to make into an algo eventually, just keeping simple for now. 

    public int weaponCount = 5;
    public int mainWeaponID = 0;

    public int dashStamCost = 20;

    private float vertInput = 0;
    private float horzInput = 0;
    private Vector2 moveVector;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private Vector2 tempVector;

    private bool isDashing = false;
    public float dashTimer = .2f;
    public float dashSpeed;
    private float resetTime;

    private bool isPaused { get; set; } = false;
    private bool gameOver = false;

    void Awake()
    {
        resetTime = dashTimer;
        health = healthCap;
        stamina = staminaCap;

        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        UI = GameObject.Find("Canvas").GetComponent<UserInterface>();

    }

    void FixedUpdate()
    {
        CharacterMovement();
    }

    private void Update()
    {
        CharacterInput();

        if (isDashing)
        {
            if (dashTimer > 0)
            {
                dashTimer -= Time.deltaTime;
                playerRb.velocity = (moveVector * speed * dashSpeed);
            }
            else
            {
                dashTimer = resetTime;
                isDashing = false;
            }
        }
        else
        {
            RegenStamina();
        }

        CharacterAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Logic for collisions depending on collision objects tag?
    }

    public void RegenStamina(int addAmount = 0) // Regenerates the players stamina. Optional param for adding stamina, possibly for a bonus item.
    {
        if (stamina < staminaCap)
        {
            stamina += Time.deltaTime * staminaRegenRate + addAmount;
            if (stamina > staminaCap)
            {
                stamina = staminaCap; // If it goes over the players max allowed stamina, adjust the players stamina. 
            }
            UI.UpdateStaminaSlider();
        }
    }

    void CharacterInput() // Gets the input of the user
    {
        if (!isDashing && !gameOver && !isPaused)
        {
            horzInput = Input.GetAxisRaw("Horizontal");
            vertInput = Input.GetAxisRaw("Vertical");
            moveVector = new Vector2(horzInput, vertInput).normalized; // Normalizes the vector in order to prevent user from gaining speed when using both inputs

            if (Input.GetKeyDown(KeyCode.Space) && (stamina > dashStamCost) && !(horzInput == 0 && vertInput == 0)) // Dash if they have enough stamina
            {
                isDashing = true;
                stamina -= dashStamCost;
                UI.UpdateStaminaSlider();
            }
            else if (Input.GetKeyDown(KeyCode.E)) // Shove
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver) // Pause game is game is not over
        {
            UI.TogglePauseScreen();
        }
    }

    void CharacterMovement()
    {
        if (!isDashing && !gameOver && !isPaused)
        {
            playerRb.velocity = (moveVector * speed);
        }
    }

    void CharacterAnimation() // Controls animation variables to determine the proper animation to play
    {
        if (isPaused || gameOver)
            return;

        playerAnimator.SetFloat("horz", horzInput);
        playerAnimator.SetFloat("vert", vertInput);

        if (horzInput == 0 && vertInput == 0) // If there is no player input
        {
            playerAnimator.SetFloat("horz", tempVector.x); // Set the animation to what direction they faced previously
            playerAnimator.SetFloat("vert", tempVector.y);
            playerAnimator.speed = 0; // Pause the animation
        }
        else
        {
            tempVector = moveVector; // Save what direction the player is facing
            playerAnimator.speed = 1; // Play the animation.
        }
    }

    public void DamageCharacter(float damageAmount)
    {
        if (isDashing)
            return;
        health -= damageAmount;
        UI.UpdateHealthSlider();
        if (health <= 0)
        {
            OnGameOver(); // If the player reaches 0 health, end the game;
        }
    }

    public void AddExp(int gainAmount)
    {
        exp += gainAmount;
        if (exp >= lvlUpAmountRequired[level]) // If player has enough exp to go to next level
        {
            exp -= lvlUpAmountRequired[level]; // Take the exp cost away
            level++;
            UI.UpdateLevelText(level);
            // Play some animation
            // Pause the gameplay
            // Give player a choice of upgrade
        }
        UI.UpdateExpSlider();
    }
    public void AddGold(int goldGain)
    {
        gold += goldGain;
        UI.UpdateGoldText(gold);
    }

    public int GetAmountToLvlUp()
    {
        return lvlUpAmountRequired[level];
    }

    public int Getlevel()
    {
        return level;
    }

    public void OnGameOver()
    {
        // Play death animation
        gameOver = true;
        playerAnimator.SetBool("gameOver", true);
        Time.timeScale = 1;
        playerRb.simulated = false;

        playerRb.velocity = Vector2.zero;
        playerAnimator.speed = 1;
        // Save the player's stats
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void SetPaused(bool pause)
    {
        isPaused = pause;
    }
}
