namespace Project.Scripts.Items
{
    public class FoodItem : Item
    {
        public int Points;
        
        protected override void OnAction(PlayerType playerType)
        {
            var tree = BottomTreeItem.Instances[playerType];
            
            if (tree.IsLock)
            {
                PointsCounter.Instance.InsertPoints(playerType, Points);
                
                tree.Unlock();
                Destroy(this);
            }
        }
    }
}