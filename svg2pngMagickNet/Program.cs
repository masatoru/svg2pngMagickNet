using System;

namespace svg2pngMagickNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込む設定をします。
            var magicSettings = new ImageMagick.MagickReadSettings();

            // [罠]ここでdpiを指定します。指定しないと画質が荒くなります。1000としたらInkscapeで出力した時よりも綺麗になりました。
            var dpi = 300;
            magicSettings.Density = new ImageMagick.Density(dpi);

            // [罠]ここで背景色を透明にしないと透明部分が全部真っ白になります。
            magicSettings.BackgroundColor = new ImageMagick.MagickColor("#00000000");

            var path = ".\\1.svg";
            var outPath = ".\\1.png";

            Console.WriteLine(path);
            Console.WriteLine($"==>{outPath}");

            //　さて、いよいよ読み込みです。
            using (var magickImage = new ImageMagick.MagickImage(path, magicSettings))
            {
                var width = 128;
                var height = 128;
                // 出力後のサイズを指定します。
                magickImage.Scale(width, height);

                // 読み込みと出力フォーマットが異なるならここで指定します。
                magickImage.Format = ImageMagick.MagickFormat.Png;

                // 変わらなっかたが念のためQualityを100にしておきました。
                magickImage.Quality = 100;

                // 出力
                magickImage.Write(outPath);
            }
        }
    }
}
