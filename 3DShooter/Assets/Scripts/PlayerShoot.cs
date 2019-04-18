using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int gunDamage = 50;
    public float fireRate = .10f;
    public float weaponRange = 50f;
    public float hitForce = 1000f;
    public ParticleSystem muzzleFlash;
    public Animator animator;

    public int maxAmmo = 10;
    public int currentAmmo;
    public int totalAmmo;
    public float reloadTime = 3f;
    private bool isReloading = false;

    private Camera fpsCam;
    private EnemyHealth health;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    public  AudioSource gunAudio;
    public AudioSource reloadAudio;
    private float nextTimeToFire;

    void Start()
    {
        currentAmmo = PlayerVariable.currentAmmo[PlayerVariable.selectedWeapon];
        totalAmmo = PlayerVariable.totalAmmo[PlayerVariable.selectedWeapon];
        fpsCam = GetComponentInParent<Camera>();
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("reloading", false);
        muzzleFlash.Stop();
    }

    void Update()
    {
        if (isReloading)
            return;
        
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire && !PlayerVariable.fireLock)
        {
            nextTimeToFire = Time.time + fireRate;

                //StartCoroutine(ShootEffect());
                ShootEffect();
                Shoot();
            

        }
    }


        IEnumerator Reload()
    {
        reloadAudio.Play();
        isReloading = true;
        
        Debug.Log("Reloading...");

        animator.SetBool("reloading", true);
        yield return new WaitForSeconds(reloadTime- .25f);
        
        animator.SetBool("reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        PlayerVariable.currentAmmo[PlayerVariable.selectedWeapon] = currentAmmo;
        Debug.Log("количество патронов в магазине составляет " + PlayerVariable.currentAmmo);
        totalAmmo -= maxAmmo;
        PlayerVariable.totalAmmo[PlayerVariable.selectedWeapon] = totalAmmo;
        Debug.Log("Общее " + totalAmmo);
        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;
        PlayerVariable.currentAmmo[PlayerVariable.selectedWeapon] = currentAmmo;

        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        {
            health = hit.collider.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.Damage(gunDamage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
        }
    }

    private void ShootEffect()
    {
        gunAudio.Play();
        muzzleFlash.Play();
       // yield return shotDuration;
    }

}
