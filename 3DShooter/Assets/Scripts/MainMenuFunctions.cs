using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenuFunctions : MonoBehaviour
{
    GameObject enemy;

    private void Update()
    {
    }

    private void Start()
    {
    enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void Start(int sceneIndex)
    {
        if (sceneIndex == 1)
        {
            PlayerVariable.maxHealth = 100;
            PlayerVariable.currentHealth = PlayerVariable.maxHealth;
            PlayerVariable.currentAmmo = new int[] { 0, 0 };
            PlayerVariable.totalAmmo = new int[] { 90, 90 };
            PlayerVariable.selectedWeapon = 0;
            PlayerVariable.score = 0;
            PlayerVariable.playerPosition = new Vector3(0, 1, 0);
        }
        else
            Cursor.visible = true;
        //PlayerVariable.fireLock = false;
        SceneManager.LoadScene(sceneIndex);
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer();
    }

    public void LoadPlayer()
    {
       
        PlayerData data =  SaveSystem.LoadPlayer();
        PlayerVariable.score = data.score;
        PlayerVariable.currentAmmo = data.currentAmmo;
        PlayerVariable.totalAmmo = data.totalAmmo;
        PlayerVariable.selectedWeapon = data.selectedWeapon;

        SceneManager.LoadScene(1);
        Vector3 playerPosition;
        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        playerPosition.z = data.playerPosition[2];
        PlayerVariable.playerPosition = playerPosition;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
