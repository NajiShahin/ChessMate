using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaElement = Windows.UI.Xaml.Controls.MediaElement;
using Imi.Project.Mobile.Domain.Services.Interfaces.NativeApi;

[assembly: Dependency(typeof(Imi.Project.Mobile.UWP.Services.PlatformSoundPlayer))]

namespace Imi.Project.Mobile.UWP.Services
{
    public class PlatformSoundPlayer : ISoundPlayer
    {
        public async Task PlaySound()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package
                .Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("move.wav");
            var stream = await file.OpenReadAsync();
            mysong.SetSource(stream, file.ContentType);
            mysong.Play();
        }
    }
}