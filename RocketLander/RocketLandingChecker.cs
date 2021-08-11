using System;
using System.Collections.Generic;
using System.Linq;

namespace RocketLander
{
    public class RocketLandingChecker
    {
        private const int _landingAreaSize = 100;
        private const int _platformStartX = 5;
        private const int _platformStartY = 5;

        private readonly int _platformEndX;
        private readonly int _platformEndY;

        private List<LandingPosition> _checkedPositions = new List<LandingPosition>();

        public RocketLandingChecker(int platformSizeWidth, int platformSizeHeight)
        {
            if(platformSizeWidth <= 0 || platformSizeHeight <= 0)
                throw new ArgumentOutOfRangeException(Constants.NotValidPlatformSizeError);

            _platformEndX = platformSizeWidth + _platformStartX;
            _platformEndY = platformSizeHeight + _platformStartY;

            if (_platformEndX > _landingAreaSize || _platformEndY > _landingAreaSize)
                throw new ArgumentOutOfRangeException(Constants.NotValidPlatformSizeError);
        }

        public string CheckLandingStatus(int x, int y)
        {
            if (IsOutOfPlatform(x, y))
                return Constants.OutOfPlatformMessage;

            if (_checkedPositions.Any(position => position.IsInClashArea(x, y)))
                return Constants.ClashMessage;

            _checkedPositions.Add(new LandingPosition(x, y));

            return Constants.OkMessage;
        }

        private bool IsOutOfPlatform(int x, int y)
        {
            return !(x >= _platformStartX && x < _platformEndX && 
                     y >= _platformStartY && y < _platformEndY);
        }
    }
}
