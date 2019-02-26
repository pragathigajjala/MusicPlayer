using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicPlayer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            fop.ViewMode = PickerViewMode.Thumbnail;
            fop.FileTypeFilter.Add(".mp3");
            StorageFile file = await fop.PickSingleFileAsync();
            if(file!=null)
            {
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                Media.SetSource(stream, file.ContentType);
                Media.Play();
            }

           
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if(Media.DefaultPlaybackRate!=1)
            {
                Media.DefaultPlaybackRate = 1.0;
            }
            Media.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Media.Pause();
        }
    }
}
