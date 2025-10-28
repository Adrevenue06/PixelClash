using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private ParticleSystem water;

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ParticleMainSettings = water.main;
            ParticleMainSettings.loop = true;
            water.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            var ParticleMainSettings = water.main;
            ParticleMainSettings.loop = false;
        }
    }
}
