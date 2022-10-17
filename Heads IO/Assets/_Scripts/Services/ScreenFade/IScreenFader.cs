using System;

namespace _Scripts.Services.ScreenFade
{
    public interface IScreenFader
    {
        public void ShowCurtain(Action onComplete = null);
        public void ShowCurtainImmediate();
        public void HideCurtain(Action onComplete = null);
        public void HideCurtainImmediate();
    }
}