using Fusion;

public class BatteryCharger : BaseWorkStation
{
    public override string InteractDescription => "CHARGE BATTERY";

    protected override void Init()
    {
        base.Init();

        CanRememberWork = false;
        IsCompleted = false;

        TotalWorkAmount = 10f;
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

        if (Managers.MapMng.PlanSystem.IsBatteryChargeFinished)
        {
            creature.IngameUI.InteractInfoUI.Hide();
            creature.IngameUI.ErrorTextUI.Show("CHARGE FINISHED");
            return true;
        }

        if (!(crew.Inventory.CurrentItem is Battery))
        {
            creature.IngameUI.InteractInfoUI.Hide();
            creature.IngameUI.ErrorTextUI.Show("NO BATTERY ON YOUR HAND");
            return true;
        }

        creature.IngameUI.ErrorTextUI.Hide();
        creature.IngameUI.InteractInfoUI.Show(InteractDescription);
        return true;
    }

    protected override void WorkComplete()
    {
        CrewWorker.Inventory.RemoveItem();

        base.WorkComplete();
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    protected override void Rpc_WorkComplete()
    {
        CurrentWorkAmount = 0;
        Managers.MapMng.PlanSystem.BatteryChargeCount++;
    }
    protected override void PlayInteractAnimation()
    {
        CrewWorker.CrewAnimController.PlayChargeBattery();
    }

    protected override void PlayEffectMusic()
    {

    }
}

