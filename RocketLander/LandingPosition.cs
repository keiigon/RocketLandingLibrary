namespace RocketLander
{
    internal sealed class LandingPosition
    {
        private readonly int _clashAreaStartX;
        private readonly int _clashAreaEndX;
        private readonly int _clashAreaStartY;
        private readonly int _clashAreaEndY;

        public LandingPosition(int x, int y)
        {
            _clashAreaStartX = x - 1;
            _clashAreaEndX = x + 1;
            _clashAreaStartY = y - 1;
            _clashAreaEndY = y + 1;
        }

        public bool IsInClashArea(int x, int y)
        {
            return (x >= _clashAreaStartX && x <= _clashAreaEndX &&
                    y >= _clashAreaStartY && y <= _clashAreaEndY);
        }
    }
}
