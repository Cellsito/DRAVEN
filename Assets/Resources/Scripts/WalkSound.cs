using Invector.vCharacterController;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioSource audioSource; // Referência ao AudioSource
    public AudioClip[] footstepClips; // Vários sons de passos para variar o som
    public float stepInterval = 0.5f; // Intervalo entre os passos

    private vThirdPersonController controller;
    private float stepTimer;

    void Start()
    {
        controller = GetComponent<vThirdPersonController>();
        stepTimer = 0f;
    }

    void Update()
    {
        if (controller.isGrounded && gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer > stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; // Reseta o timer se não estiver se movendo
        }

        
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length); // Variedade nos sons
            audioSource.clip = footstepClips[index];
            audioSource.Play();
        }
    }
}
