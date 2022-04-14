using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;






public class Death : MonoBehaviour
{

    //public DeathImage death;
    public SusMeter sus;
     public string newGameScene;
    public PartyMeter party;


    // Start is called before the first frame update
    void Start()
    {
    // death.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (sus.checkDead() == true || party.checkDead() == true)
        {
            SceneManager.LoadScene(newGameScene);
            Debug.Log("GAME OVER");
        }
    }
}
