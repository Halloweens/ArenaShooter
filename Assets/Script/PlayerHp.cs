using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour {
    [SerializeField ]
    private int playerMaxHp = 3;

    private static int playerHp = 0;
    private Text label = null;

    void Start()
    {
        playerHp = playerMaxHp;
        Hud.life = playerHp;
    }

    void OnTriggerEnter(Collider collider)
    { 
        if (collider.gameObject.tag == "Ennemy")
        {
            UpdateHp();
        }
    }

    public static void UpdateHp()
    {
        playerHp--;
        Hud.life = playerHp;
    }

    void Update()
    {
        if (playerHp <= 0)
        {
            SceneManager.LoadScene(0);
            Hud.scoring = 0;
            playerHp = playerMaxHp;
            Hud.life = playerHp;
        }
    }


}
