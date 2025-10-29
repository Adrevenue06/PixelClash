using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] public ParticleSystem water;
    public float Starttime;

    private void Start()
    {
        mainCamera = Camera.main;
        water.Stop();
    }


    private void Update()
    {
        PlayWaterEffect();
        MouseDelayedFollow();
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private void MouseDelayedFollow()
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void PlayWaterEffect()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && transform.position.x == GetWorldPositionFromMouse().x && transform.position.y == GetWorldPositionFromMouse().y)
        {
            var ParticleMainSettings = water.main;
            ParticleMainSettings.loop = true;
            Starttime = Time.time;
            water.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            var ParticleMainSettings = water.main;
            ParticleMainSettings.loop = false;
        }
    }
}
