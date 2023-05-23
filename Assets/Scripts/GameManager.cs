using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI LivesText;

    public float score;
    public TextMeshProUGUI scoreText;

    public PlayerController pc;
    public GameObject playerPrefab; // Reference to the player prefab
    public Transform[] spawnPoints; // Array of spawn points for the player

    private GameObject currentPlayer; // Reference to the current player instance

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.SetText("Lives: " + pc.Lives);
        score = 0;
        scoreText.SetText("score: " + score);
    }
    public IEnumerator Hurt()
    {
        pc.moveSpeed = 0;
        pc.Lives--;
        pc.cc = null;
        yield return new WaitForSeconds(3);
        PlayerRespawn();
        Destroy(GameObject.Find("Player"));
    }
    public void PlayerRespawn()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        pc.moveSpeed = 7;
    }
}
