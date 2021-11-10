using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public MonsterSpawner Spawner;
    public void GoHome()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Reload()
    {
        Spawner.StartGame();
        gameObject.SetActive(false);
    }
}
