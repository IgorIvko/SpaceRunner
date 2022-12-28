using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityAction SkullBoxBang;
    public UnityAction<float> AddSpeed;
    public UnityAction<float> TimeOfSpawnDecrease;
    public UnityAction SoundOnOff;

    public UnityAction<Vector3> EnemyDie;   
    
    public UnityAction<Vector3> AidKitHealing;

    public UnityAction<Vector3> ItemDie;

    public UnityAction<Vector3> HeroShoot;
    public UnityAction HeroDamaged;
    public UnityAction HeroDie;
    public UnityAction<int> HeroHealthChanged;

    public UnityAction BossSpawned;
    public UnityAction<int> BossHealthChanged;
    public UnityAction<Vector3> BossDamaged;
    public UnityAction<Vector3> BossDie;
    public UnityAction BossAngry;

    public UnityAction<Vector3> FireballDamage;
    public UnityAction FireballSpawned;

    public UnityAction AsteroidShooted; 
    public UnityAction<Vector3> AsteroidDestroyed;

    public UnityAction GameOverLose;
    public UnityAction GameOverWin;
}
