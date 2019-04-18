using UnityEngine;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool isPause;
    public bool guipuse;
    public GameObject mainMenuPause;

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            
            isPause = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            
            isPause = false;

        }
        if (isPause == true)
        {
            timer = 0;
            mainMenuPause.SetActive(true);
            PlayerVariable.fireLock = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (isPause == false)
        {
            timer = 1f;
            mainMenuPause.SetActive(false);
            PlayerVariable.fireLock = false;
            if (PlayerVariable.currentHealth > 0)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
