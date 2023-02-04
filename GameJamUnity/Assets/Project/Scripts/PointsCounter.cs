using System.Collections.Generic;

namespace Project.Scripts
{
    public class PointsCounter
    {
        private Dictionary<PlayerType, int> _points = new();

        private static PointsCounter _instance;
        
        public static PointsCounter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PointsCounter();

                    _instance._points.Add(PlayerType.One, 0);
                    _instance._points.Add(PlayerType.Two, 0);
                }

                return _instance;
            }
        }
        
        public void InsertPoints(PlayerType player, int amount)
        {
            _points[player] += amount;
        }

        public int GetPoints(PlayerType playerType)
        {
            return _points[playerType];
        }
    }
}