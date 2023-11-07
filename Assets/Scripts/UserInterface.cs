using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UserInterface : MonoBehaviour
{
    private Character player;

    public Slider staminaSlider;
    public Slider healthSlider;
    public Slider expSlider;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI levelText;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Character>();
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
        expSlider.maxValue = player.GetAmountToLvlUp();
        expSlider.value = player.GetExp();
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }

    public void UpdateGoldText(int gold)
    {
        goldText.text = "Gold: " + gold.ToString();
    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = player.GetHealth();
    }
}
