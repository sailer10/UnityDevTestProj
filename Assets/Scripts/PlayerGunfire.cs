using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunfire : MonoBehaviour
{
    private PlayerController player;
    private PlayerController.Ability ability;

    // Sphere bullet 프리팹
    public GameObject bullet;
    public Transform firePos;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        ability = player.ability;
    }
    // Update is called once per frame
    void Update()
    {
        ability = player.ability;
        if (ability == PlayerController.Ability.gunfire && Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Bullet 프리팹을 동적으로 생성
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
