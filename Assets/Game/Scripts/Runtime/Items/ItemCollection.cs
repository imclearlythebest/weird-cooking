using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItemCollection: IEnumerable<ItemStack>
{
    public List<ItemStack> itemStacks = new List<ItemStack>();

    public void Add(ItemStack itemStack)
    {
        itemStacks.Add(itemStack);
    }
    public IEnumerator<ItemStack> GetEnumerator()
    {
        return itemStacks.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
