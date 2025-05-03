using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillDescription : MonoBehaviour
{
    public TMP_Text skillTitle;
    public TMP_Text skillDescription;

    public void toolTipNone()
    {
        skillTitle.text = "";
        skillDescription.text = "";
    }

    public void toolTipHealthBoost()
    {
        skillTitle.text = "Desciderium Heart";
        skillDescription.text = "+ 1 Permanent heart";
    }

    public void toolTipHealthBoost2()
    {
        skillTitle.text = "Trepidatious Essence";
        skillDescription.text = "+ 1 Permanent heart";
    }

    public void toolTipMovespeedBoost()
    {
        skillTitle.text = "Pathfinder's Grace";
        skillDescription.text = "Slight movement increase";
    }

    public void toolTipTerraShardBoost()
    {
        skillTitle.text = "Shard Seeker";
        skillDescription.text = "Slight increase in Terra shard droprate";
    }
    public void toolTipTerraShardBoost2()
    {
        skillTitle.text = "Terrasurge";
        skillDescription.text = "Moderate increase in Terra shard droprate";
    }

    public void toolTipDamageBoost()
    {
        skillTitle.text = "Berserker's Path";
        skillDescription.text = "Slight damage increase against enemies";
    }

    public void toolTipDamageBoost2()
    {
        skillTitle.text = "Renewal's Edge";
        skillDescription.text = "Moderate damage increase against enemies";
    }

    public void toolTipUnlockKey()
    {
        skillTitle.text = "Melancholia's Key";
        skillDescription.text = "Grants access to Depression's Lair";
    }
}
