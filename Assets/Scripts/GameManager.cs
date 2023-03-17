using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public Player playerControl;

    public int seedCount = 0;

    public int healhPlayer = 100;
    
    public bool IsPlayerRigth;

    public bool IsCloverOn;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        Transmitter.SeedCountAll += seedCount;
    }
}
