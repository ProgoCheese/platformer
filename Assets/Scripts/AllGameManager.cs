using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllGameManager : MonoBehaviour
{
    public Text seedCounter;
    public Text CurretnLevel;
    public int seedCounterValue = 0; 
    public int seedCounterMax = 0;
    public int setLevel = 0;

    private void OnEnable()
    {
        seedCounterValue = Transmitter.SeedCountAll;
    }

    public void SetLevelPlay(int level)
    {
        setLevel = level;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(setLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seedCounter.text = seedCounterValue.ToString() + "/" + seedCounterMax;
        CurretnLevel.text = "Текущий уровень: " + setLevel;
    }
}
