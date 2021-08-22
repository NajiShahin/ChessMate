using Android.Media;
using Imi.Project.Mobile.Domain.Services.Interfaces.NativeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Imi.Project.Mobile.Droid.Services.PlatformSoundPlayer))]

namespace Imi.Project.Mobile.Droid.Services
{
    public class PlatformSoundPlayer : ISoundPlayer
    {
        private MediaPlayer _mediaPlayer;

        public Task PlaySound()
        {
            _mediaPlayer = MediaPlayer
                .Create(global::Android.App.Application.Context, Resource.Raw.Move);
            _mediaPlayer.Start();
            return Task.Delay(0);
        }
    }
}