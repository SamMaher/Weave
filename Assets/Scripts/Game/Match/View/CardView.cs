using UnityEngine;
using UnityEngine.UI;

public class CardView : EntityView<Card> {
    
    //UI References
    public Text Name;
//    public Image cardArt;
    public Text Text;
//    public Image cardBackground;
    
    public override void MatchViewToEntity()
    {      
        Name.text = EntityReference.Name;
        Text.text = EntityReference.RenderText();
    }
}

