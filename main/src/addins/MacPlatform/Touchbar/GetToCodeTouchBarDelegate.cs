//
// GetToCodeTouchBarDelegate.cs
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
using System.Linq;
using AppKit;
using Foundation;
using MonoDevelop.Ide;

namespace Touchbar
{
	public class GetToCodeTouchBarDelegate : MonoTouchBarDelegate, INSCandidateListTouchBarItemDelegate
	{
		DesktopService _desktopService;
		NSCandidateListTouchBarItem _candidateListItem;

		public GetToCodeTouchBarDelegate ()
		{
			MonoDevelop.Core.Runtime.ServiceProvider.WhenServiceInitialized<DesktopService> (s => {
				_desktopService = s;
				// populate the list for the touch bar? 
				NSRunLoop.Main.BeginInvokeOnMainThread (OnDesktopServiceInitialized);
			});


		}

		private void OnDesktopServiceInitialized ()
		{
			if (_candidateListItem != null) {
				var projList = _desktopService.RecentFiles.GetProjects ().Take (3);
				_candidateListItem.SetCandidates (projList.Select (x => new NSString (x.DisplayName)).ToArray(), new NSRange (0, 3), "");
			}
		}

		public override NSTouchBarItem MakeItem (NSTouchBar touchBar, string identifier)
		{
			_candidateListItem = new NSCandidateListTouchBarItem (identifier);
			_candidateListItem.Delegate = this;
			//_candidateListItem.SetCandidates (new NSString [] { (NSString)"Hello", (NSString)"World", (NSString)"Touch" },
			//		new NSRange (0, 3), "");

			return _candidateListItem;
		}
	}
}
