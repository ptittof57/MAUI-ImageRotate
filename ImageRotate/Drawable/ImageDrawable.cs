using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace ImageRotate.Drawable
{
    public class ImageDrawable : IDrawable
    {
        private IImage _image;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (this._image == null)
            {
                Assembly assembly = this.GetType().GetTypeInfo().Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("ImageRotate.Resources.Images.dotnet_bot.png"))
                {
                    this._image = PlatformImage.FromStream(stream);
                }
            }

            canvas.DrawImage(this._image, 0, 0, this._image.Width, this._image.Height);
        }
    }
}
