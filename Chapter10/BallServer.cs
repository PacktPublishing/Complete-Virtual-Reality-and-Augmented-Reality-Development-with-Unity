using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallServer : MonoBehaviour
{
    public GameObject ballPrefab;
    public float startHeight = 10f;
    public float interval = 5f;

    private Transform player;

    public List<Color> colors = new List<Color>();
    [SerializeField] private int colorId;


    void Start()
    {
        colorId = Random.Range(0, colors.Count);
        player = Camera.main.transform;
        StartCoroutine("DropBall");
    }

    IEnumerator DropBall()
    {
        while (true)
        {
            Vector3 position = new Vector3(player.position.x, startHeight, player.position.z);
            GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);
            //ball.GetComponent<Renderer>().material.color = colors[colorId];
            NetworkServer.Spawn(ball);
            //ball.GetComponent<NetworkColor>().color = colors[colorId];
            ball.GetComponent<StateVariables>().SetColor( colors[colorId] );
            Destroy(ball, interval * 5);

            yield return new WaitForSeconds(interval);
        }
    }
}
