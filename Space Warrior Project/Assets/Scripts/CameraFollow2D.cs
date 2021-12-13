using UnityEngine;
using System.Collections;

public class CameraFollow2D: MonoBehaviour
{

    [Header("Size")]
    [SerializeField] private float cameraNewSize;
    [SerializeField] private float cameraSizeChangeTime;
    private float cameraDefaultSize;
    
    [Header("Movement")]

    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    private Transform player;
    private int lastX;

    void Start()
    {
        cameraDefaultSize = Camera.main.orthographicSize;
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);
    }

    public void FindPlayer(bool playerFaceLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerFaceLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    void Update()
    {
        if (player)
        {
            if(Input.GetKey(KeyCode.X))
            {
                float currectSize = Camera.main.orthographicSize;
                Camera.main.orthographicSize = Mathf.Lerp(currectSize, cameraNewSize, cameraSizeChangeTime * Time.deltaTime);   
            }
            else
            {
                float currectSize = Camera.main.orthographicSize;
                Camera.main.orthographicSize = Mathf.Lerp(currectSize, cameraDefaultSize, cameraSizeChangeTime * Time.deltaTime);
            }

            int currentX = Mathf.RoundToInt(player.position.x);
            if (Input.GetKey(KeyCode.D)) faceLeft = false; else if (Input.GetKey(KeyCode.A)) faceLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if (faceLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}