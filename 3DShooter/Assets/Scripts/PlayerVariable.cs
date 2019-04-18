using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariable
{
    public static int maxHealth = 100;
    public static int score;

    public static int[] currentAmmo = {0, 0};
    public static int[] totalAmmo = { 90, 90 };

    public static int selectedWeapon = 0;

    public static int currentHealth = maxHealth;

    public static bool fireLock = false;

    public static Vector3 playerPosition = new Vector3(0, 1, 0);
}
