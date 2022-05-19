using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStatus.HP = PlayerStatus.maxHP;
        healthBar.SetMaxHealth(PlayerStatus.maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayerStatus.HP -= 20;
            
        }
        healthBar.SetHealth(PlayerStatus.HP);
    }

	
}
