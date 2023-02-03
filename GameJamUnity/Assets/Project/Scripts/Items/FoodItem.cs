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
                var pointsItem = gameObject.AddComponent<PointsItem>();
                pointsItem.Player = playerType;
                pointsItem.Points = Points;
                
                tree.Unlock();
                Destroy(this);
            }
        }
    }
}