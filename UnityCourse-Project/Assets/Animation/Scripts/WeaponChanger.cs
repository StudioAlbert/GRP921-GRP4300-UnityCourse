using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


enum Weapon : int
{
    NONE,
    HANDS,
    RIFLE,
    FIGHTING,
    WEAPON_ENUM_LIMIT
}

public class WeaponChanger : MonoBehaviour
{
    private Weapon weapon = Weapon.NONE;

    public InputControllerByInputSystem inputController;
    public PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        //Subscribing to delegate
        //eg. of Multicast Delegate
        inputController.weaponChanged += changeWeapon;
    }
    private void OnDisable()
    {
        //UnSubscribing to Delegate
        inputController.weaponChanged -= changeWeapon;
    }

    public void changeWeapon()
    {

        Debug.Log("Changing Weapon");
        
        weapon++;
        if (weapon >= Weapon.WEAPON_ENUM_LIMIT)
        {
            weapon = Weapon.NONE;
        }

        switch (weapon)
        {
            case Weapon.NONE:
                playerAnimation.RealeasePosture();
                break;
            case Weapon.HANDS:
                playerAnimation.Do2HandsPosture();
                break;
            case Weapon.RIFLE:
                playerAnimation.DoRiflePosture();
                break;
            case Weapon.FIGHTING:
                playerAnimation.DoFightingPosture();
                break;
            case Weapon.WEAPON_ENUM_LIMIT:
            default:
                playerAnimation.RealeasePosture();
                weapon = Weapon.NONE;
                break;
        }
    }
}
