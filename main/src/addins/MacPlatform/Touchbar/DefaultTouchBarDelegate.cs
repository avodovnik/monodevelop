//
// DefaultTouchBarDelegate.cs
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
	public class DefaultTouchBarDelegate : MonoTouchBarDelegate
	{
		public override NSTouchBarItem MakeItem (NSTouchBar touchBar, string identifier)
		{
			NSCustomTouchBarItem item = new NSCustomTouchBarItem (identifier);

			switch (ParseId (identifier)) {
			case 0: {
					item.View = NSButton.CreateButton ("1️⃣ Button", () => Console.WriteLine ("Button"));
					return item;
				}
			case 1: {
					item.View = NSSegmentedControl.FromLabels (new string [] { "Label1", "Label2" }, NSSegmentSwitchTracking.SelectAny, () => Console.WriteLine ("Seg Label"));
					return item;
				}
			case 2: {
					item.View = new NSImageView () {
						Image = NSImage.ImageNamed (NSImageName.TouchBarGetInfoTemplate),
					};
					return item;
				}
			case 3: {
					item.View = NSSegmentedControl.FromImages (
						new NSImage [] {
										NSImage.ImageNamed (NSImageName.TouchBarVolumeDownTemplate),
										NSImage.ImageNamed (NSImageName.TouchBarVolumeUpTemplate) },
						NSSegmentSwitchTracking.SelectAny, () => Console.WriteLine ("Seg Images"));
					return item;
				}
			case 4: {
					item.View = NSSlider.FromValue (5, 0, 10, () => Console.WriteLine ("Slider"));
					return item;
				}

			}
			return null;
		}
	}
}
