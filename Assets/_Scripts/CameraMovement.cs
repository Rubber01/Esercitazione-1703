using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float maxDistance = 2000;
    public int speed = 1;
    public float distance;

    public GameObject cube;
    public int initCubePosition = 299600;
    public int initValue = 300;
    public Transform parent;

    Vector3 startPosition = Vector3.zero;


    private void Awake()
    {
        this.transform.position = startPosition;
        InitCube();
        WebsocketManager.Instance.onMessageReceived += ChangeSpeed;
    }

    private void OnDestroy()
    {
        WebsocketManager.Instance.onMessageReceived -= ChangeSpeed;

    }

    private void ChangeSpeed(string newSpeed)
    {
        Debug.Log($"New Speed: {newSpeed}");
        speed = int.Parse(newSpeed);
    }

    private void FixedUpdate()
    {
        distance = this.transform.position.z;
        //distance=Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y, distance), startPosition);
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    public void changeDistance(int changeDistance)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, changeDistance);
    }

    public void InitCube()
    {

        for (int i = 0; i < initValue; i += 2)
        {

            Vector3 v = new Vector3(3, 0, 299600 + i);

            GameObject newCube = Instantiate(cube, parent);

            newCube.transform.position = v;

            newCube.isStatic = true;

        }

        for (int i = 0; i < initValue; i += 2)
        {

            Vector3 v = new Vector3(-3, 0, 299600 + i);

            GameObject newCube = Instantiate(cube, parent);

            newCube.transform.position = v;

            newCube.isStatic = true;
        }


    }

}
