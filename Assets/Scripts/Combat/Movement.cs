using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public Transform slot4;
    public Transform slot5;
    public Transform slot6;

    public Stamina stamina;
    public AudioSource audioSource;

    public float evadeCooldown;
    private float evadeTime;
    public float jumpHeight = 1.0f;  // Altura del pequeño salto

    void Start()
    {
        Player.transform.position = slot2.position;
        evadeTime = 0;
    }

    void Update()
    {
        evadeTime += Time.deltaTime;

        if (stamina.currentStamina >= stamina.moveCost && evadeCooldown <= evadeTime && Player != null)
        {
            if (Input.GetKeyUp(KeyCode.Q))
                StartCoroutine(TeleportWithJump(slot1));
            if (Input.GetKeyUp(KeyCode.W))
                StartCoroutine(TeleportWithJump(slot2));
            if (Input.GetKeyUp(KeyCode.E))
                StartCoroutine(TeleportWithJump(slot3));
            if (Input.GetKeyUp(KeyCode.A))
                StartCoroutine(TeleportWithJump(slot4));
            if (Input.GetKeyUp(KeyCode.S))
                StartCoroutine(TeleportWithJump(slot5));
            if (Input.GetKeyUp(KeyCode.D))
                StartCoroutine(TeleportWithJump(slot6));
        }
    }

    IEnumerator TeleportWithJump(Transform targetSlot)
    {
        evadeTime = 0;
        stamina.MoveStamina();
        audioSource.Play();

        Vector3 startPos = Player.transform.position;
        Vector3 jumpApex = startPos + Vector3.up * jumpHeight;
        float jumpTime = 0.1f; 

        float elapsedTime = 0;
        while (elapsedTime < jumpTime)
        {
            Player.transform.position = Vector3.Lerp(startPos, jumpApex, elapsedTime / jumpTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Player.transform.position = targetSlot.position + Vector3.up * jumpHeight;

        elapsedTime = 0;
        while (elapsedTime < jumpTime)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, targetSlot.position, elapsedTime / jumpTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Player.transform.position = targetSlot.position;
    }
}
