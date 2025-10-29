using UnityEngine;
using Unity.Collections;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] public ParticleSystem water;
    public float Starttime;
    public Animator anim;
    public bool isWatering;

    private void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
        anim.SetBool("isIdle", true);
        anim.SetBool("isWatering", false);
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
        anim.SetBool("isIdle", true);
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
        if (Input.GetMouseButtonDown(0) && transform.position.x == GetWorldPositionFromMouse().x && transform.position.y == GetWorldPositionFromMouse().y)
        {
            var ParticleMainSettings = water.main;
            ParticleMainSettings.loop = true;
            Starttime = Time.time;
            isWatering = true;
            anim.SetBool("isWatering", isWatering);
            water.Play();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            var ParticleMainSettings = water.main;
            ParticleMainSettings.loop = false;
            isWatering = false;
            anim.SetBool("isWatering", isWatering);
        }
    }
}
