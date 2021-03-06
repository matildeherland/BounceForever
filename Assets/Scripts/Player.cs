﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private CameraController mainCamera;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ParticleSystem coinCollectEffect;

    private int currentPlatform;
    private Rigidbody playerRb;
    private Collider collider;
    private int scoreToAdd = 1;


    private float deathOffset = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < mainCamera.transform.position.y - deathOffset)
        {
            gameManager.GameOver();
            Destroy(this.gameObject);
        }

        if (playerRb.velocity.y <= 0)
        {
            //collider.enabled = true;
        }
        else
        {
            //collider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerRb.AddForce(Vector3.up * bounceForce * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Platform>() != null)
        {
            if (playerRb.velocity.y <= 0)
            {
                other.GetComponent<Collider>().isTrigger = false;
            }

            if (currentPlatform != other.GetComponent<Platform>().platformNumber)
            {
                mainCamera.MoveCamera(other.gameObject.transform.position);
                scoreManager.AddToType(Scores.SCORE, scoreToAdd);
            }
        }
        else if (other.GetComponent<CoinPickup>() != null)
        {
            scoreManager.AddToType(Scores.COINS, 1);
            Instantiate(coinCollectEffect, other.transform.position, coinCollectEffect.transform.rotation);
            other.gameObject.SetActive(false);
        }
        else if (other.GetComponent<PerfectZone>() != null)
        {
            other.GetComponent<PerfectZone>().ActivateSelf();
            scoreToAdd++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Platform>() != null)
        {
            other.GetComponent<Collider>().isTrigger = false;
        }
    }
}
