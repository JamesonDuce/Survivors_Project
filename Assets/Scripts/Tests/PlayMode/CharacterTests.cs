using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CharacterTests
{
    Character player;
    UserInterface UI;

    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("CharacterDemo");

    }
    
    // A Test behaves as an ordinary method

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    [UnityTest]
    public IEnumerator CharacterTestUI()
    {
        yield return null;
        player = GameObject.Find("Player").GetComponent<Character>();
        UI = GameObject.Find("Canvas").GetComponent<UserInterface>();
        Assert.AreEqual(UI.healthSlider.value, player.GetHealth());
        Assert.AreEqual(UI.staminaSlider.value, player.GetStamina());
        Assert.AreEqual(UI.expSlider.value, player.GetExp());
    }

    [UnityTest]
    public IEnumerator CharacterCheckHealth()
    {
        yield return null;
        player = GameObject.Find("Player").GetComponent<Character>();
        float expectedHealth = 100;
        Assert.AreEqual(player.GetHealth(), expectedHealth);
    }

    [UnityTest]
    public IEnumerator CharacterCheckStaminaCap()
    {
        yield return null;
        player = GameObject.Find("Player").GetComponent<Character>();
        float expectedStamina = 100;
        Assert.AreEqual(player.GetStamina(), expectedStamina);
    }

    [UnityTest]
    public IEnumerator TestDamage()
    {
        yield return null;
        player = GameObject.Find("Player").GetComponent<Character>();
        float expectedHealth = 40;
        player.DamageCharacter(60);
        Assert.AreEqual(player.GetHealth(), expectedHealth);
    }

    [UnityTest] 
    public IEnumerator TestAddExp()
    {
        yield return null;
        int expectedExp = 0;
        player = GameObject.Find("Player").GetComponent<Character>();
        player.AddExp(20);

        Assert.AreEqual(expectedExp, player.GetExp());
    }
}
