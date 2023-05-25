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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.SetText("Lives: " + pc.Lives);

        scoreText.SetText("score: " + score);
    }
    public IEnumerator Hurt()
    {
        pc.moveSpeed = 0;
        pc.cc = null;
        pc.Lives--;
        yield return new WaitForSeconds(3);
        Debug.Log(pc.moveSpeed);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        PlayerRespawn();
    }
    public void PlayerRespawn()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        pc.moveSpeed = 7;
    }
}
