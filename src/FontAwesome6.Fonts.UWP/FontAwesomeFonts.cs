﻿using System;
using System.Collections.Generic;
using System.Linq;

using Windows.UI.Xaml.Media;

namespace FontAwesome6.Fonts
{
    /// <summary>
    /// Provides FontFamilies and TypeFaces of FontAwesome6.
    /// </summary>
    public static class FontAwesomeFonts
    {
        private static readonly Dictionary<EFontAwesomeStyle, FontFamily> _fontFamilies = new Dictionary<EFontAwesomeStyle, FontFamily>();
        private static readonly Dictionary<EFontAwesomeStyle, Tuple<string, string>> _fonts = new Dictionary<EFontAwesomeStyle, Tuple<string, string>>();

        static FontAwesomeFonts()
        {
            _fonts.Add(EFontAwesomeStyle.Brands, Tuple.Create("Font Awesome 6 Brands-Regular-400.otf", "Font Awesome 6 Brands"));
#if FontAwesomePro
      _fonts.Add(EFontAwesomeStyle.Solid, Tuple.Create("Font Awesome 6 Pro-Solid-900.otf", "Font Awesome 6 Pro"));
      _fonts.Add(EFontAwesomeStyle.Regular, Tuple.Create("Font Awesome 6 Pro-Regular-400.otf", "Font Awesome 6 Pro"));
      _fonts.Add(EFontAwesomeStyle.Light, Tuple.Create("Font Awesome 6 Pro-Light-300.otf", "Font Awesome 6 Pro"));
      _fonts.Add(EFontAwesomeStyle.Thin, Tuple.Create("Font Awesome 6 Pro-Light-300.otf", "Font Awesome 6 Pro"));
      _fonts.Add(EFontAwesomeStyle.Duotone, Tuple.Create("Font Awesome 6 Duotone-Solid-900.otf", "Font Awesome 6 Duotone"));
#else
            _fonts.Add(EFontAwesomeStyle.Solid, Tuple.Create("Font Awesome 6 Free-Solid-900.otf", "Font Awesome 6 Free"));
            _fonts.Add(EFontAwesomeStyle.Regular, Tuple.Create("Font Awesome 6 Free-Regular-400.otf", "Font Awesome 6 Free"));

            LoadAllStyles("ms-appx:///FontAwesome6.Fonts.UWP/Fonts/");
#endif
        }

        public static FontFamily GetFontFamily(EFontAwesomeStyle style)
        {
            if (_fontFamilies.TryGetValue(style, out var fontFamily))
            {
                return fontFamily;
            }

            throw new Exception($"Couldn't find FontFamily for {style}. Please load the font file for {style}.");
        }

        /// <summary>
        /// Loads the FontFamily and Typeface for the specific EFontAwesomeStyles.
        /// </summary>
        /// <param name="uri">Uri to the location of the font file.
        /// Load from resources: new Uri("ms-appx:///FontAwesome6.UWP/Fonts/")
        /// Load from a directory: new Uri("file:///C:/Temp/", UriKind.Absolute)
        /// </param>
        /// <param name="styles">The EFontAwesomeStyles which should be loaded.</param>
        public static void LoadStyles(Uri uri, params EFontAwesomeStyle[] styles)
        {
            foreach (var style in styles)
            {
                _fontFamilies[style] = new FontFamily($"{uri.AbsoluteUri}{_fonts[style].Item1}#{_fonts[style].Item2}");
            }
        }


        /// <summary>
        /// Loads the FontFamily and Typeface for the specific EFontAwesomeStyles.
        /// </summary>
        /// <param name="uri">Uri to the location of the font file.
        /// Load from resources: new Uri("ms-appx:///FontAwesome6.UWP/Fonts/")
        /// Load from a directory: new Uri("file:///C:/Temp/", UriKind.Absolute)
        /// </param>
        /// <param name="styles">The EFontAwesomeStyles which should be loaded.</param>
        public static void LoadStyles(string uri, params EFontAwesomeStyle[] styles)
        {
            LoadStyles(new Uri(uri), styles);
        }

        /// <summary>
        /// Loads all FontFamilies and Typefaces for all EFontAwesomeStyles.    
        /// </summary>
        /// <param name="uri">Uri to the location of all font files.
        /// Load from resources: new Uri("pack://application:,,,/FontAwesome6.Net;component/Fonts/")
        /// Load from a directory: new Uri("file:///C:/Temp/", UriKind.Absolute)
        /// </param>
        public static void LoadAllStyles(Uri uri)
        {
            LoadStyles(uri, _fonts.Keys.ToArray());
        }

        /// <summary>
        /// Loads all FontFamilies and Typefaces.    
        /// </summary>
        /// <param name="absolutePath">Path to the location of all font files.</param>
        public static void LoadAllStyles(string uri)
        {
            LoadAllStyles(new Uri(uri));
        }
    }
}
