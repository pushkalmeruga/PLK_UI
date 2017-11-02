using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace PLK__
{
    public class ImageHelper
    {
        public static ImageSource ToImageSource(byte[] image = null)
        {
            if (image != null)
                return ImageSource.FromStream(() => new MemoryStream(image));
            else
                return ImageSource.FromFile("Profile.png");
        }
    }
}
