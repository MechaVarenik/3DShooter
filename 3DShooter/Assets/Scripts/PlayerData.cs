
[System.Serializable]
public class PlayerData
{
    public int score;

    public int[] currentAmmo = { 0, 0 };
    public int[] totalAmmo = { 0, 0 };
    public int selectedWeapon;

    public int playerHealth;
    public float[] playerPosition;

    public PlayerData()
    {
        score = PlayerVariable.score;
        currentAmmo = PlayerVariable.currentAmmo;
        totalAmmo = PlayerVariable.totalAmmo;
        selectedWeapon = PlayerVariable.selectedWeapon;
        playerHealth = PlayerVariable.currentHealth;
        playerPosition = new float[3];
        playerPosition[0] = PlayerVariable.playerPosition.x;
        playerPosition[1] = PlayerVariable.playerPosition.y;
        playerPosition[2] = PlayerVariable.playerPosition.z;
    }
}
