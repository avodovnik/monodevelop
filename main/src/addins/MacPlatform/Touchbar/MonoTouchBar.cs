//
// MonoTouchBar.cs
//
// Author:
//       anvod <anvod@microsoft.com>
//
// Copyright (c) 2019 Microsoft
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using AppKit;

namespace Touchbar
{
	public class MonoTouchBar : NSTouchBar
	{
		public MonoTouchBar ()
		{
			this.Delegate = new GetToCodeTouchBarDelegate ();

			//if (current.AllowCustomization) {
			//	var idList = GenerateCurrentIDList (current);
			//	bar.CustomizationIdentifier = "com.xamarin.example.customBar";
			//	bar.DefaultItemIdentifiers = idList.Take (2).ToArray ();
			//	bar.CustomizationAllowedItemIdentifiers = idList;
			//} else {
			this.DefaultItemIdentifiers = new string [] { MonoTouchBarDelegate.CreateID (1) };
			//}
		}
	}

	public abstract class MonoTouchBarDelegate : NSTouchBarDelegate
	{
		public virtual bool AllowCustomization { get; } = false;

		internal static int ParseId (string identifier)
		{
			return int.Parse (identifier.Replace ("com.monodevelop.touchbar.", ""));
		}

		internal static string CreateID (int number)
		{
			return string.Format ("com.monodevelop.touchbar.{0}", number);
		}
	}
}
