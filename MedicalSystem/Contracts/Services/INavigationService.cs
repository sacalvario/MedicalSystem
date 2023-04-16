﻿using System;
using System.Windows.Controls;

namespace MedicalSystem.Contracts.Services
{
    public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {
        event EventHandler<string> Navigated;

        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        void NavigateTo(string pageKey, object parameter, bool clearNavigation);

        void UnsubscribeNavigation();

        void CleanNavigation();
    }
}
