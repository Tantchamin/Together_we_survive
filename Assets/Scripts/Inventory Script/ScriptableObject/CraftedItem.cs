using System.Text;

public abstract class CraftedItem : Item{
 
    public byte woodAmount;
    public byte metalAmount;
    public byte tapeAmount;
    public byte clotheAmount;
    public byte gunComponentAmount;
    public byte gunPowderAmount;
    public byte herbAmount;

    public string CraftRecipe()
    {
        StringBuilder craftingRecipe = new StringBuilder("Recipe : <br>");
        if(woodAmount > 0)
            craftingRecipe.Append($"Wood x{woodAmount} <br>");
        if(metalAmount > 0)
            craftingRecipe.Append($"Metal x{metalAmount}<br>");
        if(tapeAmount > 0)
            craftingRecipe.Append($"Tape x{tapeAmount}<br>");
        if(clotheAmount > 0)
            craftingRecipe.Append($"clothe x{clotheAmount} <br>");
        if(gunComponentAmount > 0)
            craftingRecipe.Append($"Guncomponent x{gunComponentAmount}<br>");
        if(gunPowderAmount > 0)
            craftingRecipe.Append($"Gunpowder x{gunPowderAmount}<br>");
        if(herbAmount > 0)
            craftingRecipe.Append($"Herb x{herbAmount}<br> ");


        return craftingRecipe.ToString();

    }

}

