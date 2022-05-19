using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControler : MonoBehaviour
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
        Die();
        
        healthBar.SetHealth(PlayerStatus.HP);
    }
    private void Die()  // example for player
    {
        if (PlayerStatus.HP <= 0)
        {
            Destroy(gameObject);
        }
    }


}
