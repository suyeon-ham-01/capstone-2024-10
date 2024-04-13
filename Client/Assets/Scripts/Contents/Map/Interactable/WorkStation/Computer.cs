using Fusion;


public class Computer : BaseWorkStation
{
    public override string InteractDescription => "USE COMPUTER";

    protected override void Init()
    {
        base.Init();

        CanRememberWork = true;
        IsCompleted = false;

        TotalWorkAmount = 50f;
    }
    public override bool CheckInteractable(Creature creature)
    {
        if (creature is not Crew crew)
        {
            creature.IngameUI.InteractInfoUI.Hide();
            creature.IngameUI.ErrorTextUI.Hide();
            return false;
        }

        if (creature.CreatureState == Define.CreatureState.Interact)
        {
            creature.IngameUI.InteractInfoUI.Hide();
            creature.IngameUI.ErrorTextUI.Hide();
            return false;
        }

        if (IsCompleted)
        {
            creature.IngameUI.InteractInfoUI.Hide();
            creature.IngameUI.ErrorTextUI.Show("COMPLETED");
            return false;
        }

        creature.IngameUI.ErrorTextUI.Hide();
        creature.IngameUI.InteractInfoUI.Show(InteractDescription);
        return true;
    }

    protected override bool IsInteractable(Creature creature)
    {
        return true;
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    protected override void Rpc_WorkComplete()
    {
        if (IsCompleted) return;
        IsCompleted = true;
    }

    protected override void PlayInteractAnimation()
    {
        CrewWorker.CrewAnimController.PlayKeypadUse();
    }

    protected override void PlayEffectMusic()
    {
        Managers.SoundMng.Play("Music/Clicks/Typing_Keyboard", Define.SoundType.Effect, 0.5f, true);
    }


}
