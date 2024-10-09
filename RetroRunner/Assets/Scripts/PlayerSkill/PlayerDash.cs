using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerDash : AbilityBase
{
    [Header("Visuals")]
    [SerializeField] private ParticleSystem dashParticle = default;

    [SerializeField] private PlayerMovement playerMovement;

    public override void Ability()
    {
        dashParticle.Play();
        Sequence dash = DOTween.Sequence()
        .Insert(0, transform.DOMove(transform.position + (new Vector3(playerMovement.movementInputDirection.x,0,0)), .2f))
        .AppendCallback(() => dashParticle.Stop());

    }

    private void Start()
    {
        dashParticle.Stop();
    }
}
