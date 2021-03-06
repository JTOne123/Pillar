﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pillar
{
    /// <summary>
    /// Page abstration that allows us to get the current navigation object,
    /// display alerts and action sheets on the current top page
    /// </summary>
    public class PageProxy : IPage
    {
        private readonly Func<Page> _pageResolver;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="pageResolver">Provides access to the current top page</param>
        public PageProxy(Func<Page> pageResolver)
        {
            _pageResolver = pageResolver;
        }

        /// <inheritdoc />
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await _pageResolver().DisplayAlert(title, message, cancel);
        }

        /// <inheritdoc />
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await _pageResolver().DisplayAlert(title, message, accept, cancel);
        }

        /// <inheritdoc />
        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await _pageResolver().DisplayActionSheet(title, cancel, destruction, buttons);
        }

        /// <inheritdoc />
        public INavigation Navigation
        {
            get 
            { 
                var page = _pageResolver();
                var navigatioon  = page.Navigation; 
                return navigatioon;
            }
        }
    }
}

