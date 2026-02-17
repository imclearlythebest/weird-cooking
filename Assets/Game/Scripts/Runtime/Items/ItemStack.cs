[System.Serializable]
public class ItemStack
{
    public ItemDefinition definition;
    public int quantity;
    public float unitPrice;
    
    public ItemStack(ItemDefinition definition, int quantity)
    {
        this.definition = definition;
        this.quantity = quantity;
    }
    public void UpdateUnitPrice(float newUnitPrice)
    {
        unitPrice = newUnitPrice;
    }
    public int IncrementQuantity(int amount)
    {
        quantity += amount;
        return quantity;
    }
    public int DecrementQuantity(int amount)
    {
        quantity -= amount;
        return quantity;
    }


    
}
