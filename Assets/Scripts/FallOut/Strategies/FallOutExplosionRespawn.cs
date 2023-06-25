using System.Collections;
using UnityEngine;

[CreateAssetMenu]
class FallOutExplosionRespawn : FallOutStrategyBase
{
    public ParticleSystem Explosion;
    public Vector3Variable RespawnPosition;
    public Vector3Variable RespawnRotation;
    public float RespawnDelay = 2;

    public override IEnumerator HandleFallout(GameObject gameObject)
    {
        var explosion = Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, RespawnDelay);
        
        gameObject.SetActive(false);
        var mainCamera = gameObject.GetComponentInChildren<Camera>().gameObject;
        var tempCamera = Instantiate(mainCamera, mainCamera.transform.position, mainCamera.transform.rotation);
        
        yield return new WaitForSeconds(RespawnDelay);
        
        Destroy(tempCamera);
        
        gameObject.SetActive(true);

        
        gameObject.transform.SetPositionAndRotation(RespawnPosition.Value, Quaternion.Euler(RespawnRotation.Value));
        var rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
}