using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserInterface : MonoBehaviour
{
    private Character player;

    public Slider staminaSlider;
    public Slider healthSlider;
    public Slider expSlider;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Character>();
        staminaSlider.maxValue = player.GetStamina();
        healthSlider.maxValue = player.GetHealth();
        expSlider.maxValue = player.GetAmountToLvlUp();

        UpdateStaminaSlider();
        UpdateExpSlider();
        UpdateHealthSlider();
    }

    public void UpdateStaminaSlider()
    {
        staminaSlider.value = player.GetStamina();
    }

    public void UpdateExpSlider()
    {
        expSlider.value = player.GetExp();
    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = player.GetHealth();
    }
}
