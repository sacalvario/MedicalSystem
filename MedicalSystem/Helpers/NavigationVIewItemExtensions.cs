using MedicalSystem.ViewModels;
using System;

namespace ModernWpf.Controls
{
    public static class NavigationVIewItemExtensions
    {
        public static Type SetTargetPageType(this NavigationViewItem navigationViewItem)
        {
            return navigationViewItem != null
                ? navigationViewItem.Tag.ToString() switch
                {
                    "Diagnostico" => typeof(MainViewModel),
                    _ => null,
                }
                : null;
        }
    }
}
