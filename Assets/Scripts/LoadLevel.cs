using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int level;

    public void LoadLevelId(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LoadLevelId(level);
        }
    }
}
