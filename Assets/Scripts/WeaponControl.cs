using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Shooting shoots;
    public int weaponID = 1;
    public float Attack;
    public float AttackSpeed;
    public float AttackWidth;
    public float AttackLength;
    public bool AutoWeapon;
    public bool UsingActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {

    }

    //This class determines what weapon is being used.
    public void attackType()
    {
        if (weaponID == 1)
        {

            shoots.attacking();
        }
        else if (weaponID == 2)
        { }
        else if (weaponID == 3) { }
    }

    public void attackCollision()
    {


    }


}
