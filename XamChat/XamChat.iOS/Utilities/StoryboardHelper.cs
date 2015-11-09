using System;
using System.Collections.Generic;
using System.Text;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace XamChat.iOS.Utilities
{
    public class StoryboardHelper : MvxTouchViewsContainer
    {
        public StoryboardHelper()
        {
        }

        protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            try
            {
                UIStoryboard storyboard = UIStoryboard.FromName(AppDelegate.MainStoryboard, null);
                if (storyboard != null)
                {
                    UIViewController uiViewController = storyboard.InstantiateViewController(viewType.Name);
                    if (uiViewController is IMvxTouchView)
                    {
                        return uiViewController as IMvxTouchView;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
    }
}