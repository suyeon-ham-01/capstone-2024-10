using UnityEngine;

public class AlienAnimController : BaseAnimController
{
    #region Update

    protected override void PlayIdle()
    {
        XParameter = Mathf.Lerp(XParameter, 0, Runner.DeltaTime * 5);
        ZParameter = Mathf.Lerp(ZParameter, 0, Runner.DeltaTime * 5);
        SpeedParameter = Mathf.Lerp(SpeedParameter, 0, Runner.DeltaTime * 5);

        SetParameterFalse();
        SetFloat("X", XParameter);
        SetFloat("Z", ZParameter);
        SetFloat("Speed", SpeedParameter);
    }

    protected override void PlayMove()
    {
        XParameter = Mathf.Lerp(XParameter, Creature.Direction.x, Runner.DeltaTime * 5);
        ZParameter = Mathf.Lerp(ZParameter, Creature.Direction.z, Runner.DeltaTime * 5);

        switch (CreaturePose)
        {
            case Define.CreaturePose.Stand:
                SetFloat("Z", ZParameter);
                SpeedParameter = Mathf.Lerp(SpeedParameter, 1f, Runner.DeltaTime * 5);
                break;
            case Define.CreaturePose.Sit:
                SetFloat("Z", ZParameter);
                SpeedParameter = Mathf.Lerp(SpeedParameter, 1, Runner.DeltaTime * 5);
                break;
            case Define.CreaturePose.Run:
                SetFloat("Z", ZParameter * 1.8f);
                SpeedParameter = Mathf.Lerp(SpeedParameter, 2, Runner.DeltaTime * 5);
                break;
        }

        SetParameterFalse();
        SetFloat("X", XParameter);
        SetFloat("Speed", SpeedParameter);
    }

    #endregion

    #region Play

    public void PlayBasicAttack()
    {
        SetBool("BasicAttack", true);
    }

    public void PlayCrashDoor()
    {
        SetBool("CrashDoor", true);
    }
    public void PlayReadyRoar()
    {
        SetBool("ReadyRoar", true);
    }

    public void PlayRoar()
    {
        SetBool("Roar", true);
        SetBool("ReadyRoar", false);
    }

    public void PlayReadyCursedHowl()
    {
        SetBool("ReadyRoar", true);
    }

    public void PlayCursedHowl()
    {
        SetBool("CursedHowl", true);
        SetBool("ReadyRoar", false);
    }

    public void PlayReadyLeapAttack()
    {
        SetBool("ReadyLeapAttack", true);
    }

    public void PlayLeapAttack()
    {
        SetBool("LeapAttack", true);
        SetBool("ReadyLeapAttack", false);
    }

    #endregion

    protected override void SetParameterFalse()
    {
        SetBool("BasicAttack", false);
        SetBool("CrashDoor", false);
        SetBool("ReadyRoar", false);
        SetBool("Roar", false);
        SetBool("CursedHowl", false);
        SetBool("LeapAttack", false);
        SetBool("ReadyRoar", false);
        SetBool("ReadyLeapAttack", false);
    }
}
